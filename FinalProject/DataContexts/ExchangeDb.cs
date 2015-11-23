using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FinalProject.Models;

namespace FinalProject.DataContexts
{
    public class ExchangeDb : DbContext
    {
        public ExchangeDb() : base("DefaultConnection"){}
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}