using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPITest1.CsvHelper;
using WebAPITest1.Models;

namespace WebAPITest1.Controllers
{
    public class PartnersController : ApiController
    {
        //List<Partner> Partners = new List<Partner>
        //        {
        //    new Partner { id = 1, name="ABC Partner", address="Sydney", phoneNumber = "1300 111 222"},
        //    new Partner { id = 2, name="Awesome Partner", address="Sydney", phoneNumber = "1300 111 222"},
        //    new Partner { id = 3, name="Excellent Partner", address="Sydney", phoneNumber = "1300 111 222"},
        //    new Partner { id = 4, name="Gold Partner", address="Melbourne", phoneNumber = "1300 111 222"},

        //};

        private string GetFilePath()
        {
            return string.Format(@"{0}\{1}", System.Web.Hosting.HostingEnvironment.MapPath("/"), "partners.csv");
        }

        public IEnumerable<Partner> GetAllPartners()
        {
            return new CsvService().ReadPartners(GetFilePath());
        }

        public IHttpActionResult GetPartner(int id)
        {
            var Partners = GetAllPartners();

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
            var Partners = GetAllPartners().ToList();

            Partners.Add(p);

            new CsvService().WritePartners(Partners, GetFilePath());

            return Ok("success");
        }

    }
}
