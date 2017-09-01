using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace Optimised
{
    public partial class Login : Form
    {
        //Bariabile Globale Star
        public static string token;
        public static string Pass;
        public static string Usser;
        public static string Email;
        
        
        //Variabile Globale End

      
        //Initializare Form Login Start
        public Login()
        {
            InitializeComponent();
            
        }
        //Initializare Form Login End

        //Href Register Start
        private void iTalk_LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {  
            Process.Start("http://optimised.biz/register");
        }
        //Href Register End

        //Login_Load Start
        private void Login_Load(object sender, EventArgs e)
        {
            clearGC.Interval = 10000;
            clearGC.Start();
        }
        //Login_Load End
 
        //clearGC_Timer Start
        private void clearGC_Tick(object sender, EventArgs e)
        {
            GC.Collect();
        }
        //clearGC_Timer End
        private void iTalk_Button_21_Click(object sender, EventArgs e)
        {
            string password = Functii.GetHashSha1(iTalk_TextBox_Big3.Text).ToLower(); 
            string logininfo=Functii.DownloadString("http://optimised.biz/loginapp/" + iTalk_TextBox_Big2.Text + "/"+iTalk_TextBox_Big1.Text+"/"+password);
            if(logininfo.ToString().Length < 60 )
            {
                notifyIcon1.ShowBalloonTip(1000, "Optimised Login", logininfo.ToString(), ToolTipIcon.Info);
            }
            else 
            {
                token = logininfo.ToString();
                if (iTalk_Toggle1.Toggled)
                {
                    if (File.Exists(Functii.path))
                    {
                        File.Delete(Functii.path);
                    }

                    if (!File.Exists(Functii.path))
                    {

                        using (StreamWriter sw = File.CreateText(Functii.path))
                        {
                            sw.Close();
                            var MyIni = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"AutoLogin.ini");
                            MyIni.Write("Password", password);
                            MyIni.Write("Username", iTalk_TextBox_Big2.Text);
                            MyIni.Write("Email", iTalk_TextBox_Big1.Text);
                            Optimised optimised = new Optimised();
                            notifyIcon1.Visible = false;
                            optimised.Show();
                            this.Hide();
                        }
                    }
                }
                else
                {
                    Usser = iTalk_TextBox_Big2.Text;
                    Pass = password;
                    Email = iTalk_TextBox_Big1.Text;
                    Optimised optimised = new Optimised();
                    notifyIcon1.Visible = false;
                    optimised.Show();
                    this.Hide();
                }
            }
           
        }
      

    }
}
