using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LocalsScout.Models;

namespace LocalsScout.Models
{
    public class Klient
    {
        public Klient()
        {
            Izbrani = new List<Reklama5_Lokal>();
        }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Tel  { get; set; }
        public virtual ICollection<Reklama5_Lokal> Izbrani { get; set; }
    }
}