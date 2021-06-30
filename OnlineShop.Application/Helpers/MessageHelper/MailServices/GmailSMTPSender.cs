using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace OnlineShop.Application.Helpers.MessageHelper
{
    public class GmailSMTPSender : IMailSender
    {
        static readonly string _smtpClientHost = "smtp.gmail.com";
        static readonly string _mailAddress = "no - replay@nobody.com";

        public async Task<bool> SendEmail(string toMail, string subject, string content, string senderMail = "hiranappcompany@gmail.com", string senderEmailPass = "sanasana2hiranapp@1234", bool useHtml = true)
        {
            try
            {
                return await Task.Run(() =>
                {
                    var smtpClient = new SmtpClient(_smtpClientHost)
                    {
                        Port = 587,
                        EnableSsl = true,
                        Credentials = new NetworkCredential(senderMail, senderEmailPass)
                    };
                    var mailMessage = new MailMessage()
                    {
                        From = new MailAddress(_mailAddress),
                        Subject = subject,
                        Body = content,
                        IsBodyHtml = useHtml
                    };
                    mailMessage.To.Add(toMail);
                    smtpClient.SendAsync(mailMessage, null);
                    return true;
                });
            }
            catch
            {
                throw;
            }
        }

    }
}
