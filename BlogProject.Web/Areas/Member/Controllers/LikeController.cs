using BlogProject.Infrastructure.Repositories.Interfaces.EntityTypeRepositories;
using BlogProject.Model.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject.Web.Areas.Member.Controllers
{
    public class LikeController : Controller
    {
        private readonly ILikeRepository _likeRepository;

        public LikeController(ILikeRepository likeRepository)
        {
            this._likeRepository = likeRepository;
        }

        public JsonResult AddLike(int id)
        {
            Like like = new Like();
            like.AppUserId = 1;
            like.ArticleId = id;
            _likeRepository.Create(like);
            return Json("");
        }
    }
}
