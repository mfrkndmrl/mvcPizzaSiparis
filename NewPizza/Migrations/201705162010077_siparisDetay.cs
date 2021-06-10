namespace NewPizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siparisDetay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiparisDetays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SiparisId = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                        Adet = c.Int(nullable: false),
                        Fiyat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Siparis", t => t.SiparisId, cascadeDelete: true)
                .ForeignKey("dbo.Uruns", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.SiparisId)
                .Index(t => t.UrunId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SiparisDetays", "UrunId", "dbo.Uruns");
            DropForeignKey("dbo.SiparisDetays", "SiparisId", "dbo.Siparis");
            DropIndex("dbo.SiparisDetays", new[] { "UrunId" });
            DropIndex("dbo.SiparisDetays", new[] { "SiparisId" });
            DropTable("dbo.SiparisDetays");
        }
    }
}
