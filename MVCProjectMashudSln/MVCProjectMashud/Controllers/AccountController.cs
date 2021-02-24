using MVCProjectMashud.Models;
using MVCProjectMashud.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVCProjectMashud.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblUser obj)
        {
            using (var _context = new HospitalDBContext())
            {
                bool isvalid = _context.tblUsers.Any(u => u.UserName == obj.UserName && u.UserPassword == obj.UserPassword);
                if (isvalid)
                {
                    FormsAuthentication.SetAuthCookie(obj.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid user infromation");
                    return View();
                }
            }

        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tblUser obj)
        {
            using (var _context = new HospitalDBContext())
            {
                bool IsExists = !_context.tblUsers.Any(u => u.UserName == obj.UserName);
                if (IsExists)
                {
                    _context.tblUsers.Add(obj);
                    _context.SaveChanges();
                    int count = _context.tblUsers.Count();
                    if (count == 1)
                    {
                        return RedirectToAction("CreateRole", "Admin");
                    }
                    return View("Login");
                }
                else
                {
                    ModelState.AddModelError("", "User already exists");
                    return View();
                }

            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}