using BlogProject.Infrastructure.Repositories.Interfaces.BaseRepository;
using BlogProject.Model.Entities.Concrete;

namespace BlogProject.Infrastructure.Repositories.Interfaces.EntityTypeRepositories
{
    public interface IAppUserRepository : IBaseRepository<AppUser>
    {
    }
}
