using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProjectMashud.Models.ViewModel
{
    public class CreatePatientVIewModel
    {
        public int PatientId { get; set; }
        [Required(ErrorMessage = "Patient name required*")]
        [DataType(DataType.Text)]
        [Display(Name = "Patient Name")]
        [StringLength(40, ErrorMessage ="Patient name Maximum 40 character*")]
        public string PatientName { get; set; }
        [Range(18, 90, ErrorMessage = "Age must be avobe 18")]
        public int Age { get; set; }

        [Display(Name = "Admission Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime AdmissionDate { get; set; }
        [Required(ErrorMessage = "Email address required*")]
        [RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Enter valid email*")]
        public string Email { get; set; }
        [Compare("Email", ErrorMessage ="Email does not match*")]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }
        public bool Bed { get; set; }
        public bool Cabin { get; set; }
        public string ImageName { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }
        public int DoctorId { get; set; }
        public List<tblDoctor> docList { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}