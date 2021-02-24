using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjectMashud.Models.ViewModel
{
    public class EditPatientViewModel
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int Age { get; set; }
        public DateTime AdmissionDate { get; set; }
        public string Email { get; set; }
        public bool Bed { get; set; }
        public bool Cabin { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public List<tblDoctor> docList { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}