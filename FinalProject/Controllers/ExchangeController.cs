using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class ExchangeController : Controller
    {
        // GET: Exchange
        public ActionResult Index()
            //category model required to finish index controller
        {
            return View();
        }

        //GET: /Exchange/Browse
        public ActionResult Browse(String category) {
            //need category model class to finish this
            var categoryModel = new Category { };
            
            return View(categoryModel);
        }

        //GET: /Exchange/Details
        public ActionResult Details(int id) {
            //need ticket model to complete this
            var ticket = new Ticket {Title="Category " + id };

            return View(ticket);
        }
    }
}