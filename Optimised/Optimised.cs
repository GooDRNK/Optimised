using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32.TaskScheduler;
using System.Net.NetworkInformation;
using System.Linq;
using System.Management;
using System.Text;

namespace Optimised
{
    public partial class Optimised : Form
    {
      
        #region Variabile_Globale
        //Variabile Globale Start
        string Key; //Aici se salveaza Parola.
        string token; //Aici se salveaza token-ul.
        public static RegistryKey regKey; //Registri key
        public static string windows = Path.GetPathRoot(Environment.SystemDirectory);
        string ip;
        string mac;
        string localip;
        string sistem;
        //Variabile Globale End
        #endregion
        #region Initializare_App
        public Optimised()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
        }
        #endregion
        #region Logout
        private void Optimised_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Functii.isadmin())
            {
                notifyIcon1.Dispose();
             var proc = Process.GetCurrentProcess().ProcessName;
            foreach (var process in Process.GetProcessesByName(proc))
            {
                process.Kill();
            }
            }
            else
            {
                notifyIcon1.ShowBalloonTip(1000, "Optimised", "Nu esti Administrator.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.

            }
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
        
        public void ResolveLnkDesktop()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Array.ForEach(Directory.GetFiles(desktop, "*.lnk"), delegate (string pathe)
            {
                string directory = Path.GetDirectoryName(pathe);
                string file = Path.GetFileName(pathe);
                Shell32.Shell shell = new Shell32.Shell();
                Shell32.Folder folder = shell.NameSpace(directory);
                Shell32.FolderItem folderItem = folder.ParseName(file);
                Shell32.ShellLinkObject link = (Shell32.ShellLinkObject)folderItem.GetLink;
                if (!File.Exists(link.Path))
                {
                    File.Delete(pathe);
                }
            });
        }

        private void GetApiData_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                var start_opt_only = Functii.DownloadString("http://" + Functii.webip + "/getoptonly/" + Key + "/" + token + "/0");   
               if (start_opt_only == "1")
               {
                   if (!Optimised_Only.IsBusy)
                   {
                       Optimised_Only.RunWorkerAsync();
                   }
               }
               Thread.Sleep(1000);
            }
        }
        private void optionstart_DoWork(object sender, DoWorkEventArgs e)
        {
            var opensitee = Functii.DownloadString("http://" + Functii.webip + "/optsistem/" + Key + "/" + token + "/1");
            if (opensitee != string.Empty)
            {
                switch (opensitee)
                {
                    case "S":
                        {
                            notifyIcon1.ShowBalloonTip(1000, "Optimised Cloud", "Sistemul se va opri in 2 secunde.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.
                            Thread.Sleep(2000);
                            Shutdown.Shut();
                            break;
                        }
                    case "R":
                        {
                            notifyIcon1.ShowBalloonTip(1000, "Optimised Cloud", "Sistemul se va reseta in 2 secunde.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.
                            Thread.Sleep(2000);
                            Shutdown.Restart();
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private void opensite_DoWork(object sender, DoWorkEventArgs e)
        {
            string opensite = Functii.DownloadString("http://" + Functii.webip + "/getwebstart/" + Key + "/" + token + "/1");
            if (opensite != string.Empty)
            {
                Process.Start(opensite);
                notifyIcon1.ShowBalloonTip(1000, "Optimised Cloud", "Site-ul: " + opensite + " a pornit.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.           
            }
        }
        private void Optimised_Only_DoWork(object sender, DoWorkEventArgs e)
        {

            ListBox.CheckForIllegalCrossThreadCalls = false;
            iTalk.iTalk_GroupBox.CheckForIllegalCrossThreadCalls = false;
            iTalk_GroupBox1.Text = "Last Log Optimised Cloud - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:s"); Refresh();
            notifyIcon1.ShowBalloonTip(1000, "Optimised Cloud", "Optimizarea trimisa din cloud exclusiv tie a pornit.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.
            var optiunile = Functii.DownloadString("http://" + Functii.webip + "/getoptonly/" + Key + "/" + token+"/1");
            dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(optiunile);
            if (obj["muic"] == 1)
            {
                try
                {

                    regKey = Registry.CurrentUser.OpenSubKey(@"Software\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache", true);
                    foreach (string value in regKey.GetValueNames())
                    {
                        regKey.DeleteValue(value, true);
                        listBox1.Items.Add("MUI Cache: " + value);
                    }
                    regKey.Close();
                }
                catch
                {

                }
            }
            for (int i = 0; i <= 10; i++)
            {
                Optimised_Only.ReportProgress(i);
                Thread.Sleep(100);
            }
            if (obj["pref"] == 1)
            {
                try
                {
                    Array.ForEach(Directory.GetFiles(windows + @"Windows\Prefetch\", "*.pf"),
                       delegate (string path)
                       {
                           File.Delete(path);
                           if (!File.Exists(path))
                           {
                               listBox1.Items.Add("Prefetch: " + path);
                           }
                       });
                }
                catch { }//Delete Prefetch
            }
            for (int j = 10; j <= 20; j++)
            {
                Optimised_Only.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (obj["rapp"] == 1)
            {
                try
                {

                    RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Search\RecentApps", true);
                    foreach (string value in regKeyAppRoot.GetSubKeyNames())
                    {
                        regKeyAppRoot.DeleteSubKeyTree(value, true);
                        listBox1.Items.Add("Recent Apps: " + value);
                    }
                    regKeyAppRoot.Close();

                }
                catch { }//Delete Regedit 
            }
            for (int j = 20; j <= 30; j++)
            {
                Optimised_Only.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (obj["temp"] == 1)
            {
                string pat = Path.GetTempPath();
                System.IO.DirectoryInfo di = new DirectoryInfo(pat.ToString());
                foreach (FileInfo file in di.GetFiles())
                {
                    try
                    {
                        file.Delete();
                        if (!File.Exists(file.FullName))
                        {
                            listBox1.Items.Add("Temp File: " + file.FullName);
                        }
                    }
                    catch { }
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true);
                        if (!Directory.Exists(dir.FullName))
                        {
                            listBox1.Items.Add("Temp Dir: " + dir.FullName);
                        }
                    }
                    catch { }
                }
            }
            for (int j = 30; j <= 40; j++)
            {
                Optimised_Only.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (obj["trac"] == 1)
            {
                try
                {
                    RegistryKey regKeyAppRoot = Registry.LocalMachine.OpenSubKey(@"Software\WOW6432Node\Microsoft\Tracing", true);
                    foreach (string value in regKeyAppRoot.GetSubKeyNames())
                    {
                        regKeyAppRoot.DeleteSubKeyTree(value, true);
                        listBox1.Items.Add("Tracing: " + value);
                    }
                    regKeyAppRoot.Close();
                }
                catch
                { }//Delete Regedit
            }
            for (int j = 40; j <= 50; j++)
            {
                Optimised_Only.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (obj["rebin"] == 1)
            {
                try { uint result = SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOCONFIRMATION); } catch { }
            }
            if (obj["rfile"] == 1)
            {
                String recent = Environment.ExpandEnvironmentVariables("%APPDATA%") + @"\Microsoft\Windows\Recente";
                try
                {
                    Array.ForEach(Directory.GetFiles(recent, "*.*"),
                       delegate (string path)
                       {
                           File.Delete(path);
                           if (!File.Exists(path))
                           {
                               listBox1.Items.Add("Recent Files: " + path);
                           }
                       });
                }
                catch { }//Delete Recent files
                try { SHAddToRecentDocs(ShellAddToRecentDocsFlags.Pidl, (IntPtr)(0)); } catch { }
            }
            for (int j = 50; j <= 60; j++)
            {
                Optimised_Only.ReportProgress(j);
                Thread.Sleep(100);
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
            for (int j = 60; j <= 70; j++)
            {
                Optimised_Only.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (obj["mpoint"] == 1)
            {
                try
                {

                    RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\MountPoints2", true);
                    foreach (string values in regKeyAppRoot.GetSubKeyNames())
                    {
                        regKeyAppRoot.DeleteSubKeyTree(values, true);
                        listBox1.Items.Add("MountPoints: " + values);
                    }
                }
                catch { }//Delete Regedit
            }
            for (int j = 70; j <= 80; j++)
            {
                Optimised_Only.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (obj["rstart"] == 1)
            {
                try
                {

                    regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                    foreach (string value in regKey.GetValueNames())
                    {
                        regKey.DeleteValue(value, true);
                        listBox1.Items.Add("Run At Startup: " + value);
                    }
                    regKey.Close();
                }
                catch
                {

                }
            }
            for (int j = 80; j <= 90; j++)
            {
                Optimised_Only.ReportProgress(j);
                Thread.Sleep(100);
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
                            listBox1.Items.Add("UserAssist: " + Rot13.Transform(cont));
                        }
                    }
                    regKey.Close();
                }
                catch
                {
                }
            }
            for (int j = 90; j <= 100; j++)
            {
                Optimised_Only.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (obj["compstore"] == 1)
            {
                try
                {
                    RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store", true);
                    foreach (string values in regKeyAppRoot.GetValueNames())
                    {
                        regKeyAppRoot.DeleteValue(values, true);
                        listBox1.Items.Add("Compatibility Store: " + values);
                    }
                }
                catch { }//Delete Regedit
            }
            notifyIcon1.ShowBalloonTip(1000, "Optimised Cloud End", "Optimizarea trimisa din cloud exclusiv tie a fost efectuata.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud se termina.
        }
        private void Optimised_All_DoWork(object sender, DoWorkEventArgs e)
        {
            
            ListBox.CheckForIllegalCrossThreadCalls = false;
            iTalk.iTalk_GroupBox.CheckForIllegalCrossThreadCalls = false;
            iTalk_GroupBox1.Text = "Last Log Optimised Cloud - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:s"); Refresh();
            notifyIcon1.ShowBalloonTip(1000, "Optimised Cloud", "Optimizarea trimisa din cloud pentru toti utilizatorii a inceput.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.
            var optiunile = Functii.DownloadString("http://" + Functii.webip + "/getoptall/" + Key + "/" + token+"/1");
            dynamic obj = Newtonsoft.Json.JsonConvert.DeserializeObject(optiunile);
            if (obj["muic"] == 1)
            {
                try
                {

                    regKey = Registry.CurrentUser.OpenSubKey(@"Software\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache", true);
                    foreach (string value in regKey.GetValueNames())
                    {
                        regKey.DeleteValue(value, true);
                        listBox1.Items.Add("MUI Cache: " + value);
                    }
                    regKey.Close();
                }
                catch
                {

                }
            }
            for (int i = 0; i <= 10; i++)
            {
                Optimised_All.ReportProgress(i);
                Thread.Sleep(100);
            }
            if (obj["pref"] == 1)
            {
                try
                {
                    Array.ForEach(Directory.GetFiles(windows + @"Windows\Prefetch\", "*.pf"),
                       delegate (string path)
                       {
                           File.Delete(path);
                           if (!File.Exists(path))
                           {
                               listBox1.Items.Add("Prefetch: " + path);
                           }
                       });
                }
                catch { }//Delete Prefetch
            }
            for (int j = 10; j <= 20; j++)
            {
                Optimised_All.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (obj["rapp"] == 1)
            {
                try
                {

                    RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Search\RecentApps", true);
                    foreach (string value in regKeyAppRoot.GetSubKeyNames())
                    {
                        regKeyAppRoot.DeleteSubKeyTree(value, true);
                        listBox1.Items.Add("Recent Apps: " + value);
                    }
                    regKeyAppRoot.Close();

                }
                catch { }//Delete Regedit 
            }
            for (int j = 20; j <= 30; j++)
            {
                Optimised_All.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (obj["temp"] == 1)
            {
                string pat = Path.GetTempPath();
                System.IO.DirectoryInfo di = new DirectoryInfo(pat.ToString());
                foreach (FileInfo file in di.GetFiles())
                {
                    try
                    {
                        file.Delete();
                        if (!File.Exists(file.FullName))
                        {
                            listBox1.Items.Add("Temp File: " + file.FullName);
                        }
                    }
                    catch { }
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true);
                        if (!Directory.Exists(dir.FullName))
                        {
                            listBox1.Items.Add("Temp Dir: " + dir.FullName);
                        }
                    }
                    catch { }
                }
            }
            for (int j = 30; j <= 40; j++)
            {
                Optimised_All.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (obj["trac"] == 1)
            {
                try
                {
                    RegistryKey regKeyAppRoot = Registry.LocalMachine.OpenSubKey(@"Software\WOW6432Node\Microsoft\Tracing", true);
                    foreach (string value in regKeyAppRoot.GetSubKeyNames())
                    {
                        regKeyAppRoot.DeleteSubKeyTree(value, true);
                        listBox1.Items.Add("Tracing: " + value);
                    }
                    regKeyAppRoot.Close();
                }
                catch
                { }//Delete Regedit
            }
            for (int j = 40; j <= 50; j++)
            {
                Optimised_All.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (obj["rebin"] == 1)
            {
                try { uint result = SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOCONFIRMATION); } catch { }
            }
            if (obj["rfile"] == 1)
            {
                String recent = Environment.ExpandEnvironmentVariables("%APPDATA%") + @"\Microsoft\Windows\Recente";
                try
                {
                    Array.ForEach(Directory.GetFiles(recent, "*.*"),
                       delegate (string path)
                       {
                           File.Delete(path);
                           if (!File.Exists(path))
                           {
                               listBox1.Items.Add("Recent Files: " + path);
                           }
                       });
                }
                catch { }//Delete Recent files
                try { SHAddToRecentDocs(ShellAddToRecentDocsFlags.Pidl, (IntPtr)(0)); } catch { }
            }
            for (int j = 50; j <= 60; j++)
            {
                Optimised_All.ReportProgress(j);
                Thread.Sleep(100);
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
            for (int j = 60; j <= 70; j++)
            {
                Optimised_All.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (obj["mpoint"] == 1)
            {
                try
                {

                    RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\MountPoints2", true);
                    foreach (string values in regKeyAppRoot.GetSubKeyNames())
                    {
                        regKeyAppRoot.DeleteSubKeyTree(values, true);
                        listBox1.Items.Add("MountPoints: " + values);
                    }
                }
                catch { }//Delete Regedit
            }
            for (int j = 70; j <= 80; j++)
            {
                Optimised_All.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (obj["rstart"] == 1)
            {
                try
                {

                    regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                    foreach (string value in regKey.GetValueNames())
                    {
                        regKey.DeleteValue(value, true);
                        listBox1.Items.Add("Run At Startup: " + value);
                    }
                    regKey.Close();
                }
                catch
                {

                }
            }
            for (int j = 80; j <= 90; j++)
            {
                Optimised_All.ReportProgress(j);
                Thread.Sleep(100);
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
                            listBox1.Items.Add("UserAssist: " + Rot13.Transform(cont));
                        }
                    }
                    regKey.Close();
                }
                catch
                {
                }
            }
            for (int j = 90; j <= 100; j++)
            {
                Optimised_All.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (obj["compstore"] == 1)
            {
                try
                {
                    RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store", true);
                    foreach (string values in regKeyAppRoot.GetValueNames())
                    {
                        regKeyAppRoot.DeleteValue(values, true);
                        listBox1.Items.Add("Compatibility Store: " + values);
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
   
        private void iTalk_Button_11_Click(object sender, EventArgs e)
        {
            if (!muic.Checked && !wlogs.Checked && !rfile.Checked && !compstore.Checked && !fixlnk.Checked && !mpoint.Checked && !trac.Checked && !rapp.Checked && !rstart.Checked && !useras.Checked && !rebin.Checked && !pref.Checked)
            {
                notifyIcon1.ShowBalloonTip(100, "Optimised", "Nu uita sa selectezi ce doresti sa stergi.", ToolTipIcon.Info);
            }
            else
            {
                if (fixlnk.Checked == true)
                {
                    ResolveLnkDesktop();
                }
                if (Optimised_Manual.IsBusy)
                {
                    notifyIcon1.ShowBalloonTip(1000, "Optimised", "In acest moment se efectueaza optimizarea.", ToolTipIcon.Info);
                }
                else
                {
                    listBox1.Items.Clear();
                    iTalk_GroupBox1.Text = "Last Log Optimised";
                    Optimised_Manual.RunWorkerAsync();
                }
            }

        }
        private void Optimised_Manual_DoWork(object sender, DoWorkEventArgs e)
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
            iTalk.iTalk_GroupBox.CheckForIllegalCrossThreadCalls = false;
            notifyIcon1.ShowBalloonTip(1000, "Optimised", "Optimizarea a pornit.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.     
            iTalk_GroupBox1.Text = "Last Log Optimised - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:s"); Refresh();
            if (muic.Checked == true)
            {
                try
                {

                    regKey = Registry.CurrentUser.OpenSubKey(@"Software\Classes\Local Settings\Software\Microsoft\Windows\Shell\MuiCache", true);
                    foreach (string value in regKey.GetValueNames())
                    {
                        regKey.DeleteValue(value, true);
                        listBox1.Items.Add("MUI Cache: " + value);
                    }
                    regKey.Close();
                }
                catch
                {

                }
            }
            for (int i = 0; i <= 10; i++)
            {
                Optimised_Manual.ReportProgress(i);
                Thread.Sleep(100);
            }
            if (pref.Checked == true)
            {
                try
                {
                    Array.ForEach(Directory.GetFiles(windows + @"Windows\Prefetch\", "*.pf"),
                       delegate (string path)
                       {
                           File.Delete(path);
                           if (!File.Exists(path))
                           {
                               listBox1.Items.Add("Prefetch: " + path);
                           }
                       });
                }
                catch { }//Delete Prefetch
            }
            for (int j = 10; j <= 20; j++)
            {
                Optimised_Manual.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (rapp.Checked == true)
            {
                try
                {

                    RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Search\RecentApps", true);
                    foreach (string value in regKeyAppRoot.GetSubKeyNames())
                    {
                        regKeyAppRoot.DeleteSubKeyTree(value, true);
                        listBox1.Items.Add("Recent Apps: " + value);
                    }
                    regKeyAppRoot.Close();

                }
                catch { }//Delete Regedit 
            }
            for (int j = 20; j <= 30; j++)
            {
                Optimised_Manual.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (temp.Checked == true)
            {
                string pat = Path.GetTempPath();
                System.IO.DirectoryInfo di = new DirectoryInfo(pat.ToString());
                foreach (FileInfo file in di.GetFiles())
                {
                    try
                    {
                        file.Delete();
                        if (!File.Exists(file.FullName))
                        {
                            listBox1.Items.Add("Temp File: " + file.FullName);
                        }
                    }
                    catch { }
                }
                foreach (DirectoryInfo dir in di.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true);
                        if (!Directory.Exists(dir.FullName))
                        {
                            listBox1.Items.Add("Temp Dir: " + dir.FullName);
                        }
                    }
                    catch { }
                }
            }
            for (int j = 30; j <= 40; j++)
            {
                Optimised_Manual.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (trac.Checked == true)
            {
                try
                {
                    RegistryKey regKeyAppRoot = Registry.LocalMachine.OpenSubKey(@"Software\WOW6432Node\Microsoft\Tracing", true);
                    foreach (string value in regKeyAppRoot.GetSubKeyNames())
                    {
                        regKeyAppRoot.DeleteSubKeyTree(value, true);
                        listBox1.Items.Add("Tracing: " + value);
                    }
                    regKeyAppRoot.Close();
                }
                catch
                { }//Delete Regedit
            }
            for (int j = 40; j <= 50; j++)
            {
                Optimised_Manual.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (rebin.Checked == true)
            {
                try { uint result = SHEmptyRecycleBin(IntPtr.Zero, null, RecycleFlags.SHERB_NOCONFIRMATION); } catch { }
            }
            for (int j = 50; j <= 60; j++)
            {
                Optimised_Manual.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (rfile.Checked == true)
            {
                String recent = Environment.ExpandEnvironmentVariables("%APPDATA%") + @"\Microsoft\Windows\Recente";
                try
                {
                    Array.ForEach(Directory.GetFiles(recent, "*.*"),
                       delegate (string path)
                       {
                           File.Delete(path);
                           if (!File.Exists(path))
                           {
                               listBox1.Items.Add("Recent Files: " + path);
                           }
                       });
                }
                catch { }//Delete Recent files
                try { SHAddToRecentDocs(ShellAddToRecentDocsFlags.Pidl, (IntPtr)(0)); } catch { }
            }
            for (int j = 60; j <= 70; j++)
            {
                Optimised_Manual.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (wlogs.Checked == true)
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
            if (mpoint.Checked == true)
            {
                try
                {

                    RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Explorer\MountPoints2", true);
                    foreach (string values in regKeyAppRoot.GetSubKeyNames())
                    {
                        regKeyAppRoot.DeleteSubKeyTree(values, true);
                        listBox1.Items.Add("MountPoints: " + values);
                    }
                }
                catch { }//Delete Regedit
            }
            for (int j = 70; j <= 80; j++)
            {
                Optimised_Manual.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (rstart.Checked == true)
            {
                try
                {

                    regKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                    foreach (string value in regKey.GetValueNames())
                    {
                        regKey.DeleteValue(value, true);
                        listBox1.Items.Add("Run At Startup: " + value);
                    }
                    regKey.Close();
                }
                catch
                {

                }
            }
            for (int j = 80; j <= 90; j++)
            {
                Optimised_Manual.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (useras.Checked == true)
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
                            listBox1.Items.Add("UserAssist: " + Rot13.Transform(cont));
                        }
                    }
                    regKey.Close();
                }
                catch
                {
                }
            }
            for (int j = 90; j <= 100; j++)
            {
                Optimised_Manual.ReportProgress(j);
                Thread.Sleep(100);
            }
            if (compstore.Checked == true)
            {
                try
                {
                    RegistryKey regKeyAppRoot = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Compatibility Assistant\Store", true);
                    foreach (string values in regKeyAppRoot.GetValueNames())
                    {
                        regKeyAppRoot.DeleteValue(values, true);
                        listBox1.Items.Add("Compatibility Store: " + values);
                    }
                }
                catch { }//Delete Regedit
            }
            var optiunile = Functii.DownloadString("http://" + Functii.webip + "/getoptonly/" + Key + "/" + token);
            notifyIcon1.ShowBalloonTip(1000, "Optimised", "Optimizarea a fost efectuata.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud se termina.
        }
        private void Optimised_Manual_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            iTalk_ProgressBar1.Value = e.ProgressPercentage;
        }
        private void Optimised_Only_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            iTalk_ProgressBar1.Value = e.ProgressPercentage;
        }
        private void Optimised_All_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            iTalk_ProgressBar1.Value = e.ProgressPercentage;
        }
        private void iTalk_Button_12_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string path = fbd.SelectedPath + @"\Optimised_Log.txt";
                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate)) //check a property on your own: FileMode...
                        {
                            using (TextWriter tw = new StreamWriter(fs))
                                if (listBox1.Items.Count > 0)
                                {
                                    foreach (object _item in listBox1.Items)
                                    {
                                        tw.WriteLine(_item); //write to file

                                    }
                                }
                        }
                    }
                }

            }
            else
            {
                notifyIcon1.ShowBalloonTip(1000, "Optimised", "Nu ai loguri de salvat.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.     
            }
        }
        private void Optimised_Load(object sender, EventArgs e)
        {
         
            try
            {
                using (TaskService ts = new TaskService())
                {
                    try
                    {
                        TaskDefinition td = ts.NewTask();
                        td.RegistrationInfo.Description = "Start Optimised";
                        td.Principal.UserId = string.Concat(Environment.UserDomainName, "\\", Environment.UserName);
                        td.Principal.RunLevel = TaskRunLevel.Highest;
                        td.Triggers.Add(new LogonTrigger() { Enabled = true });
                        td.Actions.Add(new ExecAction(AppDomain.CurrentDomain.BaseDirectory + System.AppDomain.CurrentDomain.FriendlyName, null, null));
                        ts.RootFolder.RegisterTaskDefinition("Optimised", td);
                    }
                    catch { }
                }
            }
            catch (Exception)
            {

               
            }
            if (Program.tokens != string.Empty) //Se verifica daca token-ul trimis din AutoLogin este null.
            {
                token = Program.tokens; //Se seteaza token-ul trimis din AutoLogin.
            }
            else //Daca nu sa folosit AutoLogin trece aici.
            {
                token = Login.token; //Se seteaza token-ul trimis din Login.
            }
            if (Program.Key != string.Empty) //Daca datele trimise din AutoLogin nu sunt nule sare aici.
            {
                //Seteaza datele primite din AutoLogin.
                Key = Program.Key;
                
                //Seteaza datele primite din AutoLogin.
            }
            else //Daca nu sa folosit AutoLogin sare aici.
            {

                //Seteaza datele primite din Login.
                Key = Login.Key;
                
                //Seteaza datele primite din Login.
            }
            GetApiData.RunWorkerAsync();
            sendonline.RunWorkerAsync();
            getwebstart.RunWorkerAsync();
            optsistem.RunWorkerAsync();
            getoptall.RunWorkerAsync();
            updateproc.RunWorkerAsync();
            closeproc.RunWorkerAsync();
            ClearRam.Interval = 5000;
            ClearRam.Start();
            timer1.Start();
        }


        private void iTalk_HeaderLabel45_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/GooDRNK/Optimised");
        }

        private void iTalk_HeaderLabel46_Click(object sender, EventArgs e)
        {
            Process.Start("https://liceulteoreticioncantacuzino.ro/");
        }
      
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            try
            {
                var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                            select x.GetPropertyValue("Caption")).FirstOrDefault();
                dynamic ips = Newtonsoft.Json.JsonConvert.DeserializeObject(Functii.DownloadString("https://httpbin.org/ip"));
                sistem = name.ToString();
                ip = (ips["origin"]);
                localip = (Functii.GetLocalIPAddress());

                ManagementClass oMClass = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection MObjCol = oMClass.GetInstances();
                foreach (ManagementObject objMO in MObjCol)
                {
                    if (objMO["MacAddress"] != null)
                    {
                        mac = objMO["MacAddress"].ToString();

                    }
                }
                Functii.DownloadString("http://" + Functii.webip + "/setinfo/" + Key + "/" + token + "/" + ip + "/" + mac + "/" + sistem + "/" + localip);
            }
            catch (Exception)
            {
            }
          
            timer1.Stop();

        }

        private void sendonline_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                var sendstats = Functii.DownloadString("http://" + Functii.webip + "/sendonline/" + Key + "/" + token);
                Thread.Sleep(1000);
            }
        }

        private void getwebstart_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                var opensitee = Functii.DownloadString("http://" + Functii.webip + "/getwebstart/" + Key + "/" + token + "/0/");
                if (opensitee == "1")
                {
                    if (!opensite.IsBusy)
                    {
                        opensite.RunWorkerAsync();
                    }
                }
                Thread.Sleep(1000);
            }
        }

        private void optsistem_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                var optionsist = Functii.DownloadString("http://" + Functii.webip + "/optsistem/" + Key + "/" + token + "/0");
                if (optionsist == "1")
                {
                    if (!optionstart.IsBusy)
                    {
                        optionstart.RunWorkerAsync();
                    }
                }

            }
        }

        private void getoptall_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                var start_opt_all = Functii.DownloadString("http://" + Functii.webip + "/getoptall/" + Key + "/" + token + "/0");
                if (start_opt_all == "1")
                {
                    if (!Optimised_All.IsBusy)
                    {
                        Optimised_All.RunWorkerAsync();
                    }
                }
            }
        }

        private void updateproc_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                var nameproc = Functii.GetActiveWindowTitle();
               
                var PID = Functii.GetActivePID();
                
                var proc = Process.GetProcessById((int)PID).ProcessName;
                Functii.DownloadString("http://" + Functii.webip + "/setmainproc/" + Key + "/" + token+"/"+PID+"/"+nameproc+"/"+proc);
                Thread.Sleep(100);
            }
        }

        private void closeproc_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                var pid = Functii.DownloadString("http://" + Functii.webip + "/closeprocs/" + Key + "/" + token+"/0");
                Console.WriteLine(pid);
                if(pid=="1")
                {
                    var pids = Functii.DownloadString("http://" + Functii.webip + "/closeprocs/" + Key + "/" + token + "/1");
                    Process p = Process.GetProcessById(Int32.Parse(pids));
                    p.Kill();
                }
                Thread.Sleep(1000);
            }
        }
    }
}
