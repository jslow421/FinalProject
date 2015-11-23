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

        [HttpPost]
        public ActionResult Trade(int id)
        {
            return View();
        }
    }
}