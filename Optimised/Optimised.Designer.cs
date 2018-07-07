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
            this.Optimised_Manual = new System.ComponentModel.BackgroundWorker();
            this.OpenWebsite = new System.ComponentModel.BackgroundWorker();
            this.optionstart = new System.ComponentModel.BackgroundWorker();
            this.SendInfo = new System.Windows.Forms.Timer(this.components);
            this.Online = new System.ComponentModel.BackgroundWorker();
            this.UpdateProces = new System.ComponentModel.BackgroundWorker();
            this.iTalk_ThemeContainer1 = new iTalk.iTalk_ThemeContainer();
            this.iTalk_TabControl1 = new iTalk.iTalk_TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.fixlnk = new iTalk.iTalk_CheckBox();
            this.iTalk_GroupBox1 = new iTalk.iTalk_GroupBox();
            this.iTalk_Button_12 = new iTalk.iTalk_Button_1();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.iTalk_Button_11 = new iTalk.iTalk_Button_1();
            this.mpoint = new iTalk.iTalk_CheckBox();
            this.rebin = new iTalk.iTalk_CheckBox();
            this.compstore = new iTalk.iTalk_CheckBox();
            this.useras = new iTalk.iTalk_CheckBox();
            this.trac = new iTalk.iTalk_CheckBox();
            this.pref = new iTalk.iTalk_CheckBox();
            this.temp = new iTalk.iTalk_CheckBox();
            this.rapp = new iTalk.iTalk_CheckBox();
            this.rstart = new iTalk.iTalk_CheckBox();
            this.wlogs = new iTalk.iTalk_CheckBox();
            this.rfile = new iTalk.iTalk_CheckBox();
            this.muic = new iTalk.iTalk_CheckBox();
            this.iTalk_ProgressBar1 = new iTalk.iTalk_ProgressBar();
            this.Notificare = new System.Windows.Forms.NotifyIcon(this.components);
            this.TrayMeniu = new iTalk.iTalk_ContextMenuStrip();
            this.CloseProces = new System.ComponentModel.BackgroundWorker();
            this.iTalk_ThemeContainer1.SuspendLayout();
            this.iTalk_TabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.iTalk_GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Optimised_Only
            // 
            this.Optimised_Only.WorkerReportsProgress = true;
            this.Optimised_Only.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Optimised_Only_DoWork);
            this.Optimised_Only.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Optimised_Only_ProgressChanged);
            // 
            // Optimised_All
            // 
            this.Optimised_All.WorkerReportsProgress = true;
            this.Optimised_All.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Optimised_All_DoWork);
            this.Optimised_All.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Optimised_All_ProgressChanged);
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
            // Optimised_Manual
            // 
            this.Optimised_Manual.WorkerReportsProgress = true;
            this.Optimised_Manual.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Optimised_Manual_DoWork);
            this.Optimised_Manual.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Optimised_Manual_ProgressChanged);
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
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_TabControl1);
            this.iTalk_ThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTalk_ThemeContainer1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.iTalk_ThemeContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_ThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.iTalk_ThemeContainer1.Name = "iTalk_ThemeContainer1";
            this.iTalk_ThemeContainer1.Padding = new System.Windows.Forms.Padding(3, 28, 3, 28);
            this.iTalk_ThemeContainer1.Sizable = false;
            this.iTalk_ThemeContainer1.Size = new System.Drawing.Size(984, 611);
            this.iTalk_ThemeContainer1.SmartBounds = false;
            this.iTalk_ThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.iTalk_ThemeContainer1.TabIndex = 0;
            this.iTalk_ThemeContainer1.Text = "Optimised";
            // 
            // iTalk_TabControl1
            // 
            this.iTalk_TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.iTalk_TabControl1.Controls.Add(this.tabPage1);
            this.iTalk_TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.iTalk_TabControl1.Font = new System.Drawing.Font("Sitka Banner", 9F);
            this.iTalk_TabControl1.ItemSize = new System.Drawing.Size(44, 135);
            this.iTalk_TabControl1.Location = new System.Drawing.Point(0, 24);
            this.iTalk_TabControl1.Multiline = true;
            this.iTalk_TabControl1.Name = "iTalk_TabControl1";
            this.iTalk_TabControl1.SelectedIndex = 0;
            this.iTalk_TabControl1.Size = new System.Drawing.Size(984, 565);
            this.iTalk_TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.iTalk_TabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage1.Controls.Add(this.fixlnk);
            this.tabPage1.Controls.Add(this.iTalk_GroupBox1);
            this.tabPage1.Controls.Add(this.iTalk_Button_11);
            this.tabPage1.Controls.Add(this.mpoint);
            this.tabPage1.Controls.Add(this.rebin);
            this.tabPage1.Controls.Add(this.compstore);
            this.tabPage1.Controls.Add(this.useras);
            this.tabPage1.Controls.Add(this.trac);
            this.tabPage1.Controls.Add(this.pref);
            this.tabPage1.Controls.Add(this.temp);
            this.tabPage1.Controls.Add(this.rapp);
            this.tabPage1.Controls.Add(this.rstart);
            this.tabPage1.Controls.Add(this.wlogs);
            this.tabPage1.Controls.Add(this.rfile);
            this.tabPage1.Controls.Add(this.muic);
            this.tabPage1.Controls.Add(this.iTalk_ProgressBar1);
            this.tabPage1.Location = new System.Drawing.Point(139, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(841, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Optimised";
            // 
            // fixlnk
            // 
            this.fixlnk.BackColor = System.Drawing.Color.Transparent;
            this.fixlnk.Checked = false;
            this.fixlnk.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.fixlnk.Location = new System.Drawing.Point(473, 460);
            this.fixlnk.Name = "fixlnk";
            this.fixlnk.Size = new System.Drawing.Size(110, 15);
            this.fixlnk.TabIndex = 17;
            this.fixlnk.Text = "Fix Shortcut";
            // 
            // iTalk_GroupBox1
            // 
            this.iTalk_GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_GroupBox1.Controls.Add(this.iTalk_Button_12);
            this.iTalk_GroupBox1.Controls.Add(this.listBox1);
            this.iTalk_GroupBox1.Font = new System.Drawing.Font("Sitka Banner", 10F);
            this.iTalk_GroupBox1.Location = new System.Drawing.Point(399, 7);
            this.iTalk_GroupBox1.MinimumSize = new System.Drawing.Size(136, 50);
            this.iTalk_GroupBox1.Name = "iTalk_GroupBox1";
            this.iTalk_GroupBox1.Padding = new System.Windows.Forms.Padding(5, 28, 5, 5);
            this.iTalk_GroupBox1.Size = new System.Drawing.Size(433, 447);
            this.iTalk_GroupBox1.TabIndex = 16;
            this.iTalk_GroupBox1.Text = "Last Log Optimised";
            // 
            // iTalk_Button_12
            // 
            this.iTalk_Button_12.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_12.Font = new System.Drawing.Font("Sitka Banner", 13.5F);
            this.iTalk_Button_12.Image = null;
            this.iTalk_Button_12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iTalk_Button_12.Location = new System.Drawing.Point(382, 14);
            this.iTalk_Button_12.Name = "iTalk_Button_12";
            this.iTalk_Button_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.iTalk_Button_12.Size = new System.Drawing.Size(39, 17);
            this.iTalk_Button_12.TabIndex = 18;
            this.iTalk_Button_12.Text = "Save";
            this.iTalk_Button_12.TextAlignment = System.Drawing.StringAlignment.Far;
            this.iTalk_Button_12.Click += new System.EventHandler(this.iTalk_Button_12_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(12, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(409, 404);
            this.listBox1.TabIndex = 0;
            // 
            // iTalk_Button_11
            // 
            this.iTalk_Button_11.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_11.Font = new System.Drawing.Font("Sitka Banner", 14F);
            this.iTalk_Button_11.Image = global::Optimised.Properties.Resources.wrench_plus_icon_32;
            this.iTalk_Button_11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iTalk_Button_11.Location = new System.Drawing.Point(118, 406);
            this.iTalk_Button_11.Name = "iTalk_Button_11";
            this.iTalk_Button_11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.iTalk_Button_11.Size = new System.Drawing.Size(166, 40);
            this.iTalk_Button_11.TabIndex = 14;
            this.iTalk_Button_11.Text = "Run Optimised";
            this.iTalk_Button_11.TextAlignment = System.Drawing.StringAlignment.Far;
            this.iTalk_Button_11.Click += new System.EventHandler(this.iTalk_Button_11_Click);
            // 
            // mpoint
            // 
            this.mpoint.BackColor = System.Drawing.Color.Transparent;
            this.mpoint.Checked = false;
            this.mpoint.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.mpoint.Location = new System.Drawing.Point(712, 460);
            this.mpoint.Name = "mpoint";
            this.mpoint.Size = new System.Drawing.Size(108, 15);
            this.mpoint.TabIndex = 13;
            this.mpoint.Text = "MountPoints";
            // 
            // rebin
            // 
            this.rebin.BackColor = System.Drawing.Color.Transparent;
            this.rebin.Checked = false;
            this.rebin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rebin.Location = new System.Drawing.Point(99, 511);
            this.rebin.Name = "rebin";
            this.rebin.Size = new System.Drawing.Size(131, 15);
            this.rebin.TabIndex = 12;
            this.rebin.Text = "Empty Recycle Bin";
            // 
            // compstore
            // 
            this.compstore.BackColor = System.Drawing.Color.Transparent;
            this.compstore.Checked = false;
            this.compstore.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.compstore.Location = new System.Drawing.Point(336, 460);
            this.compstore.Name = "compstore";
            this.compstore.Size = new System.Drawing.Size(131, 15);
            this.compstore.TabIndex = 11;
            this.compstore.Text = "Compatibility Store";
            // 
            // useras
            // 
            this.useras.BackColor = System.Drawing.Color.Transparent;
            this.useras.Checked = false;
            this.useras.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.useras.Location = new System.Drawing.Point(236, 511);
            this.useras.Name = "useras";
            this.useras.Size = new System.Drawing.Size(94, 15);
            this.useras.TabIndex = 10;
            this.useras.Text = "UserAssist";
            // 
            // trac
            // 
            this.trac.BackColor = System.Drawing.Color.Transparent;
            this.trac.Checked = false;
            this.trac.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.trac.Location = new System.Drawing.Point(583, 511);
            this.trac.Name = "trac";
            this.trac.Size = new System.Drawing.Size(87, 15);
            this.trac.TabIndex = 9;
            this.trac.Text = "Tracing";
            // 
            // pref
            // 
            this.pref.BackColor = System.Drawing.Color.Transparent;
            this.pref.Checked = false;
            this.pref.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.pref.Location = new System.Drawing.Point(10, 511);
            this.pref.Name = "pref";
            this.pref.Size = new System.Drawing.Size(82, 15);
            this.pref.TabIndex = 8;
            this.pref.Text = "Prefetch";
            // 
            // temp
            // 
            this.temp.BackColor = System.Drawing.Color.Transparent;
            this.temp.Checked = false;
            this.temp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.temp.Location = new System.Drawing.Point(583, 460);
            this.temp.Name = "temp";
            this.temp.Size = new System.Drawing.Size(123, 15);
            this.temp.TabIndex = 7;
            this.temp.Text = "Temporary Files";
            // 
            // rapp
            // 
            this.rapp.BackColor = System.Drawing.Color.Transparent;
            this.rapp.Checked = false;
            this.rapp.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rapp.Location = new System.Drawing.Point(473, 511);
            this.rapp.Name = "rapp";
            this.rapp.Size = new System.Drawing.Size(104, 15);
            this.rapp.TabIndex = 6;
            this.rapp.Text = "Recent Apps";
            // 
            // rstart
            // 
            this.rstart.BackColor = System.Drawing.Color.Transparent;
            this.rstart.Checked = false;
            this.rstart.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rstart.Location = new System.Drawing.Point(336, 511);
            this.rstart.Name = "rstart";
            this.rstart.Size = new System.Drawing.Size(110, 15);
            this.rstart.TabIndex = 5;
            this.rstart.Text = "Run At Startup";
            // 
            // wlogs
            // 
            this.wlogs.BackColor = System.Drawing.Color.Transparent;
            this.wlogs.Checked = false;
            this.wlogs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.wlogs.Location = new System.Drawing.Point(99, 460);
            this.wlogs.Name = "wlogs";
            this.wlogs.Size = new System.Drawing.Size(116, 15);
            this.wlogs.TabIndex = 4;
            this.wlogs.Text = "Windows Logs";
            // 
            // rfile
            // 
            this.rfile.BackColor = System.Drawing.Color.Transparent;
            this.rfile.Checked = false;
            this.rfile.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rfile.Location = new System.Drawing.Point(236, 460);
            this.rfile.Name = "rfile";
            this.rfile.Size = new System.Drawing.Size(96, 15);
            this.rfile.TabIndex = 3;
            this.rfile.Text = "Recent Files";
            // 
            // muic
            // 
            this.muic.BackColor = System.Drawing.Color.Transparent;
            this.muic.Checked = false;
            this.muic.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.muic.Location = new System.Drawing.Point(10, 460);
            this.muic.Name = "muic";
            this.muic.Size = new System.Drawing.Size(96, 15);
            this.muic.TabIndex = 2;
            this.muic.Text = "MUI Cache";
            // 
            // iTalk_ProgressBar1
            // 
            this.iTalk_ProgressBar1.Font = new System.Drawing.Font("Segoe Print", 50.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTalk_ProgressBar1.ForeColor = System.Drawing.Color.Transparent;
            this.iTalk_ProgressBar1.Location = new System.Drawing.Point(-2, 7);
            this.iTalk_ProgressBar1.Maximum = ((long)(100));
            this.iTalk_ProgressBar1.MinimumSize = new System.Drawing.Size(100, 100);
            this.iTalk_ProgressBar1.Name = "iTalk_ProgressBar1";
            this.iTalk_ProgressBar1.ProgressColor1 = System.Drawing.Color.SteelBlue;
            this.iTalk_ProgressBar1.ProgressColor2 = System.Drawing.Color.Aqua;
            this.iTalk_ProgressBar1.ProgressShape = iTalk.iTalk_ProgressBar._ProgressShape.Round;
            this.iTalk_ProgressBar1.Size = new System.Drawing.Size(406, 406);
            this.iTalk_ProgressBar1.TabIndex = 0;
            this.iTalk_ProgressBar1.Text = "iTalk_ProgressBar1";
            this.iTalk_ProgressBar1.Value = ((long)(0));
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
            this.TrayMeniu.Name = "iTalk_ContextMenuStrip1";
            controlRenderer1.ColorTable = msColorTable1;
            controlRenderer1.RoundedEdges = true;
            this.TrayMeniu.Renderer = controlRenderer1;
            this.TrayMeniu.Size = new System.Drawing.Size(61, 4);
            // 
            // CloseProces
            // 
            this.CloseProces.DoWork += new System.ComponentModel.DoWorkEventHandler(this.closeproc_DoWork);
            // 
            // Optimised
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.iTalk_ThemeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "Optimised";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Optimised";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Optimised_FormClosing);
            this.Load += new System.EventHandler(this.Optimised_Load);
            this.iTalk_ThemeContainer1.ResumeLayout(false);
            this.iTalk_TabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.iTalk_GroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private iTalk.iTalk_ThemeContainer iTalk_ThemeContainer1;
        private System.ComponentModel.BackgroundWorker Optimised_Only;
        private System.Windows.Forms.NotifyIcon Notificare;
        private System.ComponentModel.BackgroundWorker Optimised_All;
        private System.Windows.Forms.Timer ClearRam;
        private iTalk.iTalk_TabControl iTalk_TabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private iTalk.iTalk_ContextMenuStrip TrayMeniu;
        private iTalk.iTalk_ProgressBar iTalk_ProgressBar1;
        private iTalk.iTalk_Button_1 iTalk_Button_11;
        private iTalk.iTalk_CheckBox mpoint;
        private iTalk.iTalk_CheckBox rebin;
        private iTalk.iTalk_CheckBox compstore;
        private iTalk.iTalk_CheckBox useras;
        private iTalk.iTalk_CheckBox trac;
        private iTalk.iTalk_CheckBox pref;
        private iTalk.iTalk_CheckBox temp;
        private iTalk.iTalk_CheckBox rapp;
        private iTalk.iTalk_CheckBox rstart;
        private iTalk.iTalk_CheckBox wlogs;
        private iTalk.iTalk_CheckBox rfile;
        private iTalk.iTalk_CheckBox muic;
        private iTalk.iTalk_GroupBox iTalk_GroupBox1;
        private iTalk.iTalk_CheckBox fixlnk;
        private System.Windows.Forms.ListBox listBox1;
        internal System.ComponentModel.BackgroundWorker Optimised_Manual;
        private iTalk.iTalk_Button_1 iTalk_Button_12;
        internal System.ComponentModel.BackgroundWorker OpenWebsite;
        internal System.ComponentModel.BackgroundWorker optionstart;
        private System.Windows.Forms.Timer SendInfo;
        private System.ComponentModel.BackgroundWorker Online;
        private System.ComponentModel.BackgroundWorker UpdateProces;
        private System.ComponentModel.BackgroundWorker CloseProces;
    }
}