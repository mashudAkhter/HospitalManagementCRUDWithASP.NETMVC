using MVCProjectMashud.Models;
using MVCProjectMashud.Models.DAL;
using MVCProjectMashud.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectMashud.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult CreateRole()
        {
            using (var _context = new HospitalDBContext())
            {
                List<tblUser> userList = _context.tblUsers.ToList();
                ViewBag.Users = new SelectList(userList, "Id", "UserName");
                return View();
            }

        }
        [HttpPost]
        public ActionResult CreateRole(tblRole obj)
        {
            using (var _context = new HospitalDBContext())
            {
                _context.tblRoles.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        public ActionResult Index()
        {
            using (var _context = new HospitalDBContext())
            {
                var userRoleList = (from user in _context.tblUsers
                                    join role in _context.tblRoles
                                     on user.Id equals role.UserId
                                    select new
                                    {
                                        UserId = user.Id,
                                        RoleId = role.Id,
                                        UserName = user.UserName,
                                        RoleName = role.RollName
                                    }).ToList();
                List<UserRoleViewModel> list = new List<UserRoleViewModel>();
                foreach (var item in userRoleList)
                {
                    UserRoleViewModel obj = new UserRoleViewModel();
                    obj.RoleId = item.RoleId;
                    obj.RollName = item.RoleName;
                    obj.UserId = item.UserId;
                    obj.UserName = item.UserName;
                    list.Add(obj);
                }
                return View(list);
            }
        }
        public ActionResult Edit(int id)
        {
            using (var _context = new HospitalDBContext())
            {
                tblRole role = _context.tblRoles.Find(id);
                List<tblUser> userList = _context.tblUsers.ToList();
                ViewBag.Users = new SelectList(userList, "Id", "UserName");
                return View(role);
            }

        }
        [HttpPost]
        public ActionResult Edit(tblRole obj)
        {
            using (var _context = new HospitalDBContext())
            {
                bool IsExists = !_context.tblRoles.Any(u => u.RollName == obj.RollName && u.UserId == obj.UserId);

                if (IsExists)
                {
                    tblRole role = _context.tblRoles.Find(obj.Id);
                    role.RollName = obj.RollName;
                    role.UserId = obj.UserId;
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    tblRole role = _context.tblRoles.Find(obj.Id);
                    List<tblUser> userList = _context.tblUsers.ToList();
                    ViewBag.Users = new SelectList(userList, "Id", "UserName");
                    ModelState.AddModelError("", "Role already exists");
                    return View();
                }


            }

        }

        public ActionResult Delete(int id)
        {
            using (var _context = new HospitalDBContext())
            {
                tblRole role = _context.tblRoles.Find(id);
                role.tblUser = _context.tblUsers.Find(role.UserId);
                return View(role);
            }

        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            using (var _context = new HospitalDBContext())
            {
                tblRole role = _context.tblRoles.Find(id);
                if (role != null)
                {
                    _context.tblRoles.Remove(role);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                role.tblUser = _context.tblUsers.Find(role.UserId);
                return View(role);
            }

        }

        public ActionResult Details(int id)
        {
            using (var _context = new HospitalDBContext())
            {
                tblRole role = _context.tblRoles.Find(id);
                role.tblUser = _context.tblUsers.Find(role.UserId);
                return View(role);
            }

        }
    }
}