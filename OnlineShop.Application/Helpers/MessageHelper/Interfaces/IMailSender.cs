using System.Threading.Tasks;

namespace OnlineShop.Application.Helpers.MessageHelper
{
    public interface IMailSender
    {
        Task<bool> SendEmail(string toMail, string subject, string content, string senderMail = "hiranappcompany@gmail.com", string senderEmailPass = "sanasana2hiranapp@1234", bool useHtml = true);
    }
}
