using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPizza.Models
{
    public class SiparisDetay
    {
        public int Id { get; set; }
        public int SiparisId { get; set; }
        public Siparis Siparis { get; set; }
        public int UrunId { get; set; }
        public Urun Urun { get; set; }
        public int Adet { get; set; }
        public int Fiyat { get; set; }
    }
}