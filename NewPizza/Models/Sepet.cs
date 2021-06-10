using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace NewPizza.Models
{
    public class Sepet
    {
        public int Id { get; set; }
        public int UrunId { get; set; }
        public Urun Urun { get; set; }
        public int Adet { get; set; }
        public string UserId { get; set; }
        //public IUser User { get; set; }

        //public string  User { get; set; }

    }
}