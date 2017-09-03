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
            this.GetApiData = new System.ComponentModel.BackgroundWorker();
            this.Optimised_Only = new System.ComponentModel.BackgroundWorker();
            this.Optimised_All = new System.ComponentModel.BackgroundWorker();
            this.ClearRam = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iTalk_TabControl1 = new iTalk.iTalk_TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.iTalk_ThemeContainer1 = new iTalk.iTalk_ThemeContainer();
            this.iTalk_ControlBox1 = new iTalk.iTalk_ControlBox();
            this.iTalk_ContextMenuStrip1 = new iTalk.iTalk_ContextMenuStrip();
            this.showToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iTalk_TabControl1.SuspendLayout();
            this.iTalk_ThemeContainer1.SuspendLayout();
            this.iTalk_ContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // GetApiData
            // 
            this.GetApiData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.GetApiData_DoWork);
            // 
            // Optimised_Only
            // 
            this.Optimised_Only.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Optimised_Only_DoWork);
            // 
            // Optimised_All
            // 
            this.Optimised_All.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Optimised_All_DoWork);
            // 
            // ClearRam
            // 
            this.ClearRam.Tick += new System.EventHandler(this.ClearRam_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.iTalk_ContextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Optimised";
            this.notifyIcon1.Visible = true;
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
            // iTalk_TabControl1
            // 
            this.iTalk_TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.iTalk_TabControl1.Controls.Add(this.tabPage1);
            this.iTalk_TabControl1.Controls.Add(this.tabPage2);
            this.iTalk_TabControl1.Controls.Add(this.tabPage3);
            this.iTalk_TabControl1.Controls.Add(this.tabPage4);
            this.iTalk_TabControl1.Controls.Add(this.tabPage7);
            this.iTalk_TabControl1.Controls.Add(this.tabPage5);
            this.iTalk_TabControl1.Controls.Add(this.tabPage6);
            this.iTalk_TabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
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
            this.tabPage1.Location = new System.Drawing.Point(139, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(841, 557);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Optimised";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage2.Location = new System.Drawing.Point(139, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(841, 557);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "File Shredder";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage3.Location = new System.Drawing.Point(139, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(841, 557);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Disk Defrag";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage4.Location = new System.Drawing.Point(139, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(841, 557);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Duplicate Finder";
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage7.Location = new System.Drawing.Point(139, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(841, 557);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "PC Specs";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage5.Location = new System.Drawing.Point(139, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(841, 557);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Setting";
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.tabPage6.Location = new System.Drawing.Point(139, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(841, 557);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "About";
            // 
            // iTalk_ThemeContainer1
            // 
            this.iTalk_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_ControlBox1);
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
            // iTalk_ControlBox1
            // 
            this.iTalk_ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iTalk_ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_ControlBox1.Location = new System.Drawing.Point(903, -1);
            this.iTalk_ControlBox1.Name = "iTalk_ControlBox1";
            this.iTalk_ControlBox1.Size = new System.Drawing.Size(77, 19);
            this.iTalk_ControlBox1.TabIndex = 0;
            this.iTalk_ControlBox1.Text = "iTalk_ControlBox1";
            // 
            // iTalk_ContextMenuStrip1
            // 
            this.iTalk_ContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem1,
            this.updateToolStripMenuItem1,
            this.logoutToolStripMenuItem1,
            this.exitToolStripMenuItem1});
            this.iTalk_ContextMenuStrip1.Name = "iTalk_ContextMenuStrip1";
            controlRenderer1.ColorTable = msColorTable1;
            controlRenderer1.RoundedEdges = true;
            this.iTalk_ContextMenuStrip1.Renderer = controlRenderer1;
            this.iTalk_ContextMenuStrip1.Size = new System.Drawing.Size(113, 92);
            // 
            // showToolStripMenuItem1
            // 
            this.showToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.showToolStripMenuItem1.Name = "showToolStripMenuItem1";
            this.showToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.showToolStripMenuItem1.Text = "Show";
            // 
            // updateToolStripMenuItem1
            // 
            this.updateToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.updateToolStripMenuItem1.Name = "updateToolStripMenuItem1";
            this.updateToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.updateToolStripMenuItem1.Text = "Update";
            // 
            // logoutToolStripMenuItem1
            // 
            this.logoutToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.logoutToolStripMenuItem1.Name = "logoutToolStripMenuItem1";
            this.logoutToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem1.Text = "Logout";
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            // 
            // Optimised
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.iTalk_TabControl1);
            this.Controls.Add(this.iTalk_ThemeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "Optimised";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Optimised";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Optimised_FormClosing);
            this.iTalk_TabControl1.ResumeLayout(false);
            this.iTalk_ThemeContainer1.ResumeLayout(false);
            this.iTalk_ContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private iTalk.iTalk_ThemeContainer iTalk_ThemeContainer1;
        private iTalk.iTalk_ControlBox iTalk_ControlBox1;
        private System.ComponentModel.BackgroundWorker GetApiData;
        private System.ComponentModel.BackgroundWorker Optimised_Only;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.ComponentModel.BackgroundWorker Optimised_All;
        private System.Windows.Forms.Timer ClearRam;
        private iTalk.iTalk_TabControl iTalk_TabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage7;
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
    }
}