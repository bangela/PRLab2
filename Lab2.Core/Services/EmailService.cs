using Lab2.Core.Interfaces;
using Lab2.Core.ViewModels;
using MailKit.Net.Pop3;
using MimeKit;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Lab2.Core.Services
{
    public class EmailService : IEmailService
    {
        private string username;
        private SmtpClient smtpClient;

        private Pop3Client pop3Client;

        public void Initialize(string username, string password)
        {
            this.username = username;
            smtpClient = new SmtpClient();
            NetworkCredential nc = new NetworkCredential(username, password);
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Credentials = nc;
            smtpClient.EnableSsl = true;

            pop3Client = new Pop3Client();
            pop3Client.Connect("pop.gmail.com", 995);
            pop3Client.Authenticate(username, password);
        }
        public void SendEmail(string to, string subject, string body)
        {
            MailAddress sendTo = new MailAddress(to);
            MailAddress from = new MailAddress(username);
            MailMessage message = new MailMessage(from, sendTo);
            message.IsBodyHtml = false;
            message.Subject = subject;
            message.Body = body;
            smtpClient.Send(message);
        }
        public List<MessageHeaderViewModel> GetInbox()
        {
            var messages = new List<MessageHeaderViewModel>();
            for (int i = 0; i < 15; i++)
            {
                var headers = pop3Client.GetMessageHeaders(i);
                var messHeader = new MessageHeaderViewModel
                {
                    Date = headers[HeaderId.Date],
                    From = headers[HeaderId.From],
                    Title = headers[HeaderId.Subject],
                    Id = i
                };
                messages.Add(messHeader);
            }
            return messages;
        }

        public void Close()
        {
            pop3Client.Disconnect(true);
            smtpClient.Dispose();
            username = null;
        }

        public MessageViewModel GetEmail(int id)
        {
            var message = pop3Client.GetMessage(id);
            return new MessageViewModel
            {
                From = message.From.ToString(),
                Body = message.TextBody,
                Title = message.Subject
            };
        }
    }
}
