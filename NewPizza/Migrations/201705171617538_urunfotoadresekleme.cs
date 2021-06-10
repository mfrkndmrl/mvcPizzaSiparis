namespace NewPizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class urunfotoadresekleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Uruns", "FotoAdres", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Uruns", "FotoAdres");
        }
    }
}
