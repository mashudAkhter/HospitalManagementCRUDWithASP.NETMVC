using MVCProjectMashud.BLL.Interfaces;
using MVCProjectMashud.Models;
using MVCProjectMashud.Models.DAL;
using MVCProjectMashud.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjectMashud.BLL.Repositories
{
    public class PatientRepository : IPatientRepositories
    {
        HospitalDBContext DB = new HospitalDBContext();
        public void DeletePatient(int id)
        {
            tblPatient delPat = GetPatientById(id);
            DB.tblPatients.Remove(delPat);
            DB.SaveChanges();
        }

        public List<tblDoctor> GetDoctor()
        {
            List<tblDoctor> docList = DB.tblDoctors.ToList();
            return docList;
        }

        public List<PatientListViewModel> GetPatient()
        {
            List<PatientListViewModel> vl = new List<PatientListViewModel>();
            vl = DB.tblPatients.Select(p => new PatientListViewModel
            {
                PatientId = p.PatientId,
                PatientName = p.PatientName,
                Age = p.Age,
                AdmissionDate = p.AdmissionDate,
                Email = p.Email,
                Bed = p.Bed,
                Cabin = p.Cabin,
                ImageName = p.ImageName,
                ImageUrl = p.ImageUrl,
                DoctorId = p.DoctorId,
                DoctorName = p.tblDoctor.DoctorName
            }).ToList();
            return vl;
        }

        public tblPatient GetPatientById(int id)
        {
            tblPatient pt = DB.tblPatients.SingleOrDefault(p => p.PatientId == id);
            return pt;
        }

        public void SavePatient(tblPatient obj)
        {
            DB.tblPatients.Add(obj);
            DB.SaveChanges();
        }

        public void UpdatePatient(tblPatient obj)
        {
            DB.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }
    }
}