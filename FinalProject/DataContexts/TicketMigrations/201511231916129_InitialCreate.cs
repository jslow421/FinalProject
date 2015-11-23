namespace FinalProject.DataContexts.TicketMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        categoryId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.categoryId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        ticketId = c.Int(nullable: false, identity: true),
                        eventName = c.String(),
                        location = c.String(),
                        date = c.DateTime(nullable: false),
                        time = c.DateTime(nullable: false),
                        tradeType = c.String(),
                        user = c.String(),
                        category_categoryId = c.Int(),
                    })
                .PrimaryKey(t => t.ticketId)
                .ForeignKey("dbo.Categories", t => t.category_categoryId)
                .Index(t => t.category_categoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "category_categoryId", "dbo.Categories");
            DropIndex("dbo.Tickets", new[] { "category_categoryId" });
            DropTable("dbo.Tickets");
            DropTable("dbo.Categories");
        }
    }
}
