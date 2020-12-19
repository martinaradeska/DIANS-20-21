using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalsScout.Models
{
    public class Category
    {
        public Category()
        {
            lokali = new List<Lokal>();
        }
        [Key]
        public int Type_ID  { get; set; }
        public string Kategorija { get; set; }
        public ICollection<Lokal> lokali { get; set; }
    }
}