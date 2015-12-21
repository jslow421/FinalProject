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
                new Category { name = "Football", imageUrl = "~/Content/Img/football.png" },
                new Category { name = "Hockey", imageUrl = "~/Content/Img/hockey.png" },
                new Category { name = "Basketball", imageUrl = "~/Content/Img/basketball.png" },
                new Category { name = "Concert", imageUrl = "~/Content/Img/Concert.png" }
            };

            DateTime date = new DateTime();
            context.tickets.AddOrUpdate(
                t => t.eventName,
                new Ticket { eventName = "Packer Game", date= DateTime.Now,  location = "Lambaeu Field", category = categories.Single(c => c.name == "Football"), user="mvcmanager@gmail.com" },
                new Ticket { eventName = "Admiral Game", date = DateTime.Now,  location = "Bradley Center", category = categories.Single(c => c.name == "Hockey"), user="cust@isp.com" },
                new Ticket { eventName = "Bucks Game", date = DateTime.Now, location = "Bradley Center", category = categories.Single(c => c.name == "Basketball"), user = "cust@isp.com" },
                new Ticket { eventName = "Some Singer", date = DateTime.Now, location = "Pabst Theater", category = categories.Single(c => c.name == "Concert"), user = "cust@isp.com" }
                );

            context.SaveChanges();
           
        }
    }
}
