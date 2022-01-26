using BlogProject.Infrastructure.Context;
using BlogProject.Infrastructure.Repositories.Abstract;
using BlogProject.Infrastructure.Repositories.Interfaces.EntityTypeRepositories;
using BlogProject.Model.Entities.Concrete;

namespace BlogProject.Infrastructure.Repositories.Concretes
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
