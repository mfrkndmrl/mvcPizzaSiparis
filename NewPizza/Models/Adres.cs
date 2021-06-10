using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewPizza.Models
{
    public class Adres
    {

        public int Id { get; set; }
        [Required]
        [Display(Name ="Açık Adres")]
        public string AcikAdres { get; set; }
        [Required]
        [Display(Name = "Otruduğunuz şehir")]
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string UserId { get; set; }
    }
}