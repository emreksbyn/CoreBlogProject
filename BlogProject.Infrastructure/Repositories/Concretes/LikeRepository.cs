using BlogProject.Infrastructure.Context;
using BlogProject.Infrastructure.Repositories.Abstract;
using BlogProject.Infrastructure.Repositories.Interfaces.EntityTypeRepositories;
using BlogProject.Model.Entities.Concrete;

namespace BlogProject.Infrastructure.Repositories.Concretes
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
