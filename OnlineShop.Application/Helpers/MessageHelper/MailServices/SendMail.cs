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

        public async Task<bool> SendActivationCode(string carActivationCode, string userEmail)
        {
            try
            {
                return await _mailSender.SendEmail(userEmail, MailMessagesString.ActivationCode, MailMessagesString.GetActivationCodeMessage(carActivationCode));
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SendCarPassword(string carPassword, string userEmail)
        {
            try
            {
                return await _mailSender.SendEmail(userEmail, MailMessagesString.SendCarPassword, MailMessagesString.GetSendCarPasswordMessage(carPassword));
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SendEmailNewPassword(string userEmail, string newPassword)
        {
            try
            {
                return await _mailSender.SendEmail(userEmail, MailMessagesString.SendNewPasswordNotfication, MailMessagesString.GetSendNewPasswordNotficationMessage(newPassword));
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> SendCarNameEmail(string userEmail, string carUniquePhrase)
        {
            try
            {
                return await _mailSender.SendEmail(userEmail, MailMessagesString.SendCarNameEmail, MailMessagesString.GetSendCarNameEmailMessage(carUniquePhrase));
            }
            catch
            {
                throw;
            }
        }
    }
}
