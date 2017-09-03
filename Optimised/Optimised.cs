using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace Optimised
{
    public partial class Optimised : Form
    {
        #region Variabile_Globale
            //Variabile Globale Start
            string Parola; //Aici se salveaza Parola.
            string Username; //Aici se salveaza Utilizatorul.
            string Email; //Aici se salveaza Emailul.
            string token; //Aici se salveaza token-ul.
            public static RegistryKey regKey; //Registri key
            public static string windows = Path.GetPathRoot(Environment.SystemDirectory);
        //Variabile Globale End
        #endregion
        #region Initializare_App
        public Optimised()
                {
                    InitializeComponent();
                    GetApiData.RunWorkerAsync();
                    ClearRam.Interval = 5000;
                    ClearRam.Start();
                    if(Program.tokens!=string.Empty) //Se verifica daca token-ul trimis din AutoLogin este null.
                    {
                        token = Program.tokens; //Se seteaza token-ul trimis din AutoLogin.
                    }
                    else //Daca nu sa folosit AutoLogin trece aici.
                    {
                        token = Login.token; //Se seteaza token-ul trimis din Login.
                    }
                    if (Program.Email_Autologin != string.Empty && Program.Parola_Autologin != string.Empty && Program.User_Autologin != string.Empty) //Daca datele trimise din AutoLogin nu sunt nule sare aici.
                    {
                        //Seteaza datele primite din AutoLogin.
                        Parola = Program.Parola_Autologin; 
                        Username = Program.User_Autologin;
                        Email = Program.Email_Autologin;
                        //Seteaza datele primite din AutoLogin.
                    }
                    else //Daca nu sa folosit AutoLogin sare aici.
                    {
                        //Seteaza datele primite din Login.
                        Parola = Login.Parola_Login;
                        Username = Login.User_Login;
                        Email = Login.Email_Login;
                        //Seteaza datele primite din Login.
                    }
                }
        #endregion
        #region Logout
        private void Optimised_FormClosing(object sender, FormClosingEventArgs e)
        {
            string logout = Functii.DownloadString("http://optimised.biz/logoutapp/" + Username + "/" + Email + "/" + Parola +"/" +token); //Cere informatii despre Login la API.
        }
        #endregion
        #region DllImport All
        [DllImport("shell32.dll")]
        public static extern void SHAddToRecentDocs(ShellAddToRecentDocsFlags flag, IntPtr pidl);
        [DllImport("Shell32.dll", CharSet = CharSet.Unicode)]
        static extern uint SHEmptyRecycleBin(IntPtr hwnd, string pszRootPath, RecycleFlags dwFlags);
        #endregion
        #region Enum
        enum RecycleFlags : uint
        {
            SHERB_NOCONFIRMATION = 0x00000001,
            SHERB_NOPROGRESSUI = 0x00000002,
            SHERB_NOSOUND = 0x00000004
        }
        public enum ShellAddToRecentDocsFlags
        {
            Pidl = 0x001,
            Path = 0x002,
        }
        #endregion
        private void GetApiData_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                var start_opt_only =  Functii.DownloadString("http://optimised.biz/getoptonly/"+Username+"/"+Email+"/"+Parola+"/"+token+"/1");
                if(start_opt_only == "1")
                {
                    if (!Optimised_Only.IsBusy)
                    {            
                        Optimised_Only.RunWorkerAsync();
                    }
                }
                var start_opt_all = Functii.DownloadString("http://optimised.biz/getoptall/" + Username + "/" + Email + "/" + Parola + "/" + token + "/1");
                if (start_opt_all == "1")
                {
                    if (!Optimised_All.IsBusy)
                    {
                        Optimised_All.RunWorkerAsync();
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private void Optimised_Only_DoWork(object sender, DoWorkEventArgs e)
        {
            notifyIcon1.ShowBalloonTip(1000, "Optimised Cloud", "Optimizarea trimisa din cloud exclusiv tie a pornit.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.
            var optiunile = Functii.DownloadString("http://optimised.biz/getoptonly/" + Username + "/" + Email + "/" + Parola + "/" + token);
            dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(optiunile);
            if (obj["muic"] == 1)
            {
                Console.WriteLine("muic");
                try
                {

                    regKey = Registry.CurrentUser.OpenSubKey(@"Software\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache", true);
                    foreach (string value in regKey.GetValueNames())
                    {
                        regKey.DeleteValue(value, true);
                        
                    }
                    regKey.Close();
                }
                catch
                {

                }
            }
            if (obj["pref"] == 1)
            {
                try
                {
                    Array.ForEach(Directory.GetFiles(windows + @"Windows\Prefetch\", "*.pf"),
                       delegate (string path) { File.Delete(path);});
                }
                catch { }//Delete Prefetch
            }
            if (obj["rapp"] == 1)
            {
                try
                {

                    RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Search\RecentApps", true);
                    foreach (string value in regKeyAppRoot.GetSubKeyNames())
                    {
                        regKeyAppRoot.DeleteSubKeyTree(value, true);
                    }
                    regKeyAppRoot.Close();

                }
                catch { }//Delete Regedit 
            }
            if (obj["temp"] == 1)
            {
                Console.WriteLine("temp");
                string pat = Path.GetTempPath();
                System.IO.DirectoryInfo di = new DirectoryInfo(pat.ToString());
                foreach (FileInfo file in di.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch { }
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true); 
                    }
                    catch { }
                }
            }
            if (obj["trac"] == 1)
            {
                try
                {
                    RegistryKey regKeyAppRoot = Registry.LocalMachine.OpenSubKey(@"Software\WOW6432Node\Microsoft\Tracing", true);
                    foreach (string value in regKeyAppRoot.GetSubKeyNames())
                    {
                        regKeyAppRoot.DeleteSubKeyTree(value, true);
                    }
                    regKeyAppRoot.Close();
                }
                catch
                {}//Delete Regedit
            }
            if (obj["rebin"] == 1)
            {
                try { uint result = SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOCONFIRMATION); } catch { }
            }
            if (obj["rfile"] == 1)
            {
                try { SHAddToRecentDocs(ShellAddToRecentDocsFlags.Pidl, (IntPtr)(0)); } catch { }
            }
            if (obj["wlogs"] == 1)
            {
                foreach (var eventLog in EventLog.GetEventLogs())
                {
                    try
                    {
                        eventLog.Clear();
                        eventLog.Dispose();
                    }
                    catch { }
                }
            }
            if (obj["mpoint"] == 1)
            {
                try
                {

                    RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\MountPoints2", true);
                    foreach (string values in regKeyAppRoot.GetSubKeyNames())
                    {
                        regKeyAppRoot.DeleteSubKeyTree(values, true);
                    }
                }
                catch { }//Delete Regedit
            }
            if (obj["rstart"] == 1)
            {
                try
                {

                    regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                    foreach (string value in regKey.GetValueNames())
                    {
                        regKey.DeleteValue(value, true);
                    }
                    regKey.Close();
                }
                catch
                {

                }
            }
            if (obj["useras"] == 1)
            {
                try
                {
                    regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\UserAssist", true);
                    foreach (string value in regKey.GetSubKeyNames())
                    {
                        regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\UserAssist\" + value.ToString() + @"\Count", true);
                        foreach (string cont in regKey.GetValueNames())
                        {
                            regKey.DeleteValue(cont, true);
                        }
                    }
                    regKey.Close();
                }
                catch
                {
                }
            }
            if (obj["compstore"] == 1)
            {
                try
                {
                    RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store", true);
                    foreach (string values in regKeyAppRoot.GetValueNames())
                    {
                        regKeyAppRoot.DeleteValue(values, true);
                    }
                }
                catch { }//Delete Regedit
            }
            notifyIcon1.ShowBalloonTip(1000, "Optimised Cloud End", "Optimizarea trimisa din cloud exclusiv tie a fost efectuata.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud se termina.
        }

        private void Optimised_All_DoWork(object sender, DoWorkEventArgs e)
        {
            notifyIcon1.ShowBalloonTip(1000, "Optimised Cloud", "Optimizarea trimisa din cloud pentru toti utilizatorii a inceput.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.
            var optiunile = Functii.DownloadString("http://optimised.biz/getoptall/" + Username + "/" + Email + "/" + Parola + "/" + token);
            dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(optiunile);
            if (obj["muic"] == 1)
            {
                Console.WriteLine("muic");
                try
                {

                    regKey = Registry.CurrentUser.OpenSubKey(@"Software\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache", true);
                    foreach (string value in regKey.GetValueNames())
                    {
                        regKey.DeleteValue(value, true);

                    }
                    regKey.Close();
                }
                catch
                {

                }
            }
            if (obj["pref"] == 1)
            {
                try
                {
                    Array.ForEach(Directory.GetFiles(windows + @"Windows\Prefetch\", "*.pf"),
                       delegate (string path) { File.Delete(path); });
                }
                catch { }//Delete Prefetch
            }
            if (obj["rapp"] == 1)
            {
                try
                {

                    RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Search\RecentApps", true);
                    foreach (string value in regKeyAppRoot.GetSubKeyNames())
                    {
                        regKeyAppRoot.DeleteSubKeyTree(value, true);
                    }
                    regKeyAppRoot.Close();

                }
                catch { }//Delete Regedit 
            }
            if (obj["temp"] == 1)
            {
                Console.WriteLine("temp");
                string pat = Path.GetTempPath();
                System.IO.DirectoryInfo di = new DirectoryInfo(pat.ToString());
                foreach (FileInfo file in di.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch { }
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true);
                    }
                    catch { }
                }
            }
            if (obj["trac"] == 1)
            {
                try
                {
                    RegistryKey regKeyAppRoot = Registry.LocalMachine.OpenSubKey(@"Software\WOW6432Node\Microsoft\Tracing", true);
                    foreach (string value in regKeyAppRoot.GetSubKeyNames())
                    {
                        regKeyAppRoot.DeleteSubKeyTree(value, true);
                    }
                    regKeyAppRoot.Close();
                }
                catch
                { }//Delete Regedit
            }
            if (obj["rebin"] == 1)
            {
                try { uint result = SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOCONFIRMATION); } catch { }
            }
            if (obj["rfile"] == 1)
            {
                try { SHAddToRecentDocs(ShellAddToRecentDocsFlags.Pidl, (IntPtr)(0)); } catch { }
            }
            if (obj["wlogs"] == 1)
            {
                foreach (var eventLog in EventLog.GetEventLogs())
                {
                    try
                    {
                        eventLog.Clear();
                        eventLog.Dispose();
                    }
                    catch { }
                }
            }
            if (obj["mpoint"] == 1)
            {
                try
                {

                    RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\MountPoints2", true);
                    foreach (string values in regKeyAppRoot.GetSubKeyNames())
                    {
                        regKeyAppRoot.DeleteSubKeyTree(values, true);
                    }
                }
                catch { }//Delete Regedit
            }
            if (obj["rstart"] == 1)
            {
                try
                {

                    regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                    foreach (string value in regKey.GetValueNames())
                    {
                        regKey.DeleteValue(value, true);
                    }
                    regKey.Close();
                }
                catch
                {

                }
            }
            if (obj["useras"] == 1)
            {
                try
                {
                    regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\UserAssist", true);
                    foreach (string value in regKey.GetSubKeyNames())
                    {
                        regKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\UserAssist\" + value.ToString() + @"\Count", true);
                        foreach (string cont in regKey.GetValueNames())
                        {
                            regKey.DeleteValue(cont, true);
                        }
                    }
                    regKey.Close();
                }
                catch
                {
                }
            }
            if (obj["compstore"] == 1)
            {
                try
                {
                    RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store", true);
                    foreach (string values in regKeyAppRoot.GetValueNames())
                    {
                        regKeyAppRoot.DeleteValue(values, true);
                    }
                }
                catch { }//Delete Regedit
            }
            notifyIcon1.ShowBalloonTip(1000, "Optimised Cloud End", "Optimizarea trimisa din cloud pentru toti utilizatorii a fost efectuata.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud se termina.

        }

        private void ClearRam_Tick(object sender, EventArgs e)
        {
            Functii.FlushMemory();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
