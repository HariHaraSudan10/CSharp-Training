using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assessment1_Question2.Controllers
{
    public class SecondController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();
        [HttpGet]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var data = db.GetCustomersByCountry(country).ToList();

            return Ok(data);
        }
    }
}
