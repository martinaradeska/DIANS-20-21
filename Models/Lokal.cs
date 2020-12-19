using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalsScout.Models
{
    public class Lokal
    {
        [Key]
        public int ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }

    }
}