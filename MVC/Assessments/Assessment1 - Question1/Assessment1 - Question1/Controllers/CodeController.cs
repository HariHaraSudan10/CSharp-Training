using Assessment1___Question1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assessment1___Question1.Controllers
{
    public class CodeController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }

        //all customers from Germany
        public ActionResult GermanyCustomers()
        {
            var customers = db.Customers.Where(c => c.Country == "Germany");
            return View(customers);
        }

        //details of the customer with order id 10248
        public ActionResult CustomerByOrderId()
        {
            int orderId = 10248;
            var customer = db.Orders
                .Where(o => o.OrderID == orderId)
                .Select(o => o.Customer).FirstOrDefault();

            ViewBag.OrderId = orderId;

            return View(customer);
        }

    }
}