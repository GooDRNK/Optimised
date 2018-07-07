using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;
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
            RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Optimised", true);
            RegistryKey regKeyAppRoot1;
            if (regKeyAppRoot == null)
            {
                RegistryKey key =  Registry.CurrentUser.CreateSubKey(@"Software\Optimised");
                key.SetValue("Key", "0");
                regKeyAppRoot1 = Registry.CurrentUser.OpenSubKey(@"Software\Optimised", true);
                regKeyAppRoot.Close();
           
            }
            else
            {
                int c = 0;
                foreach (string value in regKeyAppRoot.GetValueNames())
                {
                    c++;
                  
                }
                if (c != 1)
                {
                    regKeyAppRoot.SetValue("Key", "0");
                }
                regKeyAppRoot1 = Registry.CurrentUser.OpenSubKey(@"Software\Optimised", true);
                regKeyAppRoot.Close();
            }
         
            if (!mutex.WaitOne(TimeSpan.Zero, true))
            {
                MessageBox.Show("Nu poti deschide aplicatia de mai multe ori");
            }
            else
            {
                while (!Functii.CheckForInternetConnection()) { }
               if (Functii.CheckForInternetConnection())
                {
                   
                    if (regKeyAppRoot1 != null)
                    {
                        try
                        {
                           
                            if (regKeyAppRoot1.GetValue("Key")!=null && regKeyAppRoot1.GetValue("Key").ToString().Length == 30)
                            {
                                  LoginAuto(regKeyAppRoot1.GetValue("Key").ToString());
                            }
                            else
                            {
                                Application.EnableVisualStyles();
                                Application.SetCompatibleTextRenderingDefault(false);
                                Application.Run(new Login());
                            }
                        }
                        catch { }
                    }
                }
            }
        }

        public static string error = string.Empty;
        public static string tokens = string.Empty;
        public static string Key = string.Empty;
        public static string Id = string.Empty;
        public static string Email = string.Empty;
        public static string statie = string.Empty;
        static void LoginAuto(string key)
        {
            dynamic logininfo;
            try
            {
                logininfo = Newtonsoft.Json.JsonConvert.DeserializeObject(Functii.DownloadString("http://" + Functii.webip + "/loginapp/" + key.ToString()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
            if (logininfo.token.ToString().Length == 60)
            {
                Key = key;
                tokens = logininfo.token.ToString();
                Id = logininfo.id.ToString();
                Email = logininfo.email.ToString();
                statie = logininfo.statie.ToString();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Optimised());
            }
            else
            {
                        error = logininfo.error.ToString();
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Login());
            }
        }
    }
}
