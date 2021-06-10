namespace NewPizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sepet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Sepets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrunId = c.Int(nullable: false),
                        Adet = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Uruns", t => t.UrunId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UrunId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sepets", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Sepets", "UrunId", "dbo.Uruns");
            DropIndex("dbo.Sepets", new[] { "UserId" });
            DropIndex("dbo.Sepets", new[] { "UrunId" });
            DropTable("dbo.Sepets");
        }
    }
}
