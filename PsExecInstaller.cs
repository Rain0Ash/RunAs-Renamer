// This is an independent project of an individual developer. Dear PVS-Studio, please check it.
// PVS-Studio Static Code Analyzer for C, C++, C#, and Java: http://www.viva64.com

using System;
using System.IO;
using RunAsRenamer.Properties;

namespace RunAsRenamer
{
    internal static class PsExecInstaller
    {
        private const String BasePath = @"C:\Windows";
        private const String PsExecPath = BasePath + @"\PsExec";
        private const String PsExec64Path = BasePath + @"\PsExec64";
        internal static void Install()
        {
            Boolean is64Os = IntPtr.Size == 8;
            if (File.Exists(is64Os ? PsExec64Path : PsExecPath))
            {
                return;
            }

            using (FileStream stream = File.Open(is64Os ? PsExec64Path : PsExecPath, FileMode.Create,
                FileAccess.Write))
            {
                stream.Write(is64Os ? Resources.PsExec64 : Resources.PsExec, 0,
                    is64Os ? Resources.PsExec64.Length : Resources.PsExec.Length);
            }
        }

        internal static void Uninstall()
        {
            if (File.Exists(PsExecPath))
            {
                File.Delete(PsExecPath);
            }

            if (File.Exists(PsExec64Path))
            {
                File.Delete(PsExec64Path);
            }
        }
    }
}