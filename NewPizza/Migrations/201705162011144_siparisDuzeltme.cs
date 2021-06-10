namespace NewPizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siparisDuzeltme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Siparis", "AdresId", c => c.Int(nullable: false));
            CreateIndex("dbo.Siparis", "AdresId");
            AddForeignKey("dbo.Siparis", "AdresId", "dbo.Adres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Siparis", "AdresId", "dbo.Adres");
            DropIndex("dbo.Siparis", new[] { "AdresId" });
            DropColumn("dbo.Siparis", "AdresId");
        }
    }
}
