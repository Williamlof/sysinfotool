using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SysInfoTool
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer popupTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Label currentMessageLabel;
        private Image originalBackground;
        public Form1()
        {
            InitializeComponent();
            InitializeApp();
            label8.Click += Label8_Click;
        }

        private void InitializeApp()
        {
            this.Visible = false;
            notifyIcon1.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            this.Load += Form1_Load;

            DisplaySystemInfo();

            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Open", null, OpenMenuItem_Click);
            notifyIcon1.ContextMenuStrip = contextMenu;
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

        private string GetLocalIPAddress()
        {
            try
            {
                foreach (var ni in NetworkInterface.GetAllNetworkInterfaces()
                    .Where(n =>
                        n.OperationalStatus == OperationalStatus.Up &&
                        n.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                        n.NetworkInterfaceType != NetworkInterfaceType.Tunnel))
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
                var nics = NetworkInterface.GetAllNetworkInterfaces()
                    .Where(n => n.OperationalStatus == OperationalStatus.Up);

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

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            originalBackground = this.BackgroundImage;
            SetupLabelClickEvents();
            popupTimer.Tick += PopupTimer_Tick;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (WindowState == FormWindowState.Minimized)
                    WindowState = FormWindowState.Normal;

                Show();
                BringToFront();
            }
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                WindowState = FormWindowState.Normal;

            Show();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            DisplaySystemInfo();

            // Återställ originalbakgrund
            this.BackgroundImage = originalBackground;
            this.BackgroundImageLayout = ImageLayout.Center;

            // Nollställ index så att nästa "easter egg" börjar från första bilden
            currentBackgroundIndex = 0;
        }



        private void button2_Click(object sender, EventArgs e)
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
            currentMessageLabel = lbl;

            popupTimer.Interval = 2500;
            popupTimer.Start();
        }

        private void PopupTimer_Tick(object sender, EventArgs e)
        {
            popupTimer.Stop();
            currentMessageLabel?.Dispose();
            currentMessageLabel = null;
        }

        private int currentBackgroundIndex = 0;


        private void Label8_Click(object sender, EventArgs e)
        {
            if (!Control.ModifierKeys.HasFlag(Keys.Control))
                return;

            List<Bitmap> backgrounds =
    [
        Properties.Resources.BannerEasterEgg
    ];

            currentBackgroundIndex = (currentBackgroundIndex + 1) % backgrounds.Count;
            BackgroundImage = backgrounds[currentBackgroundIndex];
            BackgroundImageLayout = ImageLayout.Stretch;
        }

    }
}