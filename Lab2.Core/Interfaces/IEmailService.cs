using Lab2.Core.ViewModels;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2.Core.Interfaces
{
    public interface IEmailService
    {
        void Initialize(string username, string password);

        List<MessageHeaderViewModel> GetInbox();

        void SendEmail(string to, string subject, string body);

        MessageViewModel GetEmail(int id);

        void Close();
    }
}
