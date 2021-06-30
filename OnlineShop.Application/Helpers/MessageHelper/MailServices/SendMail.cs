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

        public async Task<bool> SendActivationCode(string carActivationCode, string userEmail, string domainName)
        {
            try
            {
                return await _mailSender.SendEmail(userEmail, MailMessagesString.ActivationCode, MailMessagesString.GetActivationCodeMessage(carActivationCode, domainName));
            }
            catch
            {
                throw;
            }
        }
    }
}
