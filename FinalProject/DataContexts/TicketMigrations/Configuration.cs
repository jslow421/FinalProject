namespace FinalProject.DataContexts.TicketMigrations
{
    using FinalProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FinalProject.DataContexts.ExchangeDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContexts\TicketMigrations";
        }

        protected override void Seed(FinalProject.DataContexts.ExchangeDb context)
        {
            var categories = new List<Category>
            {
                new Category { name = "Football" },
                new Category { name = "Hockey" },
                new Category { name = "Basketball" },
                new Category { name = "Concert" }
            };

            context.tickets.AddOrUpdate(
                t => t.eventName,
                new Ticket { eventName = "Packer Game", date= DateTime.Now, location = "Lambaeu Field", category = categories.Single(c => c.name == "Football") },
                new Ticket { eventName = "Admiral Game", date = DateTime.Now, location = "Bradley Center", category = categories.Single(c => c.name == "Hockey") },
                new Ticket { eventName = "Bucks Game", date = DateTime.Now, location = "Bradley Center", category = categories.Single(c => c.name == "Basketball") },
                new Ticket { eventName = "Some Singer", date = DateTime.Now, location = "Pabst Theater", category = categories.Single(c => c.name == "Concert") }
                );

            context.SaveChanges();
           
        }
    }
}
