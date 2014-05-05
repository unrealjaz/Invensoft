﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Invensoft.Models;

namespace Invensoft
{
    internal class RoleActions
    {
        internal void CreateAdmin()
        {
            Models.ApplicationDbContext context = new Models.ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            var roleStore = new RoleStore<IdentityRole>(context);

            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            if (!roleMgr.RoleExists("Administrator"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole("Administrator"));

                if (!IdRoleResult.Succeeded)
                {

                }
            }

            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser()
            {
                UserName = "admin@invensoft.com",
            };

            IdUserResult = userMgr.Create(appUser, "Pa$$word");

            if (IdUserResult.Succeeded)
            {
                IdUserResult = userMgr.AddToRole(appUser.Id, "Administrator");
                if (!IdUserResult.Succeeded)
                {

                }
            }
            else
            {
            }
        }
        internal void CreateSalesUser()
        {
            Models.ApplicationDbContext context = new Models.ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            var roleStore = new RoleStore<IdentityRole>(context);

            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            if (!roleMgr.RoleExists("Sales"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole("Sales"));

                if (!IdRoleResult.Succeeded)
                {

                }
            }

            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser()
            {
                UserName = "sales@invensoft.com",
            };

            IdUserResult = userMgr.Create(appUser, "Pa$$word");

            if (IdUserResult.Succeeded)
            {
                IdUserResult = userMgr.AddToRole(appUser.Id, "Sales");
                if (!IdUserResult.Succeeded)
                {

                }
            }
            else
            {
            }
        }
        internal void CreateProductionUser()
        {
            Models.ApplicationDbContext context = new Models.ApplicationDbContext();
            IdentityResult IdRoleResult;
            IdentityResult IdUserResult;

            var roleStore = new RoleStore<IdentityRole>(context);

            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            if (!roleMgr.RoleExists("Production"))
            {
                IdRoleResult = roleMgr.Create(new IdentityRole("Production"));

                if (!IdRoleResult.Succeeded)
                {

                }
            }

            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser()
            {
                UserName = "production@invensoft.com",
            };

            IdUserResult = userMgr.Create(appUser, "Pa$$word");

            if (IdUserResult.Succeeded)
            {
                IdUserResult = userMgr.AddToRole(appUser.Id, "Production");
                if (!IdUserResult.Succeeded)
                {

                }
            }
            else
            {
            }
        }
    }
}