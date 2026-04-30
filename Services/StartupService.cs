using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;

namespace Kil0bitSystemMonitor.Services
{
    public static class StartupService
    {
        private const string AppName = "Kil0bitSystemMonitor";
        private const string RunKey = @"Software\Microsoft\Windows\CurrentVersion\Run";

        public static void SetStartup(bool enable)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RunKey, true)!)
                {
                    if (enable)
                    {
                        string appPath = ProcessPath ?? Environment.ProcessPath ?? "";
                        if (!string.IsNullOrEmpty(appPath))
                        {
                            key.SetValue(AppName, $"\"{appPath}\" --startup");
                        }
                    }
                    else
                    {
                        key.DeleteValue(AppName, false);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[StartupService] Failed to {(enable ? "enable" : "disable")} startup registration: {ex}");
            }
        }

        private static string? ProcessPath => System.Diagnostics.Process.GetCurrentProcess().MainModule?.FileName;
    }
}
