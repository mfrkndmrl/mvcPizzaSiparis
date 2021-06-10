namespace NewPizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class siparisesiparisonayeklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Siparis", "SiparisOnay", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Siparis", "SiparisOnay");
        }
    }
}
