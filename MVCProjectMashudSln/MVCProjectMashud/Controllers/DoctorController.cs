using MVCProjectMashud.Models;
using MVCProjectMashud.Models.DAL;
using MVCProjectMashud.Models.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectMashud.Controllers
{
    public class DoctorController : Controller
    {
        HospitalDBContext DB = new HospitalDBContext();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetDoctorDetails()
        {
            var docList = DB.tblDoctors.Select(d => new DoctorViewModel
            {
                DoctorId = d.DoctorId,
                DoctorName = d.DoctorName,
                Designation = d.Designation
                }).ToList();
            return Json(docList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveDataInToDatabase(DoctorViewModel vobj)
        {
            var result = false;
            if (vobj.DoctorId == 0)
            {
                tblDoctor obj = new tblDoctor();
                obj.DoctorName = vobj.DoctorName;
                obj.Designation = vobj.Designation;
                DB.tblDoctors.Add(obj);
                DB.SaveChanges();
                result = true;
            }
            else
            {
                tblDoctor model = DB.tblDoctors.Where(d => d.DoctorId == vobj.DoctorId).SingleOrDefault();
                model.DoctorName = vobj.DoctorName;
                model.Designation = vobj.Designation;
                DB.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDoctorById(int DoctorId)
        {
            tblDoctor model = DB.tblDoctors.Where(d => d.DoctorId == DoctorId).SingleOrDefault();
            string value = "";
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult GetDetailsDoctorRecord(int DoctorId)
        {
            tblDoctor model = DB.tblDoctors.Where(d => d.DoctorId == DoctorId).SingleOrDefault();
            DoctorViewModel vObj = new DoctorViewModel();
            vObj.DoctorId = model.DoctorId;
            vObj.DoctorName = model.DoctorName;
            vObj.Designation = model.Designation;
            return PartialView("_doctorDetails", vObj);
        }
    }//cs
}//ns