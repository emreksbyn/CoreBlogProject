using System;

namespace BlogProject.Web.Areas.Admin.Models.DTOs
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string FullName { get; set; }
        public string UserImage { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
