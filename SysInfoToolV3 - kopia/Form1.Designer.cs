namespace SysInfoTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon1 = new NotifyIcon(components);
            refreshButton = new Button();
            exitButton = new Button();
            hostNameLabel = new Label();
            connectivityLabel = new Label();
            label5 = new Label();
            computerModelLabel = new Label();
            label2 = new Label();
            serialNumberLabel = new Label();
            ipAddressLabel = new Label();
            label4 = new Label();
            label3 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel7 = new Panel();
            label1 = new Label();
            label6 = new Label();
            lastRestartLabel = new Label();
            panel6 = new Panel();
            panel8 = new Panel();
            label7 = new Label();
            loggedInUserLabel = new Label();
            panel9 = new Panel();
            panel10 = new Panel();
            label8 = new Label();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel9.SuspendLayout();
            SuspendLayout();
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipText = "System Info";
            notifyIcon1.BalloonTipTitle = "System Info";
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "System Info";
            notifyIcon1.Visible = true;
            // 
            // refreshButton
            // 
            refreshButton.BackColor = Color.Cornsilk;
            refreshButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            refreshButton.Location = new Point(8, 372);
            refreshButton.Margin = new Padding(4, 3, 4, 3);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(117, 40);
            refreshButton.TabIndex = 14;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = false;
            refreshButton.Click += button1_Click;
            // 
            // exitButton
            // 
            exitButton.BackColor = Color.Cornsilk;
            exitButton.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exitButton.Location = new Point(243, 372);
            exitButton.Margin = new Padding(4, 3, 4, 3);
            exitButton.Name = "exitButton";
            exitButton.Size = new Size(117, 40);
            exitButton.TabIndex = 15;
            exitButton.Text = "Mer info";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += button2_Click;
            // 
            // hostNameLabel
            // 
            hostNameLabel.BackColor = Color.Transparent;
            hostNameLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            hostNameLabel.Location = new Point(181, 211);
            hostNameLabel.Margin = new Padding(4, 0, 4, 0);
            hostNameLabel.Name = "hostNameLabel";
            hostNameLabel.Size = new Size(181, 20);
            hostNameLabel.TabIndex = 9;
            hostNameLabel.Text = "N/A";
            hostNameLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // connectivityLabel
            // 
            connectivityLabel.BackColor = Color.Transparent;
            connectivityLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            connectivityLabel.Location = new Point(181, 237);
            connectivityLabel.Margin = new Padding(4, 0, 4, 0);
            connectivityLabel.Name = "connectivityLabel";
            connectivityLabel.Size = new Size(181, 20);
            connectivityLabel.TabIndex = 10;
            connectivityLabel.Text = "N/A";
            connectivityLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 285);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(155, 20);
            label5.TabIndex = 7;
            label5.Text = "Serial Number:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // computerModelLabel
            // 
            computerModelLabel.BackColor = Color.Transparent;
            computerModelLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            computerModelLabel.Location = new Point(181, 261);
            computerModelLabel.Margin = new Padding(4, 0, 4, 0);
            computerModelLabel.Name = "computerModelLabel";
            computerModelLabel.Size = new Size(181, 20);
            computerModelLabel.TabIndex = 11;
            computerModelLabel.Text = "N/A";
            computerModelLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(13, 211);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(155, 20);
            label2.TabIndex = 4;
            label2.Text = "Host Name:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // serialNumberLabel
            // 
            serialNumberLabel.BackColor = Color.Transparent;
            serialNumberLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            serialNumberLabel.Location = new Point(181, 286);
            serialNumberLabel.Margin = new Padding(4, 0, 4, 0);
            serialNumberLabel.Name = "serialNumberLabel";
            serialNumberLabel.Size = new Size(181, 20);
            serialNumberLabel.TabIndex = 12;
            serialNumberLabel.Text = "N/A";
            serialNumberLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ipAddressLabel
            // 
            ipAddressLabel.BackColor = Color.Transparent;
            ipAddressLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ipAddressLabel.Location = new Point(181, 187);
            ipAddressLabel.Margin = new Padding(4, 0, 4, 0);
            ipAddressLabel.Name = "ipAddressLabel";
            ipAddressLabel.Size = new Size(181, 20);
            ipAddressLabel.TabIndex = 8;
            ipAddressLabel.Text = "N/A";
            ipAddressLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(13, 237);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(155, 20);
            label4.TabIndex = 5;
            label4.Text = "Wi-fi / Lan:";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(10, 261);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(155, 20);
            label3.TabIndex = 6;
            label3.Text = "Computer Model:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gold;
            panel1.Location = new Point(7, 207);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(355, 1);
            panel1.TabIndex = 17;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gold;
            panel2.Location = new Point(7, 233);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(355, 1);
            panel2.TabIndex = 18;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Gold;
            panel3.Location = new Point(7, 256);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(355, 1);
            panel3.TabIndex = 19;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Gold;
            panel4.Location = new Point(7, 282);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new Size(355, 1);
            panel4.TabIndex = 20;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Gold;
            panel5.Controls.Add(panel7);
            panel5.Location = new Point(7, 306);
            panel5.Margin = new Padding(0);
            panel5.Name = "panel5";
            panel5.Size = new Size(355, 1);
            panel5.TabIndex = 21;
            // 
            // panel7
            // 
            panel7.BackColor = Color.Gold;
            panel7.Location = new Point(0, 40);
            panel7.Margin = new Padding(0);
            panel7.Name = "panel7";
            panel7.Size = new Size(420, 1);
            panel7.TabIndex = 22;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 187);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(155, 20);
            label1.TabIndex = 3;
            label1.Text = "IP-Adress:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 309);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(155, 20);
            label6.TabIndex = 22;
            label6.Text = "Senaste omstart:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lastRestartLabel
            // 
            lastRestartLabel.BackColor = Color.Transparent;
            lastRestartLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lastRestartLabel.Location = new Point(181, 310);
            lastRestartLabel.Margin = new Padding(4, 0, 4, 0);
            lastRestartLabel.Name = "lastRestartLabel";
            lastRestartLabel.Size = new Size(181, 18);
            lastRestartLabel.TabIndex = 23;
            lastRestartLabel.Text = "N/A";
            lastRestartLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Gold;
            panel6.Controls.Add(panel8);
            panel6.Location = new Point(7, 331);
            panel6.Margin = new Padding(0);
            panel6.Name = "panel6";
            panel6.Size = new Size(355, 1);
            panel6.TabIndex = 21;
            // 
            // panel8
            // 
            panel8.BackColor = Color.Gold;
            panel8.Location = new Point(0, 23);
            panel8.Margin = new Padding(0);
            panel8.Name = "panel8";
            panel8.Size = new Size(420, 12);
            panel8.TabIndex = 22;
            // 
            // label7
            // 
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(12, 335);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(155, 20);
            label7.TabIndex = 24;
            label7.Text = "Inloggad användare:";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // loggedInUserLabel
            // 
            loggedInUserLabel.BackColor = Color.Transparent;
            loggedInUserLabel.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loggedInUserLabel.Location = new Point(181, 336);
            loggedInUserLabel.Margin = new Padding(4, 0, 4, 0);
            loggedInUserLabel.Name = "loggedInUserLabel";
            loggedInUserLabel.Size = new Size(181, 20);
            loggedInUserLabel.TabIndex = 25;
            loggedInUserLabel.Text = "N/A";
            loggedInUserLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel9
            // 
            panel9.BackColor = Color.Gold;
            panel9.Controls.Add(panel10);
            panel9.Location = new Point(7, 355);
            panel9.Margin = new Padding(0);
            panel9.Name = "panel9";
            panel9.Size = new Size(355, 1);
            panel9.TabIndex = 23;
            // 
            // panel10
            // 
            panel10.BackColor = Color.Gold;
            panel10.Location = new Point(0, 23);
            panel10.Margin = new Padding(0);
            panel10.Name = "panel10";
            panel10.Size = new Size(420, 12);
            panel10.TabIndex = 22;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Microsoft Sans Serif", 2.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(253, 158, 0);
            label8.Location = new Point(216, 41);
            label8.Margin = new Padding(0);
            label8.Name = "label8";
            label8.Size = new Size(4, 4);
            label8.TabIndex = 23;
            label8.Text = "+";
            // 
            // Form1
            // 
            AccessibleRole = AccessibleRole.Application;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(216, 121, 39);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Center;
            ClientSize = new Size(371, 421);
            Controls.Add(label8);
            Controls.Add(panel9);
            Controls.Add(label7);
            Controls.Add(loggedInUserLabel);
            Controls.Add(panel6);
            Controls.Add(label6);
            Controls.Add(lastRestartLabel);
            Controls.Add(label1);
            Controls.Add(exitButton);
            Controls.Add(panel5);
            Controls.Add(refreshButton);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(hostNameLabel);
            Controls.Add(panel1);
            Controls.Add(connectivityLabel);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(computerModelLabel);
            Controls.Add(ipAddressLabel);
            Controls.Add(serialNumberLabel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "System Information";
            Load += Form1_Load;
            panel5.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel9.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label hostNameLabel;
        private System.Windows.Forms.Label connectivityLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label computerModelLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label serialNumberLabel;
        private System.Windows.Forms.Label ipAddressLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lastRestartLabel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label loggedInUserLabel;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label8;
    }
}
