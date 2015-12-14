namespace FinalProject.DataContexts.TicketMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "eventName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tickets", "location", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Tickets", "tradeType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "tradeType", c => c.String());
            AlterColumn("dbo.Tickets", "location", c => c.String());
            AlterColumn("dbo.Tickets", "eventName", c => c.String());
        }
    }
}
