using MVCProjectMashud.Models;
using MVCProjectMashud.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectMashud.Controllers
{
    public class DepartmentController : Controller
    {
        public ActionResult Index()
        {
            using (var _context = new HospitalDBContext())
            {
                List<tblDepartment> list = _context.tblDepartments.ToList();
                return View(list);
            }

        }

        public JsonResult InsertDepartments(List<tblDepartment> tblDepartments)
        {
            int insertRecords = 0;
            using (var _context = new HospitalDBContext())
            {
                _context.Database.ExecuteSqlCommand("TRUNCATE TABLE [tblDepartments]");
                if (tblDepartments == null)
                {
                    tblDepartments = new List<tblDepartment>();
                }
                foreach (var item in tblDepartments)
                {
                    _context.tblDepartments.Add(item);
                }
                insertRecords = _context.SaveChanges();
                return Json(insertRecords);
            }

        }
    }
}