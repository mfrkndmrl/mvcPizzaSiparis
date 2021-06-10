using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewPizza.Models
{
    public class Deneme
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}