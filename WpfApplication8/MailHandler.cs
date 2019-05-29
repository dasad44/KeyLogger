using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading;
using System.Timers;

namespace WpfApplication8
{
    class MailHandler
    {
        public void SetTimer()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer(2000);

            aTimer.Elapsed += SendMail;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void SendMail(Object source, ElapsedEventArgs e)
        {
            Console.Write("dsadsad");
        }
    }
}
