using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using FinalProject.DataContexts;

namespace FinalProject.Controllers
{
    public class ExchangeController : Controller
    {
        ExchangeDb ticketDb = new ExchangeDb();

        // GET: Exchange
        public ActionResult Index()
        {
            var categories = ticketDb.categories.ToList();
            return View(categories);
        }

        //GET: /Exchange/Browse
        public ActionResult Browse(string category) {
           
            var categoryModel = ticketDb.categories.Include("Tickets").Single(c=>c.name == category);
           
            return View(categoryModel);
        }

        //GET: /Exchange/Details
        public ActionResult Details(int id) {
            var ticket = ticketDb.tickets.Find(id);
            var user = User.Identity.Name;
            bool status = String.IsNullOrEmpty(user) ? false : true;
            
            ViewBag.status = status;
            return View(ticket);
        }

        //GET: /Trade Details
        public ActionResult Ticket(int id)
        {
            var user = User.Identity.Name;
            var ticket = ticketDb.tickets.Find(id);

            var tickets = ticketDb.tickets.Where(t => t.user == user);

            ViewBag.ticket = ticket;
            return View(tickets);
        }

        //POST: /Trade Approval
        [HttpPost]
        public ActionResult Trade(int id, FormCollection form)
        {
            string userName = User.Identity.Name;
            var ticket = ticketDb.tickets.Find(id);
            var tradeId = form["tradeTicket"];
            tradeId = tradeId.Substring(0, tradeId.IndexOf(','));
            var ticket2 = ticketDb.tickets.Find(Convert.ToInt32(tradeId));
            //trades the tickets
            ticket2.user = ticket.user;
            ticket.user = userName;

            ticketDb.SaveChanges();

            ViewBag.ticket = ticket;
            ViewBag.userName = userName;
            ViewBag.ticket2 = ticket2;


            var tickets = ticketDb.tickets.Where(t => t.user == User.Identity.Name);
            return View(tickets);
        }
    }
}