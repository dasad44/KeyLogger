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
using System.Timers;

namespace WpfApplication8
{
    public partial class MainWindow : Window
    {
        Timer timer = new Timer(60000);
        timer.
        bool condition = false;                                         //variables and importants actions
        StreamWriter file = new StreamWriter(@"SochiKeyLog.txt");
        /// <summary>
        /// 
        /// </summary>
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
          public void Save_With_Big_Letters(string key)
          {
              switch (key)
              {
                  case "OemMinus":
                      file.Write("_");
                      break;
                  case "D0":
                      file.Write(")");
                      break;
                  case "D1":
                      file.Write("!");
                      break;
                  case "D2":
                      file.Write("@");
                      break;
                  case "D3":
                      file.Write("#");
                      break;
                  case "D4":
                      file.Write("$");
                      break;
                  case "D5":
                      file.Write("%");
                      break;
                  case "D6":
                      file.Write("^");
                      break;
                  case "D7":
                      file.Write("&");
                      break;
                  case "D8":
                      file.Write("*");
                      break;
                  case "D9":
                      file.Write("(");
                      break;
                  case "OemPlus":
                      file.Write("+");
                      break;
                  case "back":
                      file.Write("BACKSPACE");
                      break;
                  case "Divide":
                      file.Write("/");
                      break;
                  case "Multiply":
                      file.Write("*");
                      break;
                  case "Subtract":
                      file.Write("-");
                      break;
                  case "Oem3":
                      file.Write("~");
                      break;
                  case "tab":
                      file.Write("TAB");
                      break;
                  case "OemOpenBrackets":
                      file.Write("{");
                      break;
                  case "Oem6":
                      file.Write("}");
                      break;
                  case "Oem5":
                      file.Write("|");
                      break;
                  case "Add":
                      file.Write("+");
                      break;
                  case "Oem1":
                      file.Write(":");
                      break;
                  case "OemQuotes":
                      file.Write("\"");
                      break;
                  case "OemComma":
                      file.Write("<");
                      break;
                  case "OemPeriod":
                      file.Write(">");
                      break;
                  case "Decimal":
                      file.Write(",");
                      break;
                  case "OemQuestion":
                      file.Write("?");
                      break;
                  default:
                      file.Write(Convert.ToString(key));
                      break;
              }
          }
          public void Save_With_Small_Letters(string key)
          {
         // file.Write(letter.ToString().ToLower());
            switch (key.ToLower())
            {
                case "oemminus":
                    file.Write("-");
                    break;
                case "d0":
                    file.Write("0");
                    break;
                case "d1":
                    file.Write("1");
                    break;
                case "d2":
                    file.Write("2");
                    break;
                case "d3":
                    file.Write("3");
                    break;
                case "d4":
                    file.Write("4");
                    break;
                case "d5":
                    file.Write("5");
                    break;
                case "d6":
                    file.Write("6");
                    break;
                case "d7":
                    file.Write("7");
                    break;
                case "d8":
                    file.Write("8");
                    break;
                case "d9":
                    file.Write("9");
                    break;
                case "oemplus":
                    file.Write("=");
                    break;
                case "back":
                    file.Write("BACKSPACE");
                    break;
                case "divide":
                    file.Write("/");
                    break;
                case "multiply":
                    file.Write("*");
                    break;
                case "subtract":
                    file.Write("-");
                    break;
                case "oem3":
                    file.Write("`");
                    break;
                case "tab":
                    file.Write("TAB");
                    break;
                case "oemopenbrackets":
                    file.Write("[");
                    break;
                case "oem6":
                    file.Write("]");
                    break;
                case "oem5":
                    file.Write("\\");
                    break;
                case "add":
                    file.Write("+");
                    break;
                case "oem1":
                    file.Write(";");
                    break;
                case "oemquotes":
                    file.Write("'");
                    break;
                case "oemcomma":
                    file.Write(",");
                    break;
                case "oemperiod":
                    file.Write(".");
                    break;
                case "decimal":
                    file.Write(",");
                    break;
                case "oemquestion":
                    file.Write("/");
                    break;
                default:
                    file.Write(Convert.ToString(key).ToLower());
                    break;
            }
        }

    }
}


