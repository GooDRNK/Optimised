using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optimised
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");
        [STAThread]

        static void Main(string[] args)
        {
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                MessageBox.Show("Nu poti sa pornesti programul de doua ori.");
            }
            else
            {
                

                if (Functii.CheckForInternetConnection() == false)
                {

                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Offline());
                }
                else if (Functii.CheckForInternetConnection() == true)
                {
                    if (File.Exists(Functii.path))
                    {
                        try
                        {
                            var MyIni = new IniFile(Functii.path);
                            if (MyIni.KeyExists("Email") && MyIni.KeyExists("Username") && MyIni.KeyExists("Password"))
                            {
                                var Pass = MyIni.Read("Password");
                                var Usser = MyIni.Read("Username");
                                var email = MyIni.Read("Email");
                                if (Pass == null || Usser == null || email == null)
                                {
                                    error = "Una sau mai multe date de conectare din AutoLogin.ini nu exista, verifica AutoLogin.ini (locatia programului) sau logheaza-te refolosind Remember Me, iar datele de logare se restabilesc.";
                                    Application.EnableVisualStyles();
                                    Application.SetCompatibleTextRenderingDefault(false);
                                    Application.Run(new Login());

                                }
                                else
                                {
                                    LoginAuto(Pass, Usser, email);
                                }
                            }
                            else
                            {
                                error = "Una sau mai multe date de conectare din AutoLogin.ini nu exista, verifica AutoLogin.ini (locatia programului) sau logheaza-te refolosind Remember Me, iar datele de logare se restabilesc.";
                                Application.EnableVisualStyles();
                                Application.SetCompatibleTextRenderingDefault(false);
                                Application.Run(new Login());
                            }
                        }
                        catch { }


                    }
                    else
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Offline());
                    }
                }
            }
        }

        public static string error = string.Empty;
        public static string tokens = string.Empty;
        public static string Parola_Autologin = string.Empty;
        public static string User_Autologin = string.Empty;
        public static string Email_Autologin = string.Empty;
        static string logininfo;
        static void LoginAuto(string pass, string user, string email)
        {

          
            logininfo = Functii.DownloadString("http://"+webip+"/loginapp/" + user.ToString() + "/" + email.ToString() + "/" + pass.ToString());
            if(logininfo.ToString().Length == 60)
            {
                Parola_Autologin = pass;
                User_Autologin = user;
                Email_Autologin = email;
                tokens = logininfo.ToString();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Optimised());
            }

            switch(logininfo.ToString())
            {
                case "Acest cont este deja conectat.":
                    {
                        error = logininfo.ToString();
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Login());
                        break;
                    }

                case "Datele introduse sunt incorecte":
                    {
                        error = logininfo.ToString();
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Login());
                        break;
                    }    
                
            }
        }


    }
}
