using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using Optimised;
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

            }
            else
            {
                if (!Functii.CheckForInternetConnection())
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Login());
                }
                else if (Functii.CheckForInternetConnection())
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
        static string logininfo;
        static void LoginAuto(string key)
        {
            
            try
            {
                logininfo = Functii.DownloadString("http://" + Functii.webip + "/loginapp/" + key.ToString());
                Console.WriteLine(logininfo);
            }
            catch (Exception)
            {

                throw;
            }
            if (logininfo.ToString().Length == 60)
            {
                Key = key;
                tokens = logininfo.ToString();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Optimised());
            }
            else
            {
                        error = logininfo.ToString();
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Login());
            }
        }
    }
}
