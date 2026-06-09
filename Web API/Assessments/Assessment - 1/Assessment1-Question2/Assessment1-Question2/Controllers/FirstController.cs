using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assessment1_Question2.Controllers
{
    public class FirstController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        [HttpGet]
        public IHttpActionResult GetOrders()
        {
            var data = db.Orders
                .Where(o => o.EmployeeID == 5)
                .Select(o => new
            {
                o.OrderID,
                o.CustomerID,
                o.EmployeeID,
                o.OrderDate
            }).ToList();

            return Ok(data);
        }

    }
}
