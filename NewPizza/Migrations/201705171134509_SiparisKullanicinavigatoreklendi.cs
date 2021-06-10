namespace NewPizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiparisKullanicinavigatoreklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Siparis", "Kullanici_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Siparis", "Kullanici_Id");
            AddForeignKey("dbo.Siparis", "Kullanici_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Siparis", "Kullanici_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Siparis", new[] { "Kullanici_Id" });
            DropColumn("dbo.Siparis", "Kullanici_Id");
        }
    }
}
