using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalorieTracker.Models
{
    using CalorieTracker.Views.Health_Enthusiast;
    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System;
    using System.Threading.Tasks;

    namespace Example
    {
        internal class Example
        {
            //private void Main()
            //{
            //    Execute().Wait();
            //}

            public async Task Execute(string To)
            {
                //APIKey sendGridKey = new APIKey();
                //var apiKey = sendGridKey.ToString();

                var apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("jeffpigg5@gmail.com", "Jeff Pigg");
                var subject = "Welcome To KnowCal";
                var to = new EmailAddress(To);
                var plainTextContent = "Thanks for subscribing to KnowCal's E-Mail subscription.";
                var htmlContent = "<strong>This is your first Email from KnowCal</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);
            }
        }
    }
}
