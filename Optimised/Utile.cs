using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;

namespace Optimised
{
    public class Functii
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory + @"AutoLogin.ini";
        public static string reply = string.Empty;
        //Download String Start
         public static string DownloadString(string address)
        {
            try
            {

                WebClient client = new WebClient();
                reply = client.DownloadString(address);
                return reply.ToString();

            }
            catch { }
            return reply.ToString();
        }
        //Download String End
        public static string GetHashSha1(string input)
        {
            return ComputeHash(input, new SHA1Managed());
        }
        public static string ComputeHash(string input, HashAlgorithm hashProvider)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (hashProvider == null)
            {
                throw new ArgumentNullException("hashProvider");
            }

            var inputBytes = Encoding.UTF8.GetBytes(input);
            var hashBytes = hashProvider.ComputeHash(inputBytes);
            var hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

            return hash;
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
    public class IniFile
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public IniFile(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName.ToString();
        }

        public string Read(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }

        public void Write(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }

        public void DeleteKey(string Key, string Section = null)
        {
            Write(Key, null, Section ?? EXE);
        }

        public void DeleteSection(string Section = null)
        {
            Write(null, null, Section ?? EXE);
        }

        public bool KeyExists(string Key, string Section = null)
        {
            return Read(Key, Section).Length > 0;
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
    public class PerformanceInfo
    {
        [DllImport("psapi.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetPerformanceInfo([Out] out PerformanceInformation PerformanceInformation, [In] int Size);

        [StructLayout(LayoutKind.Sequential)]
        public struct PerformanceInformation
        {
            public int Size;
            public IntPtr CommitTotal;
            public IntPtr CommitLimit;
            public IntPtr CommitPeak;
            public IntPtr PhysicalTotal;
            public IntPtr PhysicalAvailable;
            public IntPtr SystemCache;
            public IntPtr KernelTotal;
            public IntPtr KernelPaged;
            public IntPtr KernelNonPaged;
            public IntPtr PageSize;
            public int HandlesCount;
            public int ProcessCount;
            public int ThreadCount;
        }

        public static Int64 GetPhysicalAvailableMemoryInMiB()
        {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
            {
                return Convert.ToInt64((pi.PhysicalAvailable.ToInt64() * pi.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }

        }

        public static Int64 GetTotalMemoryInMiB()
        {
            PerformanceInformation pi = new PerformanceInformation();
            if (GetPerformanceInfo(out pi, Marshal.SizeOf(pi)))
            {
                return Convert.ToInt64((pi.PhysicalTotal.ToInt64() * pi.PageSize.ToInt64() / 1048576));
            }
            else
            {
                return -1;
            }

        }
    }
}
