namespace NewPizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siparis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Siparis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        Tarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Siparis");
        }
    }
}
