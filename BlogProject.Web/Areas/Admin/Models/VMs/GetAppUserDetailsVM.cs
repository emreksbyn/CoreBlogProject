using BlogProject.Model.Enums;
using System;

namespace BlogProject.Web.Areas.Admin.Models.VMs
{
    public class GetAppUserDetailsVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public Role Role { get; set; }
        public string Image { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
