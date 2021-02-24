using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectMashud.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = ("Admin, SuperAdmin, User"))]
        public ActionResult Index()
        {
            return View();
        }
    }
}