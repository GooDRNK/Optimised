using Microsoft.Win32;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Optimised.Program;

namespace Optimised
{
    public partial class Offline : Form
    {
        string webip = "192.168.0.135";
        public static RegistryKey regKey; //Registri key
        public static string windows = Path.GetPathRoot(Environment.SystemDirectory);
        public Offline()
        {
            InitializeComponent();

        }
        private void iTalk_Button_21_Click(object sender, EventArgs e)
        {
            notifyIcon1.Dispose();
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
                webBrowser1.Navigate("http://"+webip+"/register");
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

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {

            notifyIcon1.Dispose();
            this.Hide();
            Login log = new Login();
            log.ShowDialog();
            GClean.Stop();
            this.Close();
 
        }

        private void Offline_Resize(object sender, EventArgs e)
        {
         
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var proc = Process.GetCurrentProcess().ProcessName;
            notifyIcon1.Dispose();
            foreach (var process in Process.GetProcessesByName(proc))
            {
                process.Kill();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.Visible == true)
            {
                this.Hide();
            }
            else if (this.Visible == false)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void Offline_Load(object sender, EventArgs e)
        {
            GClean.Interval = 5000;
            GClean.Start();
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Config.ini"))
            {
                var MyIni = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"AutoLogin.ini"); //Deschide calea de scriere in fisierul AutoLogin.ini.
                var FileLog = MyIni.Read("SaveLogs");
                var StartWindows = MyIni.Read("StarWin");
                if (FileLog == "Da")
                {
                    iTalk_CheckBox1.Checked = true;
                }
                else
                {
                    iTalk_CheckBox1.Checked = false;
                }
                if (StartWindows == "Da")
                {
                    iTalk_CheckBox1.Checked = true;
                }
                else { iTalk_CheckBox1.Checked = false; }
            }
        }

        private void Offline_FormClosing(object sender, FormClosingEventArgs e)
        {
            notifyIcon1.Dispose();
            var proc = Process.GetCurrentProcess().ProcessName;
            foreach (var process in Process.GetProcessesByName(proc))
            {
                process.Kill();
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
                       delegate (string path) {
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
                       delegate (string path) {
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
            notifyIcon1.ShowBalloonTip(1000, "Optimised", "Optimizarea a fost efectuata.", ToolTipIcon.Info); //Trimite messajul primit de la actiunea trimisa din Cloud se termina.
        }
        private void Optimised_Manual_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            iTalk_ProgressBar1.Value = e.ProgressPercentage;
        }
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

        private void iTalk_CheckBox1_CheckedChanged(object sender)
        {
            if (iTalk_CheckBox1.Checked == true)
            {
                var MyIni = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"Config.ini"); //Deschide calea de scriere in fisierul AutoLogin.ini.

                MyIni.Write("StarWin", "Da");
                using (TaskService ts = new TaskService())
                {
                    try
                    {
                        TaskDefinition td = ts.NewTask();
                        td.RegistrationInfo.Description = "Start Optimised";
                        // Run Task whether user logged on or not
                        td.Principal.UserId = string.Concat(Environment.UserDomainName, "\\", Environment.UserName);
                        td.Principal.RunLevel = TaskRunLevel.Highest;
                        td.Triggers.Add(new LogonTrigger() { Enabled = true });
                        td.Actions.Add(new ExecAction(AppDomain.CurrentDomain.BaseDirectory + @"Optimised.exe", null, null));
                        ts.RootFolder.RegisterTaskDefinition("Optimised", td);
                    }
                    catch { }
                }
            }
            else
            {
                try
                {
                    var MyIni = new IniFile(AppDomain.CurrentDomain.BaseDirectory + @"Config.ini"); //Deschide calea de scriere in fisierul AutoLogin.ini.

                    MyIni.Write("StarWin", "Nu");
                    TaskService ts = new TaskService();
                    TaskDefinition td = ts.NewTask();
                    ts.RootFolder.DeleteTask("Optimised", true);
                }
                catch { }
            }
        }

        private void iTalk_HeaderLabel45_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/GooDRNK/Optimised");
        }

        private void iTalk_HeaderLabel46_Click(object sender, EventArgs e)
        {
            Process.Start("https://liceulteoreticioncantacuzino.ro/");
        }
    }
}
