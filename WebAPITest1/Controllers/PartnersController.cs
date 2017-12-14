using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPITest1.Models;

namespace WebAPITest1.Controllers
{
    public class PartnersController : ApiController
    {
        List<Partner> Partners = new List<Partner>
                {
            new Partner { id = 1, name="ABC Partner", address="Sydney", phoneNumber = "1300 111 222"},
            new Partner { id = 2, name="Awesome Partner", address="Sydney", phoneNumber = "1300 111 222"},
            new Partner { id = 3, name="Excellent Partner", address="Sydney", phoneNumber = "1300 111 222"},
            new Partner { id = 4, name="Gold Partner", address="Melbourne", phoneNumber = "1300 111 222"},
                };

        public IEnumerable<Partner> GetAllPartners()
        {
            return Partners;
        }

        public IHttpActionResult GetPartner(int id)
        {
            var Partner = Partners.FirstOrDefault((p) => p.id == id);
            if (Partner == null)
            {
                return NotFound();
            }
            return Ok(Partner);
        }

        [HttpPost]
        public IHttpActionResult InsertPartner(Partner p)
        {
            Partners.Add(p);
            return Ok();
        }

    }
}
