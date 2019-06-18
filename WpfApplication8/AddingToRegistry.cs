using Microsoft.Win32;
using System.IO;

namespace WpfApplication8
{
    class AddingToRegistry
    {
        RegistryKey reg;
        public void AddToRegistry()
        {
            reg = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            reg.SetValue("rtx32", Path.GetFullPath("WpfApplication8.exe"));
        }
        public void RemoveFromRegistry()
        {
            reg.Close();
        }
    }
}
