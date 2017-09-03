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
        #region Variabile Globale
        //Variabile Globale Star
        public static string token; //Aici este stocat token-ul pentru verificarea login-ului din aplicatie.
        public static string Parola_Login; //Aici se salveaza Parola introdusa.
        public static string User_Login; //Aici se salveaza Utilizatorul introdus.
        public static string Email_Login;  //Aici se salveaza Email-ul introdus.
                                           //Variabile Globale End
        #endregion
        #region Initializare_Form
                //Initializare Form Login Start
                public Login()
                {
                    InitializeComponent();
                    clearGC.Interval = 5000; //Seteaza intervalul pentru timerul clearGC.
                    clearGC.Start(); //Porneste timerul clearGC.
                    if (Program.error!=string.Empty) //Verifica daca sunt erori din AutoLogin.ini
                    {
                        notifyIcon1.ShowBalloonTip(2000, "Optimised Auto Login", Program.error.ToString(), ToolTipIcon.Info); //Trimite notificarea cu eroarea.
                        Program.error = string.Empty; //Seteaza eroarea pe null dupa ce este afisata.
                    }
            
                }
                //Initializare Form Login End
                #endregion
        #region Go_Register_Site
                //Href Register Start
                private void iTalk_LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
                {  
                    Process.Start("http://optimised.biz/register"); //Te trimite in pagina de inregistrare pe site.
                }
                //Href Register End
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
                    string password = Functii.GetHashSha1(iTalk_TextBox_Big3.Text).ToLower(); //Cripteaza parola.
                    string logininfo=Functii.DownloadString("http://optimised.biz/loginapp/" + iTalk_TextBox_Big2.Text + "/"+iTalk_TextBox_Big1.Text+"/"+password); //Cere informatii despre Login la API.
                    if(logininfo.ToString().Length != 60 ) //Verifica daca a returnat token sau nu.
                    {
                        notifyIcon1.ShowBalloonTip(1000, "Optimised Login", logininfo.ToString(), ToolTipIcon.Info); //Trimite messajul primit de la API.
                    }
                    else 
                    { 
                        if (iTalk_Toggle1.Toggled) //Daca Remember Me este bifat trece mai departe.
                        {
                            if (File.Exists(Functii.path)) //Daca fisierul AutoLogin.ini exista il sterge.
                            {
                                File.Delete(Functii.path); //Sterge fisierul AutoLogin.ini.
                            }

                            if (!File.Exists(Functii.path)) //Daca fisierul AutoLogin.ini nu exista trece mai departe.
                            {

                                using (StreamWriter sw = File.CreateText(Functii.path)) //Creaza fisierul AutoLogin.ini.
                                {
                                    this.Hide(); //Ascunde Form-ul de Login.
                                    sw.Close();
                                    var MyIni = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"AutoLogin.ini"); //Deschide calea de scriere in fisierul AutoLogin.ini.
                                    MyIni.Write("Password", password); //Scrie parola in fisierul AutoLogin.ini.
                                    MyIni.Write("Username", iTalk_TextBox_Big2.Text); //Scrie Utilizatorul in fisierul AutoLogin.ini.
                                    MyIni.Write("Email", iTalk_TextBox_Big1.Text); //Scrie Emailul in fisierul AutoLogin.ini.
                                    token = logininfo.ToString(); //Salveaza token-ul primit.
                                    User_Login = iTalk_TextBox_Big2.Text; //Salveaza Utilizatorul logat.
                                    Parola_Login = password; //Salveaza Parola folosita.
                                    Email_Login = iTalk_TextBox_Big1.Text; //Salveaza Emailul folosit.
                                    Optimised optimised = new Optimised(); //Deschide calea catre noul Form.
                                    notifyIcon1.Visible = false; //Stinge Iconita din sistem Tray.
                                    optimised.ShowDialog(); //Porneste Form-ul cu aplicatia propriuzisa.
                                    this.Close();
                                }
                            }
                        }
                        else //Daca Remember Me nu este bifat trece mai departe.
                        {
                            this.Hide(); //Ascunde Form-ul de Login.
                            token = logininfo.ToString(); //Salveaza token-ul primit.
                            User_Login = iTalk_TextBox_Big2.Text; //Salveaza Utilizatorul logat.
                            Parola_Login = password; //Salveaza Parola folosita.
                            Email_Login = iTalk_TextBox_Big1.Text; //Salveaza Emailul folosit.
                            Optimised optimised = new Optimised(); //Deschide calea catre noul Form.
                            notifyIcon1.Visible = false; //Stinge Iconita din sistem Tray.
                            optimised.ShowDialog(); //Porneste Form-ul cu aplicatia propriuzisa.
                            this.Close();
                            
                        }
                    }
           
                }
                private void iTalk_Button_22_Click(object sender, EventArgs e)
                {
                    this.Hide();
                    Offline optimised = new Offline(); //Deschide calea catre noul Form.
                    notifyIcon1.Visible = false; //Stinge Iconita din sistem Tray.
                    optimised.ShowDialog(); //Porneste Form-ul cu aplicatia propriuzisa.
                    this.Close();
                }
        #endregion
        #region Sistem_Tray_Meniu
        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit(); //Stinge Aplicatia.
        }

        private void goWebToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("http://optimised.biz"); //Intra pe site.
        }

        private void registerToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("http:///optimised.biz/register"); //Intra in sectiunea de Register.
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

    }
}
