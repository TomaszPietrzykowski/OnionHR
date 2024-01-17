using OnionHR.Application.Models.Email;

namespace OnionHR.Application.Contracts.Email;

public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}
