using NewPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPizza.ViewModel
{
    public class UrunSepetViewModel
    {
        public IEnumerable<Urun> Urunler { get; set; }
        public IEnumerable<Sepet> SepetUrunler { get; set; }
    }
}