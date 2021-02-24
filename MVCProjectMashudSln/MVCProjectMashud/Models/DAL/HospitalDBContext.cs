using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCProjectMashud.Models.DAL
{
    public class HospitalDBContext : DbContext
    {
        

        public HospitalDBContext() : base("name = HospitalDBContext") { }

        public virtual DbSet<tblDoctor> tblDoctors { get; set; }
        public virtual DbSet<tblPatient> tblPatients { get; set; }
        public virtual DbSet<tblUser> tblUsers { get; set; }
        public virtual DbSet<tblRole> tblRoles { get; set; }
        public virtual DbSet<tblDepartment> tblDepartments { get; set; }
    }
}