using System.Net;
using HR_Management.Application.infrastructure;
using HR_Management.Application.models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace HR_Management.Infrastructure.mail;

public class EmailSender : IEmailSender
{
    private readonly EmailSetting _emailSetting;

    public EmailSender(IOptions<EmailSetting> options)
    {
        _emailSetting = options.Value;
    }

    public async Task<bool> SendEmail(Email email)
    {
        var client = new SendGridClient(_emailSetting.ApiKey);
        var to = new EmailAddress(email.To);
        var from = new EmailAddress()
        {
            Email = _emailSetting.FromAddress,
            Name = _emailSetting.FromName
        };
        var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
        var response = await client.SendEmailAsync(message);
        return response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Accepted;
    }
}