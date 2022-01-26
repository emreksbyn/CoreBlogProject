using BlogProject.Infrastructure.Context;
using BlogProject.Infrastructure.Repositories.Abstract;
using BlogProject.Infrastructure.Repositories.Interfaces.EntityTypeRepositories;
using BlogProject.Model.Entities.Concrete;

namespace BlogProject.Infrastructure.Repositories.Concretes
{
    public class ArticleRepository : BaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
