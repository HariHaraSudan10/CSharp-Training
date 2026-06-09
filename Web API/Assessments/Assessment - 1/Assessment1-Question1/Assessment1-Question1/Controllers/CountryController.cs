using Assessment1_Question1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assessment1_Question1.Controllers
{
    public class CountryController : ApiController
    {

        CountryDBContext db = new CountryDBContext();
        [HttpGet]
        public IHttpActionResult GetCountries()
        {
            var data = db.Countries.ToList();
            return Ok(data);
            
        }

        [HttpGet]
        public IHttpActionResult GetCountry(int id)
        {
            var country = db.Countries.Find(id);

            if (country == null)
                return NotFound();

            return Ok(country);
        }

        [HttpPost]
        public IHttpActionResult AddCountry(Country country)
        {
            db.Countries.Add(country);
            db.SaveChanges();
            return Ok("Country Added Successfully");
        }

        [HttpPut]
        public IHttpActionResult UpdateCountry(int id, Country country)
        {
            var modcountry = db.Countries.Find(id);


            if (modcountry == null)
                return NotFound();

            modcountry.CountryName = country.CountryName;
            modcountry.Capital = country.Capital;
            db.SaveChanges();
            return Ok("Country Updated Successfully");
        }

        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = db.Countries.Find(id);


            if (country == null)
                return NotFound();

            db.Countries.Remove(country);
            db.SaveChanges();

            return Ok("Country Deleted Successfully");
        }
    }
}
