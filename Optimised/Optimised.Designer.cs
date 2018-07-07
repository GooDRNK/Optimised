namespace Optimised
{
    partial class Optimised
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Optimised));
            iTalk.ControlRenderer controlRenderer1 = new iTalk.ControlRenderer();
            iTalk.MSColorTable msColorTable1 = new iTalk.MSColorTable();
            this.Optimised_Only = new System.ComponentModel.BackgroundWorker();
            this.Optimised_All = new System.ComponentModel.BackgroundWorker();
            this.ClearRam = new System.Windows.Forms.Timer(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenWebsite = new System.ComponentModel.BackgroundWorker();
            this.optionstart = new System.ComponentModel.BackgroundWorker();
            this.SendInfo = new System.Windows.Forms.Timer(this.components);
            this.Online = new System.ComponentModel.BackgroundWorker();
            this.UpdateProces = new System.ComponentModel.BackgroundWorker();
            this.iTalk_ThemeContainer1 = new iTalk.iTalk_ThemeContainer();
            this.Notificare = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMeniu = new iTalk.iTalk_ContextMenuStrip();
            this.CloseProces = new System.ComponentModel.BackgroundWorker();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrayMeniu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Optimised_Only
            // 
            this.Optimised_Only.WorkerReportsProgress = true;
            this.Optimised_Only.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Optimised_Only_DoWork);
            // 
            // Optimised_All
            // 
            this.Optimised_All.WorkerReportsProgress = true;
            this.Optimised_All.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Optimised_All_DoWork);
            // 
            // ClearRam
            // 
            this.ClearRam.Tick += new System.EventHandler(this.ClearRam_Tick);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // OpenWebsite
            // 
            this.OpenWebsite.WorkerReportsProgress = true;
            this.OpenWebsite.DoWork += new System.ComponentModel.DoWorkEventHandler(this.opensite_DoWork);
            // 
            // optionstart
            // 
            this.optionstart.WorkerReportsProgress = true;
            this.optionstart.DoWork += new System.ComponentModel.DoWorkEventHandler(this.optionstart_DoWork);
            // 
            // SendInfo
            // 
            this.SendInfo.Tick += new System.EventHandler(this.SendInfo_Tick);
            // 
            // Online
            // 
            this.Online.DoWork += new System.ComponentModel.DoWorkEventHandler(this.sendonline_DoWork);
            // 
            // UpdateProces
            // 
            this.UpdateProces.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UpdateProces_DoWork);
            // 
            // iTalk_ThemeContainer1
            // 
            this.iTalk_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.iTalk_ThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTalk_ThemeContainer1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.iTalk_ThemeContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_ThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.iTalk_ThemeContainer1.Name = "iTalk_ThemeContainer1";
            this.iTalk_ThemeContainer1.Padding = new System.Windows.Forms.Padding(3, 28, 3, 28);
            this.iTalk_ThemeContainer1.Sizable = false;
            this.iTalk_ThemeContainer1.Size = new System.Drawing.Size(129, 102);
            this.iTalk_ThemeContainer1.SmartBounds = false;
            this.iTalk_ThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.iTalk_ThemeContainer1.TabIndex = 0;
            this.iTalk_ThemeContainer1.Text = "Optimised";
            // 
            // Notificare
            // 
            this.Notificare.ContextMenuStrip = this.TrayMeniu;
            this.Notificare.Icon = ((System.Drawing.Icon)(resources.GetObject("Notificare.Icon")));
            this.Notificare.Text = "Optimised";
            this.Notificare.Visible = true;
            // 
            // TrayMeniu
            // 
            this.TrayMeniu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportToolStripMenuItem});
            this.TrayMeniu.Name = "iTalk_ContextMenuStrip1";
            controlRenderer1.ColorTable = msColorTable1;
            controlRenderer1.RoundedEdges = true;
            this.TrayMeniu.Renderer = controlRenderer1;
            this.TrayMeniu.Size = new System.Drawing.Size(110, 26);
            // 
            // CloseProces
            // 
            this.CloseProces.DoWork += new System.ComponentModel.DoWorkEventHandler(this.closeproc_DoWork);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.reportToolStripMenuItem.Text = "Report";
            this.reportToolStripMenuItem.Click += new System.EventHandler(this.reportToolStripMenuItem_Click);
            // 
            // Optimised
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(129, 102);
            this.Controls.Add(this.iTalk_ThemeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "Optimised";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Optimised";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Optimised_FormClosing);
            this.Load += new System.EventHandler(this.Optimised_Load);
            this.TrayMeniu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private iTalk.iTalk_ThemeContainer iTalk_ThemeContainer1;
        private System.ComponentModel.BackgroundWorker Optimised_Only;
        private System.ComponentModel.BackgroundWorker Optimised_All;
        private System.Windows.Forms.Timer ClearRam;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private iTalk.iTalk_ContextMenuStrip TrayMeniu;
        internal System.ComponentModel.BackgroundWorker OpenWebsite;
        internal System.ComponentModel.BackgroundWorker optionstart;
        private System.Windows.Forms.Timer SendInfo;
        private System.ComponentModel.BackgroundWorker Online;
        private System.ComponentModel.BackgroundWorker UpdateProces;
        private System.ComponentModel.BackgroundWorker CloseProces;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        internal System.Windows.Forms.NotifyIcon Notificare;
    }
}