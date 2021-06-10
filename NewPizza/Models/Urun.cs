using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewPizza.Models
{
    public class Urun
    {
        public int Id { get; set; }
        [Display(Name ="Ürün")]
        public string Ad { get; set; }
        [Display(Name = "Stok Miktarı")]
        public int Stok { get; set; }
        [Display(Name = "Fiyatı")]
        public int Fiyat { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
        [Display(Name = "Ürün Fotoğrafı")]
        public string FotoAdres { get; set; }

    }
}