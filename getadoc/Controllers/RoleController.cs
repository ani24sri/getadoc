using getadoc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace getadoc.Controllers
{
    public class RoleController : Controller
    {
        ApplicationDbContext context;
        // GET: Role
        public ActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
            {
                if(!User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            var roles = context.Roles.ToList();
            return View(roles);
        }
    }
}