﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using FinalProject.Models;
using FinalProject.DataContexts;

namespace FinalProject.DataContexts
{
    public class IdentityDb : IdentityDbContext<ApplicationUser>
    {
        public IdentityDb() : base("DefaultConnection") { }
        public static IdentityDb Create()
        {
            return new IdentityDb();
        }
    }
}
