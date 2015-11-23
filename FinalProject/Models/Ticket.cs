using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Models
{
    public class Ticket
    {
        public int ticketId { get; set; }
        public string eventName { get; set; }
        public string location { get; set; }
        public DateTime date { get; set; }
        public DateTime time { get; set; }
        public string tradeType { get; set; }
        public string user { get; set; }
        public Category category { get; set; }
    }
}