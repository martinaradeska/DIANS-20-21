using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LocalsScout.Models
{
    public class ApplicationUserReklama5_Lokal
    {
        [Key]
        [Column(Order = 1)]
        public string ApplicationUser_Id { get; set; }

        [Key]
        [Column(Order = 2)]
        public int Reklama5_Lokal_ID { get; set; }
    }
}