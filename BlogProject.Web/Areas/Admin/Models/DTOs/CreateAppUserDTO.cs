using BlogProject.Model.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogProject.Web.Areas.Admin.Models.DTOs
{
    public class CreateAppUserDTO
    {
        [Required(ErrorMessage ="Boş Bırakılamaz!")]
        [MinLength(3,ErrorMessage ="Min 3 Karakter")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [MinLength(3, ErrorMessage = "Min 3 Karakter")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [MinLength(3, ErrorMessage = "Min 3 Karakter")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        [MinLength(3, ErrorMessage = "Min 3 Karakter")]
        public string Password { get; set; }

        public Role Role { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImagePath{ get; set; }
    }
}
