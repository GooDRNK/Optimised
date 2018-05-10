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
using static Optimised.Program;
using Microsoft.Win32;

namespace Optimised
{
    public partial class Login : Form
    {
        #region Variabile Globale
        //Variabile Globale Star
        public static string token; //Aici este stocat token-ul pentru verificarea login-ului din aplicatie.
        public static string Key; //Aici se salveaza Parola introdusa.
        //Variabile Globale End
        #endregion
        #region Initializare_Form
        //Initializare Form Login Start
        public Login()
        {
            InitializeComponent();
        }
        //Initializare Form Login End
        #endregion
       
        #region clearGC_Timer_Wipe_Ram
        //clearGC_Timer Start
        private void clearGC_Tick(object sender, EventArgs e)
        {
            Functii.FlushMemory(); //Colecteaza tot ramul utilizat si il sterge.
        }
        //clearGC_Timer End
        #endregion
        #region Sistem_Login
        private void iTalk_Button_21_Click(object sender, EventArgs e)
        {
            if (iTalk_TextBox_Big3.Text != "")
            {
                string logininfo;
                try
                {
                    logininfo = Functii.DownloadString("http://" + Functii.webip + "/loginapp/" + iTalk_TextBox_Big3.Text); //Cere informatii despre Login la API.
                    if (logininfo.ToString().Length != 60) //Verifica daca a returnat token sau nu.
                    {
                        try
                        {
                            notifyIcon1.ShowBalloonTip(1000, "Optimised Login", logininfo.ToString(), ToolTipIcon.Info); //Trimite messajul primit de la API.

                        }
                        catch (Exception)
                        {
                            notifyIcon1.ShowBalloonTip(1000, "Optimised Login", "Eroare la server!", ToolTipIcon.Info); //Trimite messajul primit de la API.
                           
                            throw;
                        }
                    }
                    else
                    {
                        MessageBox.Show(logininfo.ToString());
                        RegistryKey keys = Registry.CurrentUser.OpenSubKey(@"Software\Optimised", true);
                        keys.SetValue("Key", iTalk_TextBox_Big3.Text.ToString());
                        this.Hide(); //Ascunde Form-ul de Login.
                        token = logininfo.ToString(); //Salveaza token-ul primit.
                        Key = iTalk_TextBox_Big3.Text.ToString(); //Salveaza key
                        Optimised optimised = new Optimised(); //Deschide calea catre noul Form.
                        notifyIcon1.Dispose(); //Stinge Iconita din sistem Tray.
                        optimised.ShowDialog(); //Porneste Form-ul cu aplicatia propriuzisa.
                        clearGC.Stop();

                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                notifyIcon1.ShowBalloonTip(1000, "Optimised Login", "Parola lipseste!", ToolTipIcon.Info); //Trimite messajul primit de la API.
            }

        }
 
        #endregion
        #region Sistem_Tray_Meniu
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Dispose();

            var proc = Process.GetCurrentProcess().ProcessName;
            foreach (var process in Process.GetProcessesByName(proc))
            {
                process.Kill();
            } //Stinge Aplicatia.
        }
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();

            var proc = Process.GetCurrentProcess().ProcessName;
            foreach (var process in Process.GetProcessesByName(proc))
            {
                process.Kill();
            } //Stinge Aplicatia.
        }

        private void goWebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://" + Functii.webip + ""); //Intra pe site.
        }

        private void registerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("http:///" + Functii.webip + "/register"); //Intra in sectiunea de Register.
        }

        private void loginToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal; //Reaprinde Login-ul.
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized; //Ascunde Login-ul.
            }
            else
            {
                WindowState = FormWindowState.Normal; //Reaprinde Login-ul.
            }
        }
        #endregion

        private void Login_Load(object sender, EventArgs e)
        {
            clearGC.Interval = 5000;
            clearGC.Start();
            if (Program.error != string.Empty) //Verifica daca sunt erori din AutoLogin.ini
            {
                try
                {
                    notifyIcon1.ShowBalloonTip(2000, "Optimised Auto Login", Program.error.ToString(), ToolTipIcon.Info); //Trimite notificarea cu eroarea.

                }
                catch (Exception)
                {
                    MessageBox.Show("Raspunsul este gol");
                    throw;
                }


                 Program.error = string.Empty; //Seteaza eroarea pe null dupa ce este afisata.
            }
        }
    }
}
