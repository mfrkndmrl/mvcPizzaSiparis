﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace NewPizza.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<NewPizza.Models.Urun> Uruns { get; set; }

        public System.Data.Entity.DbSet<NewPizza.Models.Kategori> Kategoris { get; set; }

        public System.Data.Entity.DbSet<NewPizza.Models.Sepet> Sepets { get; set; }
        public System.Data.Entity.DbSet<NewPizza.Models.Sehir> Sehirs { get; set; }
        public System.Data.Entity.DbSet<NewPizza.Models.Adres> Adress { get; set; }
        public System.Data.Entity.DbSet<NewPizza.Models.Siparis> Sipariss { get; set; }
        public System.Data.Entity.DbSet<NewPizza.Models.SiparisDetay> SiparisDetays { get; set; }
        public System.Data.Entity.DbSet<NewPizza.Models.Deneme> Denemes { get; set; }




    }
}