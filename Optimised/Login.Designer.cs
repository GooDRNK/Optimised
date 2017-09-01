namespace Optimised
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.clearGC = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iTalk_ThemeContainer1 = new iTalk.iTalk_ThemeContainer();
            this.iTalk_LinkLabel1 = new iTalk.iTalk_LinkLabel();
            this.iTalk_Label2 = new iTalk.iTalk_Label();
            this.iTalk_Toggle1 = new iTalk.iTalk_Toggle();
            this.iTalk_Label1 = new iTalk.iTalk_Label();
            this.iTalk_Button_21 = new iTalk.iTalk_Button_2();
            this.iTalk_TextBox_Big3 = new iTalk.iTalk_TextBox_Big();
            this.iTalk_TextBox_Big2 = new iTalk.iTalk_TextBox_Big();
            this.iTalk_TextBox_Big1 = new iTalk.iTalk_TextBox_Big();
            this.iTalk_ControlBox1 = new iTalk.iTalk_ControlBox();
            this.iTalk_ThemeContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "2x2_grid_icon&32.png");
            this.imageList1.Images.SetKeyName(1, "3x3_grid_2_icon&32.png");
            this.imageList1.Images.SetKeyName(2, "air_signal_icon&32.png");
            // 
            // clearGC
            // 
            this.clearGC.Tick += new System.EventHandler(this.clearGC_Tick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Optimised";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // iTalk_ThemeContainer1
            // 
            this.iTalk_ThemeContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(246)))), ((int)(((byte)(246)))));
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_LinkLabel1);
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_Label2);
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_Toggle1);
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_Label1);
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_Button_21);
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_TextBox_Big3);
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_TextBox_Big2);
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_TextBox_Big1);
            this.iTalk_ThemeContainer1.Controls.Add(this.iTalk_ControlBox1);
            this.iTalk_ThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iTalk_ThemeContainer1.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.iTalk_ThemeContainer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_ThemeContainer1.Location = new System.Drawing.Point(0, 0);
            this.iTalk_ThemeContainer1.Name = "iTalk_ThemeContainer1";
            this.iTalk_ThemeContainer1.Padding = new System.Windows.Forms.Padding(3, 28, 3, 28);
            this.iTalk_ThemeContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.iTalk_ThemeContainer1.Sizable = false;
            this.iTalk_ThemeContainer1.Size = new System.Drawing.Size(337, 329);
            this.iTalk_ThemeContainer1.SmartBounds = true;
            this.iTalk_ThemeContainer1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.iTalk_ThemeContainer1.TabIndex = 0;
            this.iTalk_ThemeContainer1.Text = "Optimised";
            // 
            // iTalk_LinkLabel1
            // 
            this.iTalk_LinkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(202)))));
            this.iTalk_LinkLabel1.AutoSize = true;
            this.iTalk_LinkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_LinkLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iTalk_LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.iTalk_LinkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(225)))));
            this.iTalk_LinkLabel1.Location = new System.Drawing.Point(162, 284);
            this.iTalk_LinkLabel1.Name = "iTalk_LinkLabel1";
            this.iTalk_LinkLabel1.Size = new System.Drawing.Size(55, 19);
            this.iTalk_LinkLabel1.TabIndex = 11;
            this.iTalk_LinkLabel1.TabStop = true;
            this.iTalk_LinkLabel1.Text = "register";
            this.iTalk_LinkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(101)))), ((int)(((byte)(202)))));
            this.iTalk_LinkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.iTalk_LinkLabel1_LinkClicked);
            // 
            // iTalk_Label2
            // 
            this.iTalk_Label2.AutoSize = true;
            this.iTalk_Label2.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iTalk_Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_Label2.Location = new System.Drawing.Point(138, 284);
            this.iTalk_Label2.Name = "iTalk_Label2";
            this.iTalk_Label2.Size = new System.Drawing.Size(22, 19);
            this.iTalk_Label2.TabIndex = 10;
            this.iTalk_Label2.Text = "or";
            // 
            // iTalk_Toggle1
            // 
            this.iTalk_Toggle1.Location = new System.Drawing.Point(99, 212);
            this.iTalk_Toggle1.Name = "iTalk_Toggle1";
            this.iTalk_Toggle1.Size = new System.Drawing.Size(41, 23);
            this.iTalk_Toggle1.TabIndex = 9;
            this.iTalk_Toggle1.Toggled = false;
            this.iTalk_Toggle1.Type = iTalk.iTalk_Toggle._Type.YesNo;
            // 
            // iTalk_Label1
            // 
            this.iTalk_Label1.AutoSize = true;
            this.iTalk_Label1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.iTalk_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(142)))), ((int)(((byte)(142)))));
            this.iTalk_Label1.Location = new System.Drawing.Point(12, 212);
            this.iTalk_Label1.Name = "iTalk_Label1";
            this.iTalk_Label1.Size = new System.Drawing.Size(81, 19);
            this.iTalk_Label1.TabIndex = 8;
            this.iTalk_Label1.Text = "Remember?";
            // 
            // iTalk_Button_21
            // 
            this.iTalk_Button_21.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_Button_21.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.iTalk_Button_21.ForeColor = System.Drawing.Color.White;
            this.iTalk_Button_21.Image = null;
            this.iTalk_Button_21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iTalk_Button_21.Location = new System.Drawing.Point(12, 240);
            this.iTalk_Button_21.Name = "iTalk_Button_21";
            this.iTalk_Button_21.Size = new System.Drawing.Size(313, 40);
            this.iTalk_Button_21.TabIndex = 7;
            this.iTalk_Button_21.Text = "Login";
            this.iTalk_Button_21.TextAlignment = System.Drawing.StringAlignment.Center;
            this.iTalk_Button_21.Click += new System.EventHandler(this.iTalk_Button_21_Click);
            // 
            // iTalk_TextBox_Big3
            // 
            this.iTalk_TextBox_Big3.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_TextBox_Big3.Font = new System.Drawing.Font("Tahoma", 11F);
            this.iTalk_TextBox_Big3.ForeColor = System.Drawing.Color.DimGray;
            this.iTalk_TextBox_Big3.Image = global::Optimised.Properties.Resources.key_icon_32;
            this.iTalk_TextBox_Big3.Location = new System.Drawing.Point(12, 158);
            this.iTalk_TextBox_Big3.MaxLength = 20;
            this.iTalk_TextBox_Big3.Multiline = false;
            this.iTalk_TextBox_Big3.Name = "iTalk_TextBox_Big3";
            this.iTalk_TextBox_Big3.ReadOnly = false;
            this.iTalk_TextBox_Big3.Size = new System.Drawing.Size(313, 41);
            this.iTalk_TextBox_Big3.TabIndex = 6;
            this.iTalk_TextBox_Big3.Text = "Password";
            this.iTalk_TextBox_Big3.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.iTalk_TextBox_Big3.UseSystemPasswordChar = true;
            // 
            // iTalk_TextBox_Big2
            // 
            this.iTalk_TextBox_Big2.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_TextBox_Big2.Font = new System.Drawing.Font("Tahoma", 11F);
            this.iTalk_TextBox_Big2.ForeColor = System.Drawing.Color.DimGray;
            this.iTalk_TextBox_Big2.Image = global::Optimised.Properties.Resources.user_icon_32;
            this.iTalk_TextBox_Big2.Location = new System.Drawing.Point(12, 111);
            this.iTalk_TextBox_Big2.MaxLength = 32767;
            this.iTalk_TextBox_Big2.Multiline = false;
            this.iTalk_TextBox_Big2.Name = "iTalk_TextBox_Big2";
            this.iTalk_TextBox_Big2.ReadOnly = false;
            this.iTalk_TextBox_Big2.Size = new System.Drawing.Size(313, 41);
            this.iTalk_TextBox_Big2.TabIndex = 5;
            this.iTalk_TextBox_Big2.Text = "Username";
            this.iTalk_TextBox_Big2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.iTalk_TextBox_Big2.UseSystemPasswordChar = false;
            // 
            // iTalk_TextBox_Big1
            // 
            this.iTalk_TextBox_Big1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_TextBox_Big1.Font = new System.Drawing.Font("Tahoma", 11F);
            this.iTalk_TextBox_Big1.ForeColor = System.Drawing.Color.DimGray;
            this.iTalk_TextBox_Big1.Image = global::Optimised.Properties.Resources.mail_icon_32;
            this.iTalk_TextBox_Big1.Location = new System.Drawing.Point(12, 64);
            this.iTalk_TextBox_Big1.MaxLength = 32767;
            this.iTalk_TextBox_Big1.Multiline = false;
            this.iTalk_TextBox_Big1.Name = "iTalk_TextBox_Big1";
            this.iTalk_TextBox_Big1.ReadOnly = false;
            this.iTalk_TextBox_Big1.Size = new System.Drawing.Size(313, 41);
            this.iTalk_TextBox_Big1.TabIndex = 4;
            this.iTalk_TextBox_Big1.Text = "Email";
            this.iTalk_TextBox_Big1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            this.iTalk_TextBox_Big1.UseSystemPasswordChar = false;
            // 
            // iTalk_ControlBox1
            // 
            this.iTalk_ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iTalk_ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.iTalk_ControlBox1.Location = new System.Drawing.Point(256, -1);
            this.iTalk_ControlBox1.Name = "iTalk_ControlBox1";
            this.iTalk_ControlBox1.Size = new System.Drawing.Size(77, 19);
            this.iTalk_ControlBox1.TabIndex = 0;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 329);
            this.Controls.Add(this.iTalk_ThemeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Optimised";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.iTalk_ThemeContainer1.ResumeLayout(false);
            this.iTalk_ThemeContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private iTalk.iTalk_ThemeContainer iTalk_ThemeContainer1;
        private iTalk.iTalk_ControlBox iTalk_ControlBox1;
        private System.Windows.Forms.ImageList imageList1;
        private iTalk.iTalk_LinkLabel iTalk_LinkLabel1;
        private iTalk.iTalk_Label iTalk_Label2;
        private iTalk.iTalk_Toggle iTalk_Toggle1;
        private iTalk.iTalk_Label iTalk_Label1;
        private iTalk.iTalk_Button_2 iTalk_Button_21;
        private iTalk.iTalk_TextBox_Big iTalk_TextBox_Big3;
        private iTalk.iTalk_TextBox_Big iTalk_TextBox_Big2;
        private iTalk.iTalk_TextBox_Big iTalk_TextBox_Big1;
        private System.Windows.Forms.Timer clearGC;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public  System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

