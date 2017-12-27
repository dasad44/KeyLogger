using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Reflection.Emit;
using System.Threading;
using Microsoft.Win32;

namespace Keylogger
{
    public partial class MainWindow : Window
    {
        //zmienne
        public string spi;

        public string path;
        public bool program = true;
        public string tekst;
        public string Filename;
        public string target;

        public MainWindow()
        {
            InitializeComponent();
           //Zapis();

        }


        //Tworzy plik wraz z trescia
        public void tworzenie_pliku()
        {
            if (path == null)
            {
                StreamWriter plik = new StreamWriter("keyloger.txt");
                plik.Write(tekst + "==="); //daje przerwe pomiedzy kolejnymi wpisami+ tekst z zmiennej (tekst)
                

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sdf = new SaveFileDialog();
            sdf.DefaultExt = ".txt";
            //sdf.Filter = "Text Document (.txt)/*.txt"; // pozostaje do zrozumienia
            if (sdf.ShowDialog() == true)
            {
                Filename = sdf.FileName;
                this.Dispatcher.Invoke(() => { Stdf(); });
            }
            
        }

        public void Stdf()
        { 
        Label.Content = Filename;
        }
         /*    //zmiana sciezki na podana przez uzytkownika (sdf)
        public void Zapis()
        {
            string currentDirectory = Environment.CurrentDirectory;
            Console.WriteLine("sciezka:" + currentDirectory);
            Console.ReadLine();
        } */

    }
    
}
