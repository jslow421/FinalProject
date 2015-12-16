namespace FinalProject.DataContexts.TicketMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tickets", "time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "time", c => c.DateTime(nullable: false));
        }
    }
}
