using FinalProject.DataContexts;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
    }
}