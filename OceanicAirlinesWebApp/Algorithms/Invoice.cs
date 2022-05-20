using System.Net;
using System.Net.Mail;



namespace OceanicAirlinesWebApp.Algorithms
{
    public class Invoice
    {
            public void sendEmail(string transactionId, string customerName, string customerEmail, string customerPrice, string customerTime, string customerFromLocation, string customerToLocation)
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("cesoairlines@gmail.com", "oceanicFlyAway16"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("cesoairlines@gmail.com"),
                    Subject = "OA INVOICE #" + transactionId,
                    Body = "<p> Hello " + customerName + "!" + "<br><br> Invoice for your parcel delivery going from " + customerFromLocation + " to " + customerToLocation + ". <br> The total price for the parcel delivery service was $" + customerPrice + ". <br>Your parcel will arrive in " + customerTime + " hours.<br><br> Thanks for using Oceanic Airlines as you preferred parcel delivery service in Africa!",
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(customerEmail);
                smtpClient.Send(mailMessage);

            }
    }
}
