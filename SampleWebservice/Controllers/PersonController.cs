using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SimpleRESTServer.Models;



namespace SimpleRESTServer.Controllers
{
    public class PersonController : ApiController
    {
        // GET: api/Person
        public IEnumerable<string> Get()
        {
            return new string[] { "Person1", "Person2" };
        }

        // GET: api/Person/5
        public Person Get(long id)
        {

            PersonPersistance pp = new PersonPersistance();

            Person person = pp.getPerson(id);


            return person;
        }

        // POST: api/Person
        public void Post([FromBody]Person value)
        {
        }

        // PUT: api/Person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Person/5
        public void Delete(int id)
        {
        }
    }
}
