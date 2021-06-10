namespace NewPizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kategoriduzeltme : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Adres", "AcikAdres", c => c.String(nullable: false));
            AlterColumn("dbo.Adres", "Sehir", c => c.String(nullable: false));
            AlterColumn("dbo.Kategoris", "Ad", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Kategoris", "Ad", c => c.String());
            AlterColumn("dbo.Adres", "Sehir", c => c.String());
            AlterColumn("dbo.Adres", "AcikAdres", c => c.String());
        }
    }
}
