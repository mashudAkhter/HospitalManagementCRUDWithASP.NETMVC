using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProjectMashud.Models.ViewModel
{
    public class UserRoleViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string RollName { get; set; }
    }
}