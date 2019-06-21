using Microsoft.Win32;
using System;
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
            try                             //błąd kiedy użytkownik nie kliknie START i nie ma programu zapisanego w Rejestrze
            {
                reg.Close();                    
            }
            catch(NullReferenceException ex)
            {

            }
        }
    }
}
