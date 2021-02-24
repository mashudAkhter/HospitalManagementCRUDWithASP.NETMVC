using System;
using System.ComponentModel.DataAnnotations;

namespace MVCProjectMashud.Models
{
    public class tblPatient
    {
        [Key]
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

        public tblDoctor tblDoctor { get; set; }
    }
}