namespace NewPizza.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hatagider : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sepets", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Sepets", new[] { "UserId" });
            AlterColumn("dbo.Sepets", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Sepets", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Sepets", "UserId");
            AddForeignKey("dbo.Sepets", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
