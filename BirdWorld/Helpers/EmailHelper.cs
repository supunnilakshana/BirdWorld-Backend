using SendGrid.Helpers.Mail;
using SendGrid;

namespace BirdWorld.Helpers
{
    public class EmailHelper
    {
        private readonly IConfiguration config;
        public EmailHelper( IConfiguration configuration) {
            config = configuration;
        }
        public async Task SendPwRestEmail(string email,String tokenlink){

            try
            {
                string apiKey = config["EMAIL_SECRETE"];
                Console.WriteLine(apiKey);
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
