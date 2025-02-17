﻿using System.ComponentModel.DataAnnotations;

namespace BlogProject.Web.Areas.Admin.Models.DTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Boş Bırakılamaz !")]
        [MinLength(3, ErrorMessage = "Min 3 Karakter")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [MinLength(3, ErrorMessage = "Min 3 Karakter")]
        public string Description { get; set; }
    }
}
