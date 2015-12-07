using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalProject.DataContexts;
using FinalProject.Models;

namespace FinalProject.Controllers
{
    public class TicketManagerController : Controller
    {
        private ExchangeDb db = new ExchangeDb();
        private string[] tradeTypes = {"In Person", "Mail", "Email"};
    
        // GET: TicketManager
        public ActionResult Index()
        {
            return View(db.tickets.ToList());
        }

        // GET: TicketManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: TicketManager/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> categories = db.categories
                .Select(category => new SelectListItem { Value = category.name, Text = category.name });

            ViewBag.categories = categories;
            return View();
        }

        // POST: TicketManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormCollection form)
        {
            Ticket ticket = new Ticket();
            ticket.eventName = form["eventName"];
            ticket.location = form["location"];
            ticket.tradeType = form["tradeType"];
            ticket.user = User.Identity.Name;
            ticket.date = Convert.ToDateTime(form["date"]);
            ticket.time = Convert.ToDateTime(form["time"]);
            string cat = form["categories"];

            ticket.category = (Category)db.categories.Single(s => s.name == cat);

            if (ModelState.IsValid)
            {
                db.tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.categories, "Categories", "Name", ticket.category);
            return View(ticket);
        }

        // POST: TicketManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      /*  [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ticketId,eventName,location,date,tradeType,user")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.categories, "Categories", "Name", ticket.category);
            return View(ticket);
        }*/

        // GET: TicketManager/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }

             IEnumerable<SelectListItem> categories = db.categories
                .Select(category => new SelectListItem { Value = category.name, Text = category.name });

            ViewBag.categories = categories;
            return View(ticket);
        }

        // POST: TicketManager/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ticketId,eventName,location,date,tradeType,user")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticket);
        }

        // GET: TicketManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: TicketManager/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.tickets.Find(id);
            db.tickets.Remove(ticket);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
