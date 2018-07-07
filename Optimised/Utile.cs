using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Net.Sockets;
using System.Net.NetworkInformation;

namespace Optimised
{
    public class Functii
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", SetLastError = true)]
        static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        public static string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return "";
        }
        public static uint GetActivePID()
        {
         
            IntPtr handle = GetForegroundWindow();

                uint pid;
                GetWindowThreadProcessId(handle,out pid);
            
            return pid;
        }
        public static PhysicalAddress GetMacAddress()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
               
                if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet &&
                    nic.OperationalStatus == OperationalStatus.Up)
                {
                    return nic.GetPhysicalAddress();
                }
            }
            return null;
        }
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception();
        }
        public static string webip = "optimised.biz/api";
        public static bool isadmin()
        {
            WindowsIdentity da = WindowsIdentity.GetCurrent();
            WindowsPrincipal pr = new WindowsPrincipal(da);
            return pr.IsInRole(WindowsBuiltInRole.Administrator);
        }
        [DllImportAttribute("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);
        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        //Download String Start
        public static string DownloadString(string address)
        {
            try
            {
                string reply = string.Empty;
                WebClient client = new WebClient();
                reply = client.DownloadString(address);
                return reply.ToString();

            }
            catch 
            {
                return null;
            }
        }
        //Download String End
        public static string CalculateMD5Hash(string input)

        {

            MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);

            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString();

        }
        public static bool CheckForInternetConnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("http://optimised.biz"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
         
    }
    public class Thread
    {
        public delegate uint LPTHREAD_START_ROUTINE(uint lpParam);
        public const uint INFINITE = 0xFFFFFFFF;

        [DllImport("Kernel32.dll")]
        public static extern uint CreateThread(
            uint lpThreadAttributes,
            uint dwStackSize,
            LPTHREAD_START_ROUTINE lpStartAddress,
            uint lpParameter,
            uint dwCreationFlags,
            out uint lpThreadId);

        [DllImport("Kernel32.dll")]
        public static extern int CloseHandle(uint hObject);

        [DllImport("Kernel32.dll")]
        public static extern uint WaitForSingleObject(uint hHandle, uint dwMilliseconds);

        [DllImport("Kernel32.dll")]
        public static extern void Sleep(uint dwMilliseconds);
    }
    public class Shutdown
    {

        public static void Restart()
        {
            StartShutDown("-f -r -t 5");
        }


        public static void LogOff()
        {
            StartShutDown("-l");
        }


        public static void Shut()
        {
            StartShutDown("-f -s -t 5");
        }

        private static void StartShutDown(string param)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = "cmd";
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Arguments = "/C shutdown " + param;
            Process.Start(proc);
        }
    } 
    static class Rot13
    {
        public static string Transform(string value)
        {
            char[] array = value.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                int number = (int)array[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                array[i] = (char)number;
            }
            return new string(array);
        }
    }
}
