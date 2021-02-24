using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCProjectMashud.Models
{
    public class tblDoctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string Designation { get; set; }
        public virtual ICollection<tblPatient> tblPatients { get; set; }
    }
}