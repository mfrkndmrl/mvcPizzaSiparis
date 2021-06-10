using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewPizza.Models
{
    public class Siparis
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Sipariş Zamanı")]
        public DateTime Tarih { get; set; }
        public int AdresId { get; set; }
        public Adres Adres { get; set; }
        public bool SiparisOnay { get; set; }
        public ApplicationUser Kullanici { get; set; }


    }
}