using FinalProject.DataContexts;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FinalProject.Models;
using Microsoft.AspNet.Identity;

namespace FinalProject.Controllers
{
    public class AdminController : Controller
    {
        private IdentityDb identityDb = new IdentityDb();

        // GET: Admin
        [Authorize(Roles = "AppAdmin")]
        public ActionResult Index()
        {
            return View(identityDb.Roles.OrderBy(r => r.Name));
        }

        public ActionResult UsersInRole(string name)
        {
            ViewBag.RoleName = name;
            List<IdentityUser> userMembers = new List<IdentityUser>();
            foreach (var user in identityDb.Roles.Single(r => r.Name == name).Users)
            {
                userMembers.Add(identityDb.Users.Find(user.UserId));
            }

            ViewBag.Members = userMembers;
            return View(identityDb.Users.OrderBy(u => u.UserName));
        }

        [Authorize(Roles = "AppAdmin")]
        [HttpPost]
        public ActionResult UsersInRole(String name, FormCollection Form) {
            var store = new UserStore<ApplicationUser>(identityDb);
            var manager = new UserManager<ApplicationUser>(store);

            string str = Form["UserNames"].ToString();
            string[] users = str.Split(',');
            foreach (string usr in users) {
                bool isChecked = Convert.ToBoolean(Form[usr].Split(',')[0]);
                if (isChecked) {
                    if (!manager.IsInRole(manager.Users.FirstOrDefault(u => u.UserName == usr).Id, name)) {
                        manager.AddToRole(manager.Users.FirstOrDefault(u => u.UserName == usr).Id, name);
                    }
                }
                else {
                    if (!manager.IsInRole(manager.Users.FirstOrDefault(u => u.UserName == usr).Id, name)) {
                        manager.RemoveFromRole(manager.Users.FirstOrDefault(u => u.UserName == usr).Id, name);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}