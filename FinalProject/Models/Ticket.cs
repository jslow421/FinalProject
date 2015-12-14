using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProject.Models
{
    public class Ticket
    {
        public int ticketId { get; set; }
        [Required(ErrorMessage = "An Event Name is required")]
        [StringLength(100)]
        public string eventName { get; set; }
        [Required(ErrorMessage = "A location is required")]
        [StringLength(100)]
        public string location { get; set; }
        [Required(ErrorMessage = "A date is required")]
        public DateTime date { get; set; }
        public DateTime time { get; set; }
        [Required(ErrorMessage = "You must have a trade type")]
        public string tradeType { get; set; }
        public string user { get; set; }
        public Category category { get; set; }
    }
}