using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RunAsRenamer
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                if (!new WindowsPrincipal(identity).IsInRole(WindowsBuiltInRole.Administrator))
                {
                    MessageBox.Show(@"Please run program with administrator rights!");
                    Environment.Exit(1);
                }
            }
            InitializeComponent();
        }

        private void OnForm_Load(Object sender, EventArgs e)
        {
            CenterToScreen();
            runAsAdministratorNameTextBox.Text = GetAdministratorRegistry()[0];
            runAsAdministratorIconTextBox.Text = GetAdministratorRegistry()[1];
            runAsSystemNameTextBox.Text = GetSystemRegistry()[0];
            runAsSystemIconTextBox.Text = GetSystemRegistry()[1];
        }

        private void OnRunAsSystemCheckBox_CheckChange(Object sender, EventArgs e)
        {
            if (runAsSystemCheckBox.Checked)
            {
                runAsSystemNameTextBox.Enabled = true;
                runAsSystemIconTextBox.Enabled = true;
                runAsSystemFileDialogButton.Enabled = true;
                return;
            }
            runAsSystemNameTextBox.Enabled = false;
            runAsSystemIconTextBox.Enabled = false;
            runAsSystemFileDialogButton.Enabled = false;
        }

        private void CheckFileExists(Object sender, EventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            textBox.BackColor = !File.Exists(textBox.Text) || Path.GetExtension(textBox.Text) != ".ico" ? Color.IndianRed : Color.White;
        }
        
        private const String IcoDirectory = @"C:\Windows\CustomICO";
        private void OnApplyButton_Click(Object sender, EventArgs e)
        {
            if (runAsSystemCheckBox.Checked)
            {
                PsExecInstaller.Install();
            }
            else
            {
                PsExecInstaller.Uninstall();
            }

            if (runAsAdministratorNameTextBox.Text.Length < 1 || runAsAdministratorIconTextBox.Text.Length < 1 ||
                runAsSystemCheckBox.Checked &&
                (runAsSystemNameTextBox.Text.Length < 1 || runAsSystemIconTextBox.Text.Length < 1))
            {
                MessageBox.Show(@"Some of text lines is empty!");
                return;
            }

            if (!File.Exists(runAsAdministratorIconTextBox.Text) ||
                runAsSystemCheckBox.Checked && !File.Exists(runAsSystemIconTextBox.Text))
            {
                MessageBox.Show(@"Invalid icon` path!");
                return;
            }

            if (Path.GetExtension(runAsAdministratorIconTextBox.Text) != @".ico" ||
                runAsSystemCheckBox.Checked && Path.GetExtension(runAsSystemIconTextBox.Text) != @".ico")
            {
                MessageBox.Show(@"Path not contain icon!");
                return;
            }

            
            Directory.CreateDirectory(IcoDirectory);
            File.Copy(runAsAdministratorIconTextBox.Text, Path.Combine(IcoDirectory, @"Administrator\Administrator.ico"));
            if (runAsSystemCheckBox.Checked)
            {
                File.Copy(runAsSystemIconTextBox.Text, Path.Combine(IcoDirectory, @"System\System.ico"));
            }

            InstallAdministratorRegistry();
            if (runAsSystemCheckBox.Checked)
            {
                InstallSystemRegistry();
            }
            else
            {
                RemoveSystemRegistry();
            }

            RestartExplorer();
        }

        private void OnResetButton_Click(Object sender, EventArgs e)
        {
            RemoveAdministratorRegistry();
            RemoveSystemRegistry();
            RestartExplorer();
        }
        
        private static void RestartExplorer()
        {
            foreach (Process p in Process.GetProcessesByName("explorer.exe"))
            {
                // In case we get Access Denied
                try
                {
                    if (p.MainModule == null || !p.MainModule.FileName.ToLower().EndsWith(":\\windows\\explorer.exe"))
                    {
                        continue;
                    }

                    p.Kill();
                    break;
                }
                catch (Exception e)
                {
                    // ignored
                }
            }
            Boolean contain = false;
            foreach (Process p in Process.GetProcessesByName("explorer.exe"))
            {
                // In case we get Access Denied
                try
                {
                    if (p.MainModule == null || !p.MainModule.FileName.ToLower().EndsWith(":\\windows\\explorer.exe"))
                    {
                        continue;
                    }

                    contain = true;
                    break;
                }
                catch (Exception e)
                {
                    // ignored
                }
            }

            if (contain)
            {
                Process.Start("explorer.exe");
            }
        }
        
        private readonly RegistryKey defaultKey =
                Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\exefile\shell");

        private String[] GetAdministratorRegistry()
        {
            String[] arr = new String[2];
            RegistryKey administratorKey = defaultKey?.OpenSubKey("runas");
            try
            {
                arr[0] = administratorKey?.GetValue("")?.ToString() ?? "";
            }
            catch
            {
                // ignored
            }
            try
            {
                arr[1] = administratorKey?.GetValue("icon")?.ToString() ?? "";
            }
            catch
            {
                // ignored
            }

            return arr;
        }
        
        private String[] GetSystemRegistry()
        {
            String[] arr = new String[2];
            RegistryKey systemKey = defaultKey?.OpenSubKey("runassystem");
            if (systemKey != null)
            {
                runAsSystemCheckBox.Checked = true;
            }
            try
            {
                arr[0] = systemKey?.GetValue("")?.ToString() ?? "";
            }
            catch
            {
                // ignored
            }
            try
            {
                arr[1] = systemKey?.GetValue("icon")?.ToString() ?? "";
            }
            catch
            {
                // ignored
            }

            return arr;
        }
        
        private void InstallAdministratorRegistry()
        {
            RegistryKey administratorKey = defaultKey?.CreateSubKey("runas");
            try
            {
                administratorKey?.SetValue("", runAsAdministratorNameTextBox.Text);
            }
            catch
            {
                // ignored
            }
            try
            {
                administratorKey?.SetValue("icon", Path.Combine(IcoDirectory, @"Administrator\Administrator.ico"));
            }
            catch
            {
                // ignored
            }
            administratorKey?.Close();
        }

        private void RemoveAdministratorRegistry()
        {
            RegistryKey administratorKey = defaultKey?.CreateSubKey("runas");
            try
            {
                administratorKey?.SetValue("", "");
            }
            catch
            {
                // ignored
            }
            try
            {
                administratorKey?.DeleteValue("icon");
            }
            catch
            {
                // ignored
            }
            administratorKey?.Close();
        }

        private void InstallSystemRegistry()
        {
            RegistryKey systemKey = defaultKey?.CreateSubKey("runassystem");
            RegistryKey systemKeyCommand = systemKey?.CreateSubKey("command");
            try
            {
                systemKey?.SetValue("", runAsSystemNameTextBox.Text);
            }
            catch
            {
                // ignored
            }
            try
            {
                systemKey?.SetValue("icon", Path.Combine(IcoDirectory, @"System\System.ico"));
            }
            catch
            {
                // ignored
            }
            try
            {
                systemKeyCommand?.SetValue("", $"C:\\Windows\\{(IntPtr.Size >= 8 ? "PsExec64.exe" : "PsExec.exe")} -d -i -s \"%1\" %*");
            }
            catch
            {
                // ignored
            }
            systemKey?.Close();
        }

        private void RemoveSystemRegistry()
        {
            try
            {
                defaultKey?.DeleteSubKey("runassystem");
            }
            catch
            {
                // ignored
            }
        }
    }
}