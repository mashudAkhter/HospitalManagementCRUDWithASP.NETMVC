using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjectMashud.Models
{
    public class tblRole
    {
        public int Id { get; set; }
        public string RollName { get; set; }
        public int UserId { get; set; }
        public virtual tblUser tblUser { get; set; }
    }
}