using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewPizza.Models;

namespace NewPizza.ViewModel
{
    public class AdresSepetViewModel
    {
        public IEnumerable<Sepet> SepetUrunleri { get; set; }
        public IEnumerable<Adres> Adresler { get; set; }
    }
}