using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PolicceREST.Models;
namespace PolicceREST.Controllers
{
    public class PersonController : ApiController
    {
       
        // GET: api/Person
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Forbidden);
            return response;
        }

        // GET: api/Person/5
        public Person Get(long id)
        {
            PersonPersistence per = new PersonPersistence();
            Person person = new Person();
            person= per.getPerson(id);
           
            if (person == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return person;
        }

        // POST: api/Person
        public HttpResponseMessage Post([FromBody]Person value)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Forbidden);
            return response;
        }

        // PUT: api/Person/5
        public HttpResponseMessage Put(int id, [FromBody]string value)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Forbidden);
            return response;
        }

        // DELETE: api/Person/5
        public HttpResponseMessage Delete(int id)
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Forbidden);
            return response;
        }
    }
}
