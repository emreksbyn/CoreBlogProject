using BlogProject.Infrastructure.Repositories.Interfaces.EntityTypeRepositories;
using BlogProject.Model.Entities.Concrete;
using BlogProject.Web.Areas.Member.Models.VMs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;

namespace BlogProject.Web.Areas.Member.Controllers
{
    [Area("Member")]
    public class CommentController : Controller
    {
        private readonly ICommentRepository _commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            this._commentRepository = commentRepository;
        }

        public JsonResult AddComment(string userComment, int articleId)
        {
            Comment comment = new Comment();
            //Login olmuş kullanıcının username'sinden Id'isni yakalayacağız
            comment.AppUserId = 2;
            comment.Text = userComment;
            comment.ArticleId = articleId;
            _commentRepository.Create(comment);
            return Json("");
        }

        public JsonResult GetArticleComment(int id)
        {

            var comment = _commentRepository.GetByDefaults(
                selector: x => new CommentListVM
                {
                    AppUserImage = x.AppUser.Image,
                    FullName = x.AppUser.FullName,
                    CreateDate = x.CreateDate,
                    CommentText = x.Text,
                    CommentCount = x.Article.Comments.Count
                },
                orderby: x => x.OrderByDescending(z => z.CreateDate),
                expression: x => x.ArticleId == id).Take(1);



            return Json(JsonConvert.SerializeObject(comment));
        }

        public JsonResult DeleteComment(int id)
        {
            Comment comment = _commentRepository.GetDefault(x => x.Id == id);
            _commentRepository.Delete(comment);
            return Json("");
        }
    }
}
