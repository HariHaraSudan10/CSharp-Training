using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Assessment1___Question2.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("MovieDB")
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}