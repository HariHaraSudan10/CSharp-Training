using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Assessment1_Question1.Models
{
    public class CountryDBContext : DbContext
    {
        public CountryDBContext() : base("CountryDBContext")
        {
        }

        public DbSet<Country> Countries{ get; set; }
    }
}