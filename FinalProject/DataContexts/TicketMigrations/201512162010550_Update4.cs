namespace FinalProject.DataContexts.TicketMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "imageUrl", c => c.String());
            DropColumn("dbo.Categories", "description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "description", c => c.String());
            DropColumn("dbo.Categories", "imageUrl");
        }
    }
}
