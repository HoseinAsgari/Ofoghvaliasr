using System.Threading.Tasks;

namespace OnlineShop.Application.Helpers.MessageHelper
{
    public interface IMailSender
    {
        Task SendEmail(string toMail, string subject, string content, string senderMail = "ofoghvaliasr@gmail.com", string senderEmailPass = "ofogh1353", bool useHtml = true);
    }
}
