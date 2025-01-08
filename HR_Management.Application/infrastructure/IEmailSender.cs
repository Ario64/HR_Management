using HR_Management.Application.models;

namespace HR_Management.Application.infrastructure;

public interface IEmailSender
{
    Task<bool> SendEmail(Email email);
}