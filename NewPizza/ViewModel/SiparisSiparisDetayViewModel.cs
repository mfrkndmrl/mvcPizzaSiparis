using NewPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPizza.ViewModel
{
    public class SiparisSiparisDetayViewModel
    {
        public Siparis Siparis { get; set; }
        public IEnumerable<SiparisDetay> SiparisDetaylari { get; set; }
    }
}