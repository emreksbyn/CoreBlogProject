using AutoMapper;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Areas.Admin.Models.DTOs;
using BlogProject.Web.Areas.Admin.Models.VMs;
using BlogProject.Web.Areas.Member.Models.VMs;

namespace BlogProject.Web.Models.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, UpdateCategoryDTO>().ReverseMap();
            CreateMap<Category, GetCategoryVM>().ReverseMap();

            CreateMap<AppUser, CreateAppUserDTO>().ReverseMap();
            CreateMap<AppUser, GetUserVM>().ReverseMap();
            CreateMap<AppUser, GetAppUserDetailsVM>().ReverseMap();

            CreateMap<Article, CreateArticleDTO>().ReverseMap();
            CreateMap<Article, GetArticleVM>().ReverseMap();
            CreateMap<Article, GetHomeArticleVM>().ReverseMap();

            CreateMap<Comment, CommentListVM>().ReverseMap();
        }
    }
}
