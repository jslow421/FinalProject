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
           
            var categoryModel = ticketDb.categories.Include("Tickets").Single(c=>c.name== category);
           
            return View(categoryModel);
        }

        //GET: /Exchange/Details
        public ActionResult Details(int id) {
            var ticket = ticketDb.tickets.Find(id);

            return View(ticket);
        }


        public ActionResult Trade(int id)
        {
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var ticket = ticketDb.tickets.Find(id);

            ticket.user = userName;

            ticketDb.SaveChanges();

            var ticketList = ticketDb.tickets.Include("Tickets").Single(t => t.user == userName);

            return View(ticketList);
        }
    }
}