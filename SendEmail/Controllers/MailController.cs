using SendEmail.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace SendEmail.Controllers
{
    public class MailController : ApiController
    {
        // GET: api/Mail
        public string Get()
        {
            return "hey";
        }

        // GET: api/Mail/5
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Forbidden);
            return response;
        }

        // POST: api/Mail
        public HttpResponseMessage Post([FromBody]Email value)
        {
            Models.Email email = new Models.Email();
            
            HttpStatusCode code= email.sendMail(value);
            HttpResponseMessage response = Request.CreateResponse(code);
            return response;
        }

        // PUT: api/Mail/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Forbidden);
            return response;
        }

        // DELETE: api/Mail/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Forbidden);
            return response;
        }
    }
}
