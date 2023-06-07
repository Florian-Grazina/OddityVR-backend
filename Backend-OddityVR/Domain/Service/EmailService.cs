using SendGrid.Helpers.Mail;
using SendGrid;
using Backend_OddityVR.Application.DTO;

namespace Backend_OddityVR.Domain.Service
{
    public class EmailService
    {
        public static async Task Execute(CreateProspeCmd form)
        {
            var apiKey = Environment.GetEnvironmentVariable("sendGridAPI");
            apiKey = "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";
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress("OddityForm@outlook.fr", "OddityVR Form");
            var subject = form.Subject;
            var to = new EmailAddress("floriangrazina@gmail.com", "Thomas");
            //var to = new EmailAddress("thomas.cacan@oddity-vr.com", "Thomas");
            var htmlContent = "<strong>" + form.Name + "<br>" + form.Email + "<br>" + form.Phone + "<br>" + "</strong> <br><br>" + form.Message;
            var plainTextContent = "";

            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
