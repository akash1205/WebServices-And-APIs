using System;
using System.Net;
using System.Text;
using System.Web.Mail;
namespace SendEmail.Models
{
    public class Email
    {

        private string server;
        private int port;
        private string username;
        private string password;
        public string customerEmail { get; set; }
        public string serviceEmail { get; set; }
        public string serviceName { get; set; }
        public int bookingID { get; set; }
        public DateTime bookingDate { get; set; }
        public string slot { get; set; }
        public Email()
        {
            server = "smtp.gmail.com";
            port = 465;
            username = "homeservices050@gmail.com";
            password = "HomeService";
        }

        public HttpStatusCode sendMail(Email value)
        {
           try
            {
                MailMessage mailMsg = new MailMessage();

                mailMsg.To = value.serviceEmail;
                mailMsg.Headers.Add("From", string.Format("{0} <{1}>", "System", "homeservices050@gmail.com"));
                mailMsg.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserver"] = server;
                mailMsg.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"] = port;
                mailMsg.Fields["http://schemas.microsoft.com/cdo/configuration/sendusing"] = 2;
                mailMsg.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 1;
                mailMsg.Fields["http://schemas.microsoft.com/cdo/configuration/sendusername"] = username;
                mailMsg.Fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"] = password;
                mailMsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
               
                mailMsg.BodyEncoding = Encoding.UTF8;
                mailMsg.Subject = "Home Services -  You have been booked for "+value.serviceName;
                mailMsg.Body = "Booking ID - " + value.bookingID + ". Appoitment on "+ value.bookingDate.ToLongDateString()+" at "+ value.slot;
                    //+ bookingDate.Date+" at "+bookingDate.TimeOfDay;

                SmtpMail.SmtpServer = server;
                SmtpMail.Send(mailMsg);
                mailMsg.To = value.customerEmail;
                mailMsg.Subject = "Home Services -  Your service for " + value.serviceName+"has been booked";
                mailMsg.Body = "Booking ID - " + value.bookingID + ". Appoitment on " + value.bookingDate.ToLongDateString() + " at " + value.slot;
                
                SmtpMail.Send(mailMsg);
                return (HttpStatusCode.Accepted);

            }
            catch (Exception ex)
            {
                throw ex;
                return (HttpStatusCode.BadRequest);
            }

        }


    }
}