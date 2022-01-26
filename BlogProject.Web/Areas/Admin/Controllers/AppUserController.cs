using AutoMapper;
using BlogProject.Infrastructure.Repositories.Interfaces.EntityTypeRepositories;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Model.Enums;
using BlogProject.Web.Areas.Admin.Models.DTOs;
using BlogProject.Web.Areas.Admin.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppUserController : Controller
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserRepository appUserRepository, IMapper mapper)
        {
            this._appUserRepository = appUserRepository;
            this._mapper = mapper;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateAppUserDTO model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<AppUser>(model);

                if (model.ImagePath != null)
                {
                    using var image = Image.Load(model.ImagePath.OpenReadStream());
                    image.Mutate(x => x.Resize(256, 256));
                    image.Save($"wwwroot/images/{user.UserName}.jpg");
                    user.Image = ($"/images/{user.UserName}.jpg");
                    _appUserRepository.Create(user);
                    return RedirectToAction("List");
                }
                else
                {
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult List()
        {
            var user = _appUserRepository.GetByDefaults(
                selector: x => new GetUserVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    UserName = x.UserName,
                    Password = x.Password,
                    Role = x.Role,
                    Image = x.Image
                },
                expression: x => x.Status != Status.Passive);
            return View(user);
        }

        public IActionResult Details(int id)
        {
            var appUserDetail = _appUserRepository.GetByDefault(
                selector: x => new GetAppUserDetailsVM
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Image = x.Image,
                    Role = x.Role,
                    UserName = x.UserName,
                    CreateDate = x.CreateDate
                },
                expression: x => x.Id == id);
            return View(appUserDetail);
        }
    }
}
