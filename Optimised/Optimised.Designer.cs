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
            iTalk.ControlRenderer controlRenderer6 = new iTalk.ControlRenderer();
            iTalk.MSColorTable msColorTable6 = new iTalk.MSColorTable();
            this.GetApiData = new System.ComponentModel.BackgroundWorker();
            this.Optimised_Only = new System.ComponentModel.BackgroundWorker();
            this.Optimised_All = new System.ComponentModel.BackgroundWorker();
            this.ClearRam = new System.Windows.Forms.Timer(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Optimised_Manual = new System.ComponentModel.BackgroundWorker();
            this.opensite = new System.ComponentModel.BackgroundWorker();
            this.optionstart = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.iTalk_CheckBox2 = new iTalk.iTalk_CheckBox();
            this.iTalk_CheckBox1 = new iTalk.iTalk_CheckBox();
            this.iTalk_HeaderLabel2 = new iTalk.iTalk_HeaderLabel();
            this.iTalk_HeaderLabel1 = new iTalk.iTalk_HeaderLabel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.iTalk_Separator1 = new iTalk.iTalk_Separator();
            this.iTalk_HeaderLabel40 = new iTalk.iTalk_HeaderLabel();
            this.iTalk_Separator5 = new iTalk.iTalk_Separator();
            this.iTalk_Separator4 = new iTalk.iTalk_Separator();
            this.iTalk_Separator3 = new iTalk.iTalk_Separator();
            this.iTalk_Separator2 = new iTalk.iTalk_Separator();
            this.iTalk_HeaderLabel46 = new iTalk.iTalk_HeaderLabel();
            this.iTalk_HeaderLabel47 = new iTalk.iTalk_HeaderLabel();
            this.iTalk_HeaderLabel45 = new iTalk.iTalk_HeaderLabel();
            this.iTalk_HeaderLabel44 = new iTalk.iTalk_HeaderLabel();
            this.iTalk_HeaderLabel43 = new iTalk.iTalk_HeaderLabel();
            this.iTalk_HeaderLabel41 = new iTalk.iTalk_HeaderLabel();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.iTalk_ContextMenuStrip1 = new iTalk.iTalk_ContextMenuStrip();
            this.showToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iTalk_ControlBox1 = new iTalk.iTalk_ControlBox();
            this.iTalk_ThemeContainer1.SuspendLayout();
            this.iTalk_TabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.iTalk_GroupBox1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            this.iTalk_ContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GetApiData
            // 
            this.GetApiData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GetApiData_DoWork);
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
            // opensite
            // 
            this.opensite.WorkerReportsProgress = true;
            this.opensite.DoWork += new System.ComponentModel.DoWorkEventHandler(this.opensite_DoWork);
            // 
            // optionstart
            // 
            this.optionstart.WorkerReportsProgress = true;
            this.optionstart.DoWork += new System.ComponentModel.DoWorkEventHandler(this.optionstart_DoWork);
            // 
            // iTalk_ThemeContainer1
            // 
            this.iTalk_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_ControlBox1);
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
            this.iTalk_TabControl1.Controls.Add(this.tabPage5);
            this.iTalk_TabControl1.Controls.Add(this.tabPage6);
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
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage5.Controls.Add(this.iTalk_CheckBox2);
            this.tabPage5.Controls.Add(this.iTalk_CheckBox1);
            this.tabPage5.Controls.Add(this.iTalk_HeaderLabel2);
            this.tabPage5.Controls.Add(this.iTalk_HeaderLabel1);
            this.tabPage5.Location = new System.Drawing.Point(139, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(841, 557);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Setting";
            // 
            // iTalk_CheckBox2
            // 
            this.iTalk_CheckBox2.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_CheckBox2.Checked = false;
            this.iTalk_CheckBox2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iTalk_CheckBox2.Location = new System.Drawing.Point(190, 28);
            this.iTalk_CheckBox2.Name = "iTalk_CheckBox2";
            this.iTalk_CheckBox2.Size = new System.Drawing.Size(81, 15);
            this.iTalk_CheckBox2.TabIndex = 6;
            this.iTalk_CheckBox2.Text = "ON/OFF";
            this.iTalk_CheckBox2.CheckedChanged += new iTalk.iTalk_CheckBox.CheckedChangedEventHandler(this.iTalk_CheckBox2_CheckedChanged);
            // 
            // iTalk_CheckBox1
            // 
            this.iTalk_CheckBox1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_CheckBox1.Checked = false;
            this.iTalk_CheckBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iTalk_CheckBox1.Location = new System.Drawing.Point(98, 58);
            this.iTalk_CheckBox1.Name = "iTalk_CheckBox1";
            this.iTalk_CheckBox1.Size = new System.Drawing.Size(120, 15);
            this.iTalk_CheckBox1.TabIndex = 5;
            this.iTalk_CheckBox1.Text = "ON/OFF";
            this.iTalk_CheckBox1.CheckedChanged += new iTalk.iTalk_CheckBox.CheckedChangedEventHandler(this.iTalk_CheckBox1_CheckedChanged);
            // 
            // iTalk_HeaderLabel2
            // 
            this.iTalk_HeaderLabel2.AutoSize = true;
            this.iTalk_HeaderLabel2.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_HeaderLabel2.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.iTalk_HeaderLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iTalk_HeaderLabel2.Location = new System.Drawing.Point(6, 47);
            this.iTalk_HeaderLabel2.Name = "iTalk_HeaderLabel2";
            this.iTalk_HeaderLabel2.Size = new System.Drawing.Size(85, 28);
            this.iTalk_HeaderLabel2.TabIndex = 4;
            this.iTalk_HeaderLabel2.Text = "Startup :";
            // 
            // iTalk_HeaderLabel1
            // 
            this.iTalk_HeaderLabel1.AutoSize = true;
            this.iTalk_HeaderLabel1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_HeaderLabel1.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.iTalk_HeaderLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iTalk_HeaderLabel1.Location = new System.Drawing.Point(6, 16);
            this.iTalk_HeaderLabel1.Name = "iTalk_HeaderLabel1";
            this.iTalk_HeaderLabel1.Size = new System.Drawing.Size(178, 28);
            this.iTalk_HeaderLabel1.TabIndex = 1;
            this.iTalk_HeaderLabel1.Text = "Auto Login sistem :";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage6.Controls.Add(this.iTalk_Separator1);
            this.tabPage6.Controls.Add(this.iTalk_HeaderLabel40);
            this.tabPage6.Controls.Add(this.iTalk_Separator5);
            this.tabPage6.Controls.Add(this.iTalk_Separator4);
            this.tabPage6.Controls.Add(this.iTalk_Separator3);
            this.tabPage6.Controls.Add(this.iTalk_Separator2);
            this.tabPage6.Controls.Add(this.iTalk_HeaderLabel46);
            this.tabPage6.Controls.Add(this.iTalk_HeaderLabel47);
            this.tabPage6.Controls.Add(this.iTalk_HeaderLabel45);
            this.tabPage6.Controls.Add(this.iTalk_HeaderLabel44);
            this.tabPage6.Controls.Add(this.iTalk_HeaderLabel43);
            this.tabPage6.Controls.Add(this.iTalk_HeaderLabel41);
            this.tabPage6.Controls.Add(this.pictureBox15);
            this.tabPage6.Location = new System.Drawing.Point(139, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(841, 557);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "About";
            // 
            // iTalk_Separator1
            // 
            this.iTalk_Separator1.Location = new System.Drawing.Point(19, 49);
            this.iTalk_Separator1.Name = "iTalk_Separator1";
            this.iTalk_Separator1.Size = new System.Drawing.Size(816, 13);
            this.iTalk_Separator1.TabIndex = 27;
            this.iTalk_Separator1.Text = "iTalk_Separator1";
            // 
            // iTalk_HeaderLabel40
            // 
            this.iTalk_HeaderLabel40.AutoSize = true;
            this.iTalk_HeaderLabel40.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_HeaderLabel40.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.iTalk_HeaderLabel40.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iTalk_HeaderLabel40.Location = new System.Drawing.Point(11, 0);
            this.iTalk_HeaderLabel40.Name = "iTalk_HeaderLabel40";
            this.iTalk_HeaderLabel40.Size = new System.Drawing.Size(478, 46);
            this.iTalk_HeaderLabel40.TabIndex = 26;
            this.iTalk_HeaderLabel40.Text = "Realizator: Eremia Mihai Daniel";
            // 
            // iTalk_Separator5
            // 
            this.iTalk_Separator5.Location = new System.Drawing.Point(19, 384);
            this.iTalk_Separator5.Name = "iTalk_Separator5";
            this.iTalk_Separator5.Size = new System.Drawing.Size(820, 13);
            this.iTalk_Separator5.TabIndex = 25;
            this.iTalk_Separator5.Text = "iTalk_Separator5";
            // 
            // iTalk_Separator4
            // 
            this.iTalk_Separator4.Location = new System.Drawing.Point(19, 290);
            this.iTalk_Separator4.Name = "iTalk_Separator4";
            this.iTalk_Separator4.Size = new System.Drawing.Size(816, 13);
            this.iTalk_Separator4.TabIndex = 24;
            this.iTalk_Separator4.Text = "iTalk_Separator4";
            // 
            // iTalk_Separator3
            // 
            this.iTalk_Separator3.Location = new System.Drawing.Point(19, 198);
            this.iTalk_Separator3.Name = "iTalk_Separator3";
            this.iTalk_Separator3.Size = new System.Drawing.Size(841, 13);
            this.iTalk_Separator3.TabIndex = 23;
            this.iTalk_Separator3.Text = "iTalk_Separator3";
            // 
            // iTalk_Separator2
            // 
            this.iTalk_Separator2.Location = new System.Drawing.Point(19, 124);
            this.iTalk_Separator2.Name = "iTalk_Separator2";
            this.iTalk_Separator2.Size = new System.Drawing.Size(816, 13);
            this.iTalk_Separator2.TabIndex = 22;
            this.iTalk_Separator2.Text = "iTalk_Separator2";
            // 
            // iTalk_HeaderLabel46
            // 
            this.iTalk_HeaderLabel46.AutoSize = true;
            this.iTalk_HeaderLabel46.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_HeaderLabel46.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.iTalk_HeaderLabel46.Font = new System.Drawing.Font("Segoe UI", 24.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTalk_HeaderLabel46.ForeColor = System.Drawing.Color.SteelBlue;
            this.iTalk_HeaderLabel46.Location = new System.Drawing.Point(165, 336);
            this.iTalk_HeaderLabel46.Name = "iTalk_HeaderLabel46";
            this.iTalk_HeaderLabel46.Size = new System.Drawing.Size(581, 45);
            this.iTalk_HeaderLabel46.TabIndex = 21;
            this.iTalk_HeaderLabel46.Text = "https://liceulteoreticioncantacuzino.ro/";
            this.iTalk_HeaderLabel46.Click += new System.EventHandler(this.iTalk_HeaderLabel46_Click);
            // 
            // iTalk_HeaderLabel47
            // 
            this.iTalk_HeaderLabel47.AutoSize = true;
            this.iTalk_HeaderLabel47.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_HeaderLabel47.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.iTalk_HeaderLabel47.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iTalk_HeaderLabel47.Location = new System.Drawing.Point(11, 335);
            this.iTalk_HeaderLabel47.Name = "iTalk_HeaderLabel47";
            this.iTalk_HeaderLabel47.Size = new System.Drawing.Size(148, 46);
            this.iTalk_HeaderLabel47.TabIndex = 20;
            this.iTalk_HeaderLabel47.Text = "Website:";
            // 
            // iTalk_HeaderLabel45
            // 
            this.iTalk_HeaderLabel45.AutoSize = true;
            this.iTalk_HeaderLabel45.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_HeaderLabel45.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.iTalk_HeaderLabel45.Font = new System.Drawing.Font("Segoe UI", 24.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iTalk_HeaderLabel45.ForeColor = System.Drawing.Color.SteelBlue;
            this.iTalk_HeaderLabel45.Location = new System.Drawing.Point(165, 241);
            this.iTalk_HeaderLabel45.Name = "iTalk_HeaderLabel45";
            this.iTalk_HeaderLabel45.Size = new System.Drawing.Size(614, 45);
            this.iTalk_HeaderLabel45.TabIndex = 19;
            this.iTalk_HeaderLabel45.Text = "https://github.com/GooDRNK/Optimised";
            this.iTalk_HeaderLabel45.Click += new System.EventHandler(this.iTalk_HeaderLabel45_Click);
            // 
            // iTalk_HeaderLabel44
            // 
            this.iTalk_HeaderLabel44.AutoSize = true;
            this.iTalk_HeaderLabel44.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_HeaderLabel44.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.iTalk_HeaderLabel44.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iTalk_HeaderLabel44.Location = new System.Drawing.Point(11, 241);
            this.iTalk_HeaderLabel44.Name = "iTalk_HeaderLabel44";
            this.iTalk_HeaderLabel44.Size = new System.Drawing.Size(133, 46);
            this.iTalk_HeaderLabel44.TabIndex = 18;
            this.iTalk_HeaderLabel44.Text = "GitHub:";
            // 
            // iTalk_HeaderLabel43
            // 
            this.iTalk_HeaderLabel43.AutoSize = true;
            this.iTalk_HeaderLabel43.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_HeaderLabel43.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.iTalk_HeaderLabel43.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iTalk_HeaderLabel43.Location = new System.Drawing.Point(11, 149);
            this.iTalk_HeaderLabel43.Name = "iTalk_HeaderLabel43";
            this.iTalk_HeaderLabel43.Size = new System.Drawing.Size(393, 46);
            this.iTalk_HeaderLabel43.TabIndex = 17;
            this.iTalk_HeaderLabel43.Text = "Profesor: Enescu Cătalina";
            // 
            // iTalk_HeaderLabel41
            // 
            this.iTalk_HeaderLabel41.AutoSize = true;
            this.iTalk_HeaderLabel41.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_HeaderLabel41.Font = new System.Drawing.Font("Segoe UI", 25F);
            this.iTalk_HeaderLabel41.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.iTalk_HeaderLabel41.Location = new System.Drawing.Point(11, 75);
            this.iTalk_HeaderLabel41.Name = "iTalk_HeaderLabel41";
            this.iTalk_HeaderLabel41.Size = new System.Drawing.Size(668, 46);
            this.iTalk_HeaderLabel41.TabIndex = 16;
            this.iTalk_HeaderLabel41.Text = "Clasa: a X-a, Liceul Teoretic Ion Cantacuzino";
            // 
            // pictureBox15
            // 
            this.pictureBox15.Image = global::Optimised.Properties.Resources.lticlogo;
            this.pictureBox15.Location = new System.Drawing.Point(17, 403);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(816, 132);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox15.TabIndex = 15;
            this.pictureBox15.TabStop = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.iTalk_ContextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Optimised";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // iTalk_ContextMenuStrip1
            // 
            this.iTalk_ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem1,
            this.updateToolStripMenuItem1,
            this.logoutToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.iTalk_ContextMenuStrip1.Name = "iTalk_ContextMenuStrip1";
            controlRenderer6.ColorTable = msColorTable6;
            controlRenderer6.RoundedEdges = true;
            this.iTalk_ContextMenuStrip1.Renderer = controlRenderer6;
            this.iTalk_ContextMenuStrip1.Size = new System.Drawing.Size(113, 92);
            // 
            // showToolStripMenuItem1
            // 
            this.showToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.showToolStripMenuItem1.Image = global::Optimised.Properties.Resources.home_icon_32;
            this.showToolStripMenuItem1.Name = "showToolStripMenuItem1";
            this.showToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.showToolStripMenuItem1.Text = "Show";
            this.showToolStripMenuItem1.Click += new System.EventHandler(this.showToolStripMenuItem1_Click);
            // 
            // updateToolStripMenuItem1
            // 
            this.updateToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.updateToolStripMenuItem1.Image = global::Optimised.Properties.Resources.wrench_plus_icon_32;
            this.updateToolStripMenuItem1.Name = "updateToolStripMenuItem1";
            this.updateToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.updateToolStripMenuItem1.Text = "Update";
            this.updateToolStripMenuItem1.Click += new System.EventHandler(this.updateToolStripMenuItem1_Click);
            // 
            // logoutToolStripMenuItem1
            // 
            this.logoutToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.logoutToolStripMenuItem1.Image = global::Optimised.Properties.Resources.undo_icon_32;
            this.logoutToolStripMenuItem1.Name = "logoutToolStripMenuItem1";
            this.logoutToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem1.Text = "Logout";
            this.logoutToolStripMenuItem1.Click += new System.EventHandler(this.logoutToolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.exitToolStripMenuItem1.Image = global::Optimised.Properties.Resources.on_off_icon_32;
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // iTalk_ControlBox1
            // 
            this.iTalk_ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iTalk_ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_ControlBox1.Location = new System.Drawing.Point(901, 3);
            this.iTalk_ControlBox1.Name = "iTalk_ControlBox1";
            this.iTalk_ControlBox1.Size = new System.Drawing.Size(77, 19);
            this.iTalk_ControlBox1.TabIndex = 3;
            this.iTalk_ControlBox1.Text = "iTalk_ControlBox1";
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
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Optimised";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Optimised_FormClosing);
            this.Load += new System.EventHandler(this.Optimised_Load);
            this.Resize += new System.EventHandler(this.Optimised_Resize);
            this.iTalk_ThemeContainer1.ResumeLayout(false);
            this.iTalk_TabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.iTalk_GroupBox1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            this.iTalk_ContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private iTalk.iTalk_ThemeContainer iTalk_ThemeContainer1;
        private System.ComponentModel.BackgroundWorker GetApiData;
        private System.ComponentModel.BackgroundWorker Optimised_Only;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.ComponentModel.BackgroundWorker Optimised_All;
        private System.Windows.Forms.Timer ClearRam;
        private iTalk.iTalk_TabControl iTalk_TabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private iTalk.iTalk_ContextMenuStrip iTalk_ContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
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
        private iTalk.iTalk_HeaderLabel iTalk_HeaderLabel1;
        private iTalk.iTalk_CheckBox iTalk_CheckBox1;
        private iTalk.iTalk_HeaderLabel iTalk_HeaderLabel2;
        private iTalk.iTalk_CheckBox iTalk_CheckBox2;
        private iTalk.iTalk_Separator iTalk_Separator1;
        private iTalk.iTalk_HeaderLabel iTalk_HeaderLabel40;
        private iTalk.iTalk_Separator iTalk_Separator5;
        private iTalk.iTalk_Separator iTalk_Separator4;
        private iTalk.iTalk_Separator iTalk_Separator3;
        private iTalk.iTalk_Separator iTalk_Separator2;
        private iTalk.iTalk_HeaderLabel iTalk_HeaderLabel46;
        private iTalk.iTalk_HeaderLabel iTalk_HeaderLabel47;
        private iTalk.iTalk_HeaderLabel iTalk_HeaderLabel45;
        private iTalk.iTalk_HeaderLabel iTalk_HeaderLabel44;
        private iTalk.iTalk_HeaderLabel iTalk_HeaderLabel43;
        private iTalk.iTalk_HeaderLabel iTalk_HeaderLabel41;
        private System.Windows.Forms.PictureBox pictureBox15;
        internal System.ComponentModel.BackgroundWorker opensite;
        internal System.ComponentModel.BackgroundWorker optionstart;
        private System.Windows.Forms.Timer timer1;
        private iTalk.iTalk_ControlBox iTalk_ControlBox1;
    }
}