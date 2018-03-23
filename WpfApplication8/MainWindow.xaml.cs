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
using Microsoft.Win32;

namespace WpfApplication8
{
    public partial class MainWindow : Window
    {
        bool condition = false;                                         //variables and importants actions
        public string FileName_IN;
        public string File_Content;
        public Thread FileSave;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void Window_KeyDown(object sender, KeyEventArgs e)
        {
            string key;
            if (condition)
            {
                if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                {
                    //label.Content = Convert.ToString(e.Key);
                    key = Convert.ToString(e.Key);
                    Save_With_Big_Letters(key);
                }
                else
                {
                    key = Convert.ToString(e.Key);
                    Save_With_Small_Letters(key);
                }
            }
        }
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            condition = true;
            FileSave = new Thread(Save_Content_To_File);
            FileSave.Start();
        }
        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            condition = false;
            FileSave.Abort();
        }
        public void Window_Closing(object sender, CancelEventArgs e)
        {
            FileSave.Abort();
        }
        public void Window_Closed(object sender, EventArgs e)
        {
            FileSave.Abort();
        }
        public void Hide_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        public void Save_With_Big_Letters(string key)
        {
            switch (key)
            {
                case "OemMinus":
                    File_Content += ("_");
                    break;
                case "D0":
                    File_Content += (")");
                    break;
                case "D1":
                    File_Content += ("!");
                    break;
                case "D2":
                    File_Content += ("@");
                    break;
                case "D3":
                    File_Content += ("#");
                    break;
                case "D4":
                    File_Content += ("$");
                    break;
                case "D5":
                    File_Content += ("%");
                    break;
                case "D6":
                    File_Content += ("^");
                    break;
                case "D7":
                    File_Content += ("&");
                    break;
                case "D8":
                    File_Content += ("*");
                    break;
                case "D9":
                    File_Content += ("(");
                    break;
                case "OemPlus":
                    File_Content += ("+");
                    break;
                case "back":
                    File_Content += ("BACKSPACE");
                    break;
                case "Divide":
                    File_Content += ("/");
                    break;
                case "Multiply":
                    File_Content += ("*");
                    break;
                case "Subtract":
                    File_Content += ("-");
                    break;
                case "Oem3":
                    File_Content += ("~");
                    break;
                case "tab":
                    File_Content += ("TAB");
                    break;
                case "OemOpenBrackets":
                    File_Content += ("{");
                    break;
                case "Oem6":
                    File_Content += ("}");
                    break;
                case "Oem5":
                    File_Content += ("|");
                    break;
                case "Add":
                    File_Content += ("+");
                    break;
                case "Oem1":
                    File_Content += (":");
                    break;
                case "OemQuotes":
                    File_Content += ("\"");
                    break;
                case "OemComma":
                    File_Content += ("<");
                    break;
                case "OemPeriod":
                    File_Content += (">");
                    break;
                case "Decimal":
                    File_Content += (",");
                    break;
                case "OemQuestion":
                    File_Content += ("?");
                    break;
                default:
                    File_Content += (Convert.ToString(key));
                    break;
            }
        }
        public void Save_With_Small_Letters(string key)
        {
            // file.Write(letter.ToString().ToLower());
            switch (key.ToLower())
            {
                case "oemminus":
                    File_Content += ("-");
                    break;
                case "d0":
                    File_Content += ("0");
                    break;
                case "d1":
                    File_Content += ("1");
                    break;
                case "d2":
                    File_Content += ("2");
                    break;
                case "d3":
                    File_Content += ("3");
                    break;
                case "d4":
                    File_Content += ("4");
                    break;
                case "d5":
                    File_Content += ("5");
                    break;
                case "d6":
                    File_Content += ("6");
                    break;
                case "d7":
                    File_Content += ("7");
                    break;
                case "d8":
                    File_Content += ("8");
                    break;
                case "d9":
                    File_Content += ("9");
                    break;
                case "oemplus":
                    File_Content += ("=");
                    break;
                case "back":
                    File_Content += ("BACKSPACE");
                    break;
                case "divide":
                    File_Content += ("/");
                    break;
                case "multiply":
                    File_Content += ("*");
                    break;
                case "subtract":
                    File_Content += ("-");
                    break;
                case "oem3":
                    File_Content += ("`");
                    break;
                case "tab":
                    File_Content += ("TAB");
                    break;
                case "oemopenbrackets":
                    File_Content += ("[");
                    break;
                case "oem6":
                    File_Content += ("]");
                    break;
                case "oem5":
                    File_Content += ("\\");
                    break;
                case "add":
                    File_Content += ("+");
                    break;
                case "oem1":
                    File_Content += (";");
                    break;
                case "oemquotes":
                    File_Content += ("'");
                    break;
                case "oemcomma":
                    File_Content += (",");
                    break;
                case "oemperiod":
                    File_Content += (".");
                    break;
                case "decimal":
                    File_Content += (",");
                    break;
                case "oemquestion":
                    File_Content += ("/");
                    break;
                default:
                    File_Content += (Convert.ToString(key).ToLower());
                    break;
            }

        }
        public void Get_Save_File_Directory()
        {
            SaveFileDialog sdf = new SaveFileDialog();
            sdf.DefaultExt = ".txt";
            if (sdf.ShowDialog() == true)
            {
                FileName_IN = sdf.FileName;
            }
        }
        public void Save_Content_To_File()
        {
            while (condition)
            {
                using (StreamWriter Snd = File.CreateText(FileName_IN))
                {
                    Snd.Write(File_Content);
                    File_Content += "///.";
                    Thread.Sleep(3000);
                }
            }
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Get_Save_File_Directory();
        }
    }
}


