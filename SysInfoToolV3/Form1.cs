using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace SysInfoTool
{
    public partial class Form1 : Form
    {
        private readonly System.Windows.Forms.Timer popupTimer;
        private System.Windows.Forms.Label currentMessageLabel;

        public Form1()
        {
            InitializeComponent();

            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;

            var contextMenu = new ContextMenuStrip(components);
            contextMenu.Items.Add("Open", null, OpenMenuItem_Click);
            contextMenu.Items.Add("Exit", null, ExitMenuItem_Click);
            notifyIcon1.ContextMenuStrip = contextMenu;

            popupTimer = new System.Windows.Forms.Timer(components) { Interval = 2500 };
            popupTimer.Tick += PopupTimer_Tick;

            SetupLabelClickEvents();
            DisplaySystemInfo();
        }

        private string GetLoggedInUser()
            => Environment.UserName;

        private string GetLastRestartTime()
        {
            try
            {
                string raw = GetSystemInfo("LastBootUpTime") as string;
                if (string.IsNullOrWhiteSpace(raw)) return "Not found";

                var dt = ManagementDateTimeConverter.ToDateTime(raw);
                return dt.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
                return "Not found";
            }
        }

        private object GetSystemInfo(string column)
        {
            try
            {
                using var searcher = new ManagementObjectSearcher($"SELECT {column} FROM Win32_OperatingSystem");
                foreach (var item in searcher.Get())
                    return item[column];
            }
            catch { }

            return null;
        }

        private void DisplaySystemInfo()
        {
            ipAddressLabel.Text = GetLocalIPAddress();
            hostNameLabel.Text = GetHostName();
            connectivityLabel.Text = GetConnectivityType();
            computerModelLabel.Text = GetComputerModel();
            serialNumberLabel.Text = GetSerialNumber();
            lastRestartLabel.Text = GetLastRestartTime();
            loggedInUserLabel.Text = GetLoggedInUser();
        }

        // Adapters that are up, preferring those with an IPv4 default gateway. Virtual adapters
        // (Hyper-V vEthernet, WSL, Docker) are usually up but have no gateway, so this keeps them
        // from being reported as the machine's IP / connection type.
        private static List<NetworkInterface> GetActiveInterfaces()
        {
            var up = NetworkInterface.GetAllNetworkInterfaces()
                .Where(n =>
                    n.OperationalStatus == OperationalStatus.Up &&
                    n.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    n.NetworkInterfaceType != NetworkInterfaceType.Tunnel)
                .ToList();

            var routed = up.Where(HasDefaultGateway).ToList();
            return routed.Count > 0 ? routed : up;
        }

        private static bool HasDefaultGateway(NetworkInterface ni)
        {
            try
            {
                return ni.GetIPProperties().GatewayAddresses.Any(g =>
                    g.Address.AddressFamily == AddressFamily.InterNetwork &&
                    !g.Address.Equals(IPAddress.Any));
            }
            catch
            {
                return false;
            }
        }

        private string GetLocalIPAddress()
        {
            try
            {
                foreach (var ni in GetActiveInterfaces())
                {
                    foreach (var ua in ni.GetIPProperties().UnicastAddresses)
                    {
                        if (ua.Address.AddressFamily == AddressFamily.InterNetwork)
                            return ua.Address.ToString();
                    }
                }
            }
            catch { }

            return "Not found";
        }

        private string GetHostName()
            => Environment.MachineName;

        private string GetConnectivityType()
        {
            try
            {
                var nics = GetActiveInterfaces();

                bool wifi = nics.Any(n => n.NetworkInterfaceType == NetworkInterfaceType.Wireless80211);
                bool eth = nics.Any(n =>
                    n.NetworkInterfaceType == NetworkInterfaceType.Ethernet ||
                    n.NetworkInterfaceType == NetworkInterfaceType.GigabitEthernet);

                if (wifi && eth) return "WiFi + Ethernet";
                if (wifi) return "WiFi";
                if (eth) return "Ethernet";
                return "Okänd / offline";
            }
            catch { return "Unknown"; }
        }

        private string GetComputerModel()
        {
            try
            {
                using var mos = new ManagementObjectSearcher("SELECT Model FROM Win32_ComputerSystem");
                foreach (ManagementObject mo in mos.Get())
                    return mo["Model"]?.ToString() ?? "Not found";

                return "Not found";
            }
            catch
            {
                return "Not found";
            }
        }

        private string GetSerialNumber()
        {
            try
            {
                using var mos = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS");
                foreach (ManagementObject mo in mos.Get())
                    return mo["SerialNumber"]?.ToString() ?? "Not found";

                return "Not found";
            }
            catch
            {
                return "Not found";
            }
        }

        private string GetFriendlyLabelName(string label)
        {
            return label switch
            {
                "ipAddressLabel" => "IP Address",
                "hostNameLabel" => "Host Name",
                "connectivityLabel" => "Connectivity",
                "computerModelLabel" => "Model",
                "serialNumberLabel" => "Serial Number",
                "lastRestartLabel" => "Last Restart",
                "loggedInUserLabel" => "User",
                _ => label
            };
        }

        // The X button hides the window back to the tray; the app keeps running.
        // Exit from the tray menu, logoff and shutdown still close it normally.
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void ShowWindow()
        {
            // Values like IP and connection type change while the app sits in the tray.
            DisplaySystemInfo();

            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;

            Show();
            Activate();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                ShowWindow();
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
            => ShowWindow();

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
            => DisplaySystemInfo();

        private void MoreInfoButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "msinfo32.exe",
                    UseShellExecute = true
                });
            }
            catch { }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.Label lbl)
            {
                try { Clipboard.SetText(lbl.Text); } catch { }

                ShowPopup(GetFriendlyLabelName(lbl.Name));
            }
        }

        private void SetupLabelClickEvents()
        {
            ipAddressLabel.Click += Label_Click;
            hostNameLabel.Click += Label_Click;
            connectivityLabel.Click += Label_Click;
            computerModelLabel.Click += Label_Click;
            serialNumberLabel.Click += Label_Click;
            lastRestartLabel.Click += Label_Click;
            loggedInUserLabel.Click += Label_Click;
        }

        private void ShowPopup(string message)
        {
            currentMessageLabel?.Dispose();

            var lbl = new System.Windows.Forms.Label
            {
                AutoSize = true,
                Text = $"Kopierat {message}",
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(5),
                Font = new Font(Font.FontFamily, 9, FontStyle.Bold),
                Location = new Point(10, 10)
            };

            Controls.Add(lbl);
            lbl.BringToFront();
            currentMessageLabel = lbl;

            popupTimer.Stop();
            popupTimer.Start();
        }

        private void PopupTimer_Tick(object sender, EventArgs e)
        {
            popupTimer.Stop();
            currentMessageLabel?.Dispose();
            currentMessageLabel = null;
        }
    }
}
