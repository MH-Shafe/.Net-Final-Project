using System;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using BLL.DTOs.Admin;
using BLL.Services.Admin;
using Uber.Auth;

namespace Uber.Controllers.Admin
{
    [RoutePrefix("api/admin/email")]
    public class EmailController : ApiController
    {
        private const string SenderEmail = "mhshafe83@gmail.com";
        private const string SenderPassword = "lcxz ndpa wrka ejkk";

        [HttpPost]
        [Route("send")]
        public IHttpActionResult SendEmail([FromBody] EmailDTO email)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.From = new MailAddress(SenderEmail);
                message.To.Add(new MailAddress(email.Recipient));
                message.Subject = email.Subject;
                message.Body = email.Body;
                message.IsBodyHtml = true;

                // Configure SMTP client
                using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtpClient.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(message);
                }
                
                EmailService.Create(email);

                return Ok("Email sent successfully");

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpPost]
        [Route("add")]
        public IHttpActionResult AddEmailToDatabase([FromBody] EmailDTO email)
        {
            try
            {
                // Add the email to the database using service
                EmailService.Create(email);

                return Ok("Email added to the database successfully");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [HttpGet]
        [Route("")]
        
        public HttpResponseMessage GetAll()
        {
            var data = EmailService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [HttpGet]
        [Route("{id}")]

        public HttpResponseMessage Get(int id)
        {
            var data = EmailService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [AdminAuth]
        public IHttpActionResult DeleteEmail(int id)
        {
            try
            {
                // Delete the email from the database using service
                EmailService.Delete(id);

                return Ok("Email deleted successfully");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
