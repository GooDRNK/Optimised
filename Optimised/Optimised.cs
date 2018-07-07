using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Win32.TaskScheduler;
using System.Linq;
using System.Management;
using PusherClient;
using Newtonsoft.Json;
using System.Web;
using ProjNAME;

namespace Optimised
{
    public partial class Optimised : Form
    {
      
        #region Variabile_Globale
        //Variabile Globale Start
        string Key; //Aici se salveaza Parola.
        string token; //Aici se salveaza token-ul.
        string id; //Aici se salveaza id-ul.
        string email; //Aici se salveaza email-ul.
        string statie; //Aici se salveaza numele-ul.
        public RegistryKey regKey; //Registri key
        public string windows = Path.GetPathRoot(Environment.SystemDirectory);
        public Pusher _pusher; //Pusher Init
        public Channel _MyChannel; //Channel pentru fiecare cont.
        public Channel _AccountChannel; //Channel principal al contului din cloud.
        string ip;
        string mac;
        string localip;
        string sistem;
        //Variabile Globale End
        #endregion
        #region Initializare_App
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
            if (Program.statie != string.Empty) //Se verifica daca numele-ul trimis din AutoLogin este null.
            {
                statie = Program.statie; //Se seteaza numele-ul trimis din AutoLogin.
            }
            else //Daca nu sa folosit AutoLogin trece aici.
            {
                statie = Login.statie; //Se seteaza numele-ul trimis din Login.
            }
            if (Program.tokens != string.Empty) //Se verifica daca token-ul trimis din AutoLogin este null.
            {
                token = Program.tokens; //Se seteaza token-ul trimis din AutoLogin.
            }
            else //Daca nu sa folosit AutoLogin trece aici.
            {
                token = Login.token; //Se seteaza token-ul trimis din Login.
            }

            if (Program.Email != string.Empty) //Se verifica daca Email-ul trimis din AutoLogin este null.
            {
                email = Program.Email; ; //Se seteaza Email-ul trimis din AutoLogin.
            }
            else //Daca nu sa folosit AutoLogin trece aici.
            {
                email = Login.Email; //Se seteaza Email-ul trimis din Login.
            }

            if (Program.Id != string.Empty) //Se verifica daca ID-ul trimis din AutoLogin este null.
            {
                id = Program.Id; ; //Se seteaza ID-ul trimis din AutoLogin.
            }
            else //Daca nu sa folosit AutoLogin trece aici.
            {
                id = Login.Id; //Se seteaza ID-ul trimis din Login.
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
            InitPusher();
            Online.RunWorkerAsync();
            UpdateProces.RunWorkerAsync();
            ClearRam.Interval = 5000;
            ClearRam.Start();
            SendInfo.Start();    
        }
        public Optimised()
        {
            InitializeComponent();
            SendInfo.Interval = 1000;
            SendInfo.Start();   
        }
        #endregion
        #region PusherInit
        public void InitPusher()
        {
            try
            {
                c_AntiKill c_NewAntiKill = new c_AntiKill();
                c_NewAntiKill.c_ImAntiKill();
                _pusher = new Pusher("c322190b05b7b2265d64", new PusherOptions()
                {
                   Cluster = "eu"
                });
                _AccountChannel = _pusher.Subscribe((id+email));
                _AccountChannel.Bind("OpenURL", (dynamic data) =>
                 {
                     
                     if (!OpenWebsite.IsBusy)
                     {
                         OpenWebsite.RunWorkerAsync(data);
                     }
                 });
                _AccountChannel.Bind("CleanSystem", (dynamic data) =>
                {            
                    if (!Optimised_All.IsBusy)
                    {
                        Optimised_All.RunWorkerAsync(data);
                    }
                });
                _AccountChannel.Bind("ActionWindows", (dynamic data) =>
                {
                    if (!optionstart.IsBusy)
                    {
                        optionstart.RunWorkerAsync(data);
                    }
                });

                _MyChannel = _pusher.Subscribe(Key);
                _MyChannel.Bind(Key + "CleanSystem", (dynamic data) =>
                {
                    
                    if (!Optimised_Only.IsBusy)
                    {
                        Optimised_Only.RunWorkerAsync(data);
                    }

                });
                _MyChannel.Bind(Key + "closeproc", (dynamic data) =>
                {
                   
                    if (!CloseProces.IsBusy)
                    {
                        CloseProces.RunWorkerAsync(data);
                    }
                });
                _MyChannel.Bind(Key + "OpenURL", (dynamic data) =>
                {
                    if (!OpenWebsite.IsBusy)
                    {
                        OpenWebsite.RunWorkerAsync(data);
                    }
                });
                _MyChannel.Bind(Key + "ActionWindows", (dynamic data) =>
                {
                    if (!optionstart.IsBusy)
                    {
                        optionstart.RunWorkerAsync(data);
                    }
                });
                _pusher.Connect();
         
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        #endregion
        #region Logout
        private void Optimised_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Notificare.Dispose();
            var proc = Process.GetCurrentProcess().ProcessName;
            foreach (var process in Process.GetProcessesByName(proc))
            {
                process.Kill();
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
        #region Functii
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
        private void optionstart_DoWork(object sender, DoWorkEventArgs e)
        {
            dynamic data = e.Argument;
                switch (data.action.ToString())
                {
                    case "Shutdown":
                        {
                            Notificare.ShowBalloonTip(1000, "Optimised Cloud", "Sistemul se va opri in 2 secunde.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.
                            Functii.DownloadString("http://" + Functii.webip + "/notify/" + Key + "/" + token + "/shutdown/");
                            Thread.Sleep(2000);
                            Shutdown.Shut();
                            break;
                        }
                    case "Restart":
                        {
                            Notificare.ShowBalloonTip(1000, "Optimised Cloud", "Sistemul se va reseta in 2 secunde.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.
                            Functii.DownloadString("http://" + Functii.webip + "/notify/" + Key + "/" + token + "/restart/");
                            Thread.Sleep(2000);
                            Shutdown.Restart();
                            break;
                        }
                    default:
                        break;
                }
            
        }
        private void opensite_DoWork(object sender, DoWorkEventArgs e)
        {
            dynamic data = e.Argument;
            if (data.url != null)
            {
                Process.Start(data.url.ToString()); //Porneste site-ul trimis din cloud.
                Notificare.ShowBalloonTip(1000, "Optimised Cloud", "Site-ul: " + data.url + " a pornit.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.           
                Functii.DownloadString("http://" + Functii.webip + "/notify/" + Key + "/" + token + "/site/"+ Functii.Base64Encode(data.url.ToString()));
            }
        }
        private void Optimised_Only_DoWork(object sender, DoWorkEventArgs e)
        {
            ListBox.CheckForIllegalCrossThreadCalls = false;
            iTalk.iTalk_GroupBox.CheckForIllegalCrossThreadCalls = false;
            iTalk_GroupBox1.Text = "Last Log Optimised Cloud - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:s"); Refresh();
            Notificare.ShowBalloonTip(1000, "Optimised Cloud", "Optimizarea trimisa din cloud exclusiv tie a pornit.", ToolTipIcon.Info);
            dynamic obj = (dynamic)e.Argument;
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
            Notificare.ShowBalloonTip(1000, "Optimised Cloud End", "Optimizarea trimisa din cloud exclusiv tie a fost efectuata.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud se termina.
            Functii.DownloadString("http://" + Functii.webip + "/notify/" + Key + "/" + token + "/only/");
        }
        private void Optimised_All_DoWork(object sender, DoWorkEventArgs e)
        {        
            ListBox.CheckForIllegalCrossThreadCalls = false;
            iTalk.iTalk_GroupBox.CheckForIllegalCrossThreadCalls = false;
            iTalk_GroupBox1.Text = "Last Log Optimised Cloud - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:s"); Refresh();
            Notificare.ShowBalloonTip(1000, "Optimised Cloud", "Optimizarea trimisa din cloud pentru toti utilizatorii a inceput.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.
            dynamic obj = (dynamic)e.Argument;
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
            Notificare.ShowBalloonTip(1000, "Optimised Cloud End", "Optimizarea trimisa din cloud pentru toti utilizatorii a fost efectuata.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud se termina.
            Functii.DownloadString("http://" + Functii.webip + "/notify/" + Key + "/" + token + "/all/");
        }
        private void ClearRam_Tick(object sender, EventArgs e)
        {
            Functii.FlushMemory(); //Elibereaza memoria din program.
        }
        private void iTalk_Button_11_Click(object sender, EventArgs e)
        {
            if (!muic.Checked && !wlogs.Checked && !rfile.Checked && !compstore.Checked && !fixlnk.Checked && !mpoint.Checked && !trac.Checked && !rapp.Checked && !rstart.Checked && !useras.Checked && !rebin.Checked && !pref.Checked)
            {
                Notificare.ShowBalloonTip(100, "Optimised", "Nu uita sa selectezi ce doresti sa stergi.", ToolTipIcon.Info);
            }
            else
            {
                if (fixlnk.Checked == true)
                {
                    ResolveLnkDesktop();
                }
                if (Optimised_Manual.IsBusy)
                {
                    Notificare.ShowBalloonTip(1000, "Optimised", "In acest moment se efectueaza optimizarea.", ToolTipIcon.Info);
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
            Notificare.ShowBalloonTip(1000, "Optimised", "Optimizarea a pornit.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.     
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
            Notificare.ShowBalloonTip(1000, "Optimised", "Optimizarea a fost efectuata.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud se termina.
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
                        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                        {
                            using (TextWriter tw = new StreamWriter(fs))
                                if (listBox1.Items.Count > 0)
                                {
                                    foreach (object _item in listBox1.Items)
                                    {
                                        tw.WriteLine(_item); //scrie in fisier

                                    }
                                }
                        }
                    }
                }

            }
            else
            {
                Notificare.ShowBalloonTip(1000, "Optimised", "Nu ai loguri de salvat.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud.     
            }
        }
       
        private void SendInfo_Tick(object sender, EventArgs e)
        {
            dynamic ips=null;
            this.Hide();
            try
            {
                var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                            select x.GetPropertyValue("Caption")).FirstOrDefault();
                while(name==null)
                {
                   
                    name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                            select x.GetPropertyValue("Caption")).FirstOrDefault();
                }
                var dataip = Functii.DownloadString("https://httpbin.org/ip");
                
                if(dataip != null)
                {
                  ips= Newtonsoft.Json.JsonConvert.DeserializeObject(dataip);
                }
               
                sistem = name.ToString();
                if (ips != null)
                {
                    ip = (ips["origin"]);
                }
                else
                {
                    ip = "Error!";
                }
                
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            SendInfo.Stop();
        }
        private void sendonline_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                var sendstats = Functii.DownloadString("http://" + Functii.webip + "/sendonline/" + Key + "/" + token);
                Thread.Sleep(10000);
            }
        }
        private void closeproc_DoWork(object sender, DoWorkEventArgs e)
        {
            dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(e.Argument.ToString());
            Process p = Process.GetProcessById(Int32.Parse((string)(data.pid)));
            var proc = Process.GetProcessById((int)data.pid).ProcessName;
            p.Kill();
            Functii.DownloadString("http://" + Functii.webip + "/notify/" + Key + "/" + token + "/close/"+proc);
        }
        private void UpdateProces_DoWork(object sender, DoWorkEventArgs e)
        {
            int lastPID=-1;
            string lastPROC = "";
            while (true)
            {
                var nameproc = Functii.GetActiveWindowTitle();
                var PID = Functii.GetActivePID();
                var proc = Process.GetProcessById((int)PID).ProcessName;
                if(lastPID != (int)PID || lastPROC!= nameproc)
                {
                    Functii.DownloadString("http://" + Functii.webip + "/setmainproc/" + Key + "/" + token + "/" + PID + "/" + nameproc + "/" + proc);
                    lastPID = (int)PID;
                }
                Thread.Sleep(5000);
            }
        }
        #endregion
    }
}
