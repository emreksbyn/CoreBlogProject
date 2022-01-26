using System;

namespace BlogProject.Web.Areas.Member.Models.VMs
{
    public class CommentListVM
    {
        public string AppUserImage { get; set; }
        public string FullName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CommentText { get; set; }
        public int CommentCount { get; set; }
    }
}
