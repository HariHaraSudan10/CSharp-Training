using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assessment1_Question1.Models
{
    [Table("Country")]
    public class Country
    {
        [Key]
        public int ID { get; set; }
        public string CountryName { get; set; }
        public string Capital { get; set; }
    }
}