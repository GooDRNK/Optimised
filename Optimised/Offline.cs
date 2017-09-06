using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optimised
{
    public partial class Offline : Form
    {
        
        public Offline()
        {
            InitializeComponent();

        }
        private void iTalk_Button_21_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }
        private void GClean_Tick(object sender, EventArgs e)
        {
           Functii.FlushMemory();
        }
        int count = 0;
        private void iTalk_Button_22_Click(object sender, EventArgs e)
        {
            if (count == 0)
            {
                count++;
                webBrowser1.Show();
                iTalk_Button_22.Text = "End Register";
                webBrowser1.Navigate("http://optimised.biz/register");
            }
            else if (count == 1)
            {
                count = 0;
                iTalk_Button_22.Text = "Go Register";
                webBrowser1.Hide();
                webBrowser1.Navigate("about:blank");
                this.Refresh();
            } 
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {

            notifyIcon1.Dispose();
            this.Hide();
            Login log = new Login();
            log.Show();
            GClean.Stop();
 
        }

        private void Offline_Resize(object sender, EventArgs e)
        {
         
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var proc = Process.GetCurrentProcess().ProcessName;
            notifyIcon1.Dispose();
            foreach (var process in Process.GetProcessesByName(proc))
            {
                process.Kill();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                this.Hide();
            }
            else if (this.Visible == false)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Offline_Load(object sender, EventArgs e)
        {
            GClean.Interval = 5000;
            GClean.Start();
        }

        private void Offline_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Dispose();
            var proc = Process.GetCurrentProcess().ProcessName;
            foreach (var process in Process.GetProcessesByName(proc))
            {
                process.Kill();
            }
        }
    }
}
