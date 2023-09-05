using SendGrid.Helpers.Mail;
using SendGrid;

namespace BirdWorld.Helpers
{
    public class EmailHelper
    {

        public EmailHelper() { }
        public async Task SendPwRestEmail(string email,String tokenlink){

            try
            {
                string apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("birdworldsupu@gmail.com", "BW");
                var subject = "Password Reset url";
                var to = new EmailAddress(email, "user");
                var plainTextContent = $"click and rest your password {tokenlink}";
                var htmlContent = $"<strong>click and rest your password {tokenlink}</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }




    }
}
