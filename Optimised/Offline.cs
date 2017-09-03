using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            GClean.Interval = 5000;
            GClean.Start();   
        }
        private void iTalk_Button_21_Click(object sender, EventArgs e)
        {
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

    }
}
