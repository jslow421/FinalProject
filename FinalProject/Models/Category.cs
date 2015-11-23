using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Category
    {
        public int categoryId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Ticket> tickets { get; set; }
    }
}