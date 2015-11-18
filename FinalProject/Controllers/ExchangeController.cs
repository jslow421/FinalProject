using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class ExchangeController : Controller
    {
        // GET: Exchange
        public ActionResult Index()
        {
            return View();
        }

        //GET: /Exchange/Browse
        public ActionResult Browse(String category) {
            

            
            return View();
        }

        //GET: /Exchange/Details
        public ActionResult Details(int id) {
            return View();
        }
    }
}