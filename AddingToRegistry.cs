using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication8
{
    class AddingToRegistry
    {
        RegistryKey rk;
        string AppName;
        public AddingToRegistry(string AppName)
        {
            rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            this.AppName = AppName;
        } 
        public void AddToRegistry()
        {
            rk.SetValue(AppName, System.Reflection.Assembly.GetEntryAssembly().Location);
        }
        public void RemoveFromRegistry()
        {
            rk.DeleteValue(AppName, false);
        }
    }
}
