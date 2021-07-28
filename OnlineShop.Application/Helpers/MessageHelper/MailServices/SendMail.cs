using OnlineShop.Application.Helpers.MessageHelper;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OnlineShop.Application.SendMessage
{
    public class SendMail
    {
        readonly IMailSender _mailSender;
        public SendMail(IMailSender mailSender)
        {
            _mailSender = mailSender;
        }

        public async Task SendActivationCode(string activationCode, string userEmail, string domainName)
        {
                await _mailSender.SendEmail(userEmail, MailMessagesString.ActivationCode, MailMessagesString.GetActivationCodeMessage(activationCode, domainName, userEmail));
        }
    }
}
