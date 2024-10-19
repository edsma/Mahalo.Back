using Mahalo.Shared.Response;

namespace Mahalo.Back.Helpers;

public interface IMailHelper
{
    ActionResponse<string> SendMail(string toName, string toEmail, string subject, string body, string language);
}