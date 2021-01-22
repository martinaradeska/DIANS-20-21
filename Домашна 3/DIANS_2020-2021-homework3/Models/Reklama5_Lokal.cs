using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocalsScout.Models
{
    public enum LokalType { 
    Sale,
    Rent
    }
    public class Reklama5_Lokal
    {
        public Reklama5_Lokal()
        {
            Korisnici = new List<ApplicationUser>();
        }
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Kvadratura { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Tel { get; set; }
        public LokalType Tip_oglas { get; set; }
        public string Cena { get; set; }
        public virtual ICollection<ApplicationUser> Korisnici { get; set; }
    }
}