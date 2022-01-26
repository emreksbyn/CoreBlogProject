using System;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.Web.Areas.Admin.Models.DTOs
{
    public class UpdateCategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz!")]
        [MinLength(3, ErrorMessage = "Min 3 Karakter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bu Alan Boş Bırakılamaz!")]
        [MinLength(3, ErrorMessage = "Min 3 Karakter")]
        public string Description { get; set; }

        public DateTime? CreateDate { get; set; }
        public string CreatedComputerName { get; set; }
        public string CreatedIp { get; set; }

    }
}
