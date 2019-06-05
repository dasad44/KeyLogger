using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication8
{
    class CopyFile
    {
        string sourcePath = @"";
        string targetPath = @"C:\Users\dawidsokol\source\repos\KeyLogger\WpfApplication8\bin\Debug\";
        public void CopyTxtFile(string fileName, string targetFile)
        {
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
            string destFile = System.IO.Path.Combine(targetPath, targetFile);
            System.IO.Directory.CreateDirectory(targetPath);
            try
            {
                System.IO.File.Copy(sourceFile, destFile, true);                //bug dostęp do pliku
            }
            catch(Exception ex)
            {
                
            }

            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                foreach (string s in files)
                {
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Ścieżka źródłowa pliku nie istnieje ");
            }
        }

        public void DelFile(string fileName)
        {
            try
            {
                System.IO.File.Delete(fileName);
            }
            catch(Exception ex)
            {

            }
        }
    }
}
