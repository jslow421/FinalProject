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

            DateTime date = new DateTime();
            context.tickets.AddOrUpdate(
                t => t.eventName,
                new Ticket { eventName = "Packer Game", date= DateTime.Now, time = date.AddHours(13).AddMinutes(30), location = "Lambaeu Field", category = categories.Single(c => c.name == "Football") },
                new Ticket { eventName = "Admiral Game", date = DateTime.Now, time = date.AddHours(19).AddMinutes(10), location = "Bradley Center", category = categories.Single(c => c.name == "Hockey") },
                new Ticket { eventName = "Bucks Game", date = DateTime.Now, time = date.AddHours(19).AddMinutes(30), location = "Bradley Center", category = categories.Single(c => c.name == "Basketball") },
                new Ticket { eventName = "Some Singer", date = DateTime.Now, time = date.AddHours(20).AddMinutes(00), location = "Pabst Theater", category = categories.Single(c => c.name == "Concert") }
                );

            context.SaveChanges();
           
        }
    }
}
