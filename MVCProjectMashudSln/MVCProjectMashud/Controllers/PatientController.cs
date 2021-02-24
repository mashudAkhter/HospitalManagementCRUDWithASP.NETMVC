using MVCProjectMashud.BLL.Repositories;
using MVCProjectMashud.Models;
using MVCProjectMashud.Models.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectMashud.Controllers
{
    public class PatientController : Controller
    {
        PatientRepository repo = new PatientRepository();
        public PatientController()
        {

        }
        public PatientController(PatientRepository obj)
        {
            repo = obj;
        }
        public ActionResult Index(string SearchString, string CurrentFilter, string SortOrder, int? Page)
        {
            ViewBag.SortNameParam = string.IsNullOrEmpty(SortOrder) ? "name_desc" : "";
            if (SearchString != null)
            {
                Page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            ViewBag.CurrentFilter = SearchString;
            List<PatientListViewModel> patList = repo.GetPatient();

            if (!string.IsNullOrEmpty(SearchString))
            {
                patList = patList.Where(n => n.PatientName.ToUpper()
                .Contains(SearchString.ToUpper())).ToList();
            }
            switch (SortOrder)
            {
                case "name_desc":
                    patList = patList.OrderByDescending(n => n.PatientName).ToList();
                    break;
                default:
                    patList = patList.OrderBy(n => n.PatientName).ToList();
                    break;

            }
            int PageSize = 3;
            int PageNumber = (Page ?? 1);
            return View("Index", patList.ToPagedList(PageNumber, PageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {
            CreatePatientVIewModel createPt = new CreatePatientVIewModel();
            createPt.docList = repo.GetDoctor();
            return View(createPt);
        }
        public ActionResult AddOrEdit(CreatePatientVIewModel viewObj)
        {
            var result = false;
            string filename = Path.GetFileNameWithoutExtension(viewObj.ImageFile.FileName);
            string extension = Path.GetExtension(viewObj.ImageFile.FileName);
            string fileWithExtension = filename + extension;
            tblPatient patientObj = new tblPatient();
            patientObj.PatientName = viewObj.PatientName;
            patientObj.Age = viewObj.Age;
            patientObj.AdmissionDate = viewObj.AdmissionDate;
            patientObj.Email = viewObj.Email;
            patientObj.Bed = viewObj.Bed;
            patientObj.Cabin = viewObj.Cabin;
            patientObj.DoctorId = viewObj.DoctorId;
            patientObj.ImageUrl = "~/Images/" + fileWithExtension;
            patientObj.ImageName = fileWithExtension;
            string fileWithServerPath = Path.Combine(Server.MapPath("~/Images/" + filename + extension));
            viewObj.ImageFile.SaveAs(fileWithServerPath);
            if (ModelState.IsValid)
            {
                if (viewObj.PatientId == 0)
                {
                    repo.SavePatient(patientObj);
                    result = true;
                }
                else
                {
                    patientObj.PatientId = viewObj.PatientId;
                    repo.UpdatePatient(patientObj);
                    result = true;
                }
            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (viewObj.PatientId == 0)
                {
                    return View("Create");
                }
                else
                {
                    return View("Edit");
                }

            }
        }
        [Authorize(Roles = ("Admin, SuperAdmin"))]
        public ActionResult Edit(int id)
        {
            tblPatient patObj = repo.GetPatientById(id);
            CreatePatientVIewModel viewObj = new CreatePatientVIewModel();

            viewObj.PatientId = patObj.PatientId;
            viewObj.PatientName = patObj.PatientName;
            viewObj.Age = patObj.Age;
            viewObj.AdmissionDate = patObj.AdmissionDate;
            viewObj.Email = patObj.Email;
            viewObj.Bed = patObj.Bed;
            viewObj.Cabin = patObj.Cabin;
            viewObj.ImageName = patObj.ImageName;
            viewObj.ImageUrl = patObj.ImageUrl;
            viewObj.DoctorId = patObj.DoctorId;
            viewObj.docList = repo.GetDoctor();
            return View(viewObj);
        }
        [Authorize(Roles = ("Admin, SuperAdmin"))]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            tblPatient patObj = repo.GetPatientById(id);
            CreatePatientVIewModel viewObj = new CreatePatientVIewModel();

            viewObj.PatientId = patObj.PatientId;
            viewObj.PatientName = patObj.PatientName;
            viewObj.Age = patObj.Age;
            viewObj.AdmissionDate = patObj.AdmissionDate;
            viewObj.Email = patObj.Email;
            viewObj.Bed = patObj.Bed;
            viewObj.Cabin = patObj.Cabin;
            viewObj.ImageName = patObj.ImageName;
            viewObj.ImageUrl = patObj.ImageUrl;
            viewObj.DoctorId = patObj.DoctorId;
            viewObj.docList = repo.GetDoctor();
            return View(viewObj);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            tblPatient patObj = repo.GetPatientById(id);
            if (patObj != null)
            {
                repo.DeletePatient(patObj.PatientId);
                return RedirectToAction("Index");
            }
            return View();

        }
        public PartialViewResult Details(int PatientId)
        {
            tblPatient patObj = repo.GetPatientById(PatientId);
            PatientListViewModel viewObj = new PatientListViewModel();
            viewObj.PatientId = patObj.PatientId;
            viewObj.PatientName = patObj.PatientName;
            viewObj.Age = patObj.Age;
            viewObj.AdmissionDate = patObj.AdmissionDate;
            viewObj.Email = patObj.Email;
            viewObj.Bed = patObj.Bed;
            viewObj.Cabin = patObj.Cabin;
            viewObj.ImageName = patObj.ImageName;
            viewObj.ImageUrl = patObj.ImageUrl;
            viewObj.DoctorId = patObj.DoctorId;

            return PartialView("_DetailsRecord", viewObj);
        }
    }//cs
}//ns