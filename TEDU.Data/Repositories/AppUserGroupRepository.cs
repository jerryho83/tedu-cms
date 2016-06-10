using TEDU.Data.Infrastructure;
using TEDU.Model.Models;

namespace TEDU.Data.Repositories
{
    public interface IAppUserGroupRepository : IRepository<AppUserGroup>
    {
    }

    public class AppUserGroupRepository : RepositoryBase<AppUserGroup>, IAppUserGroupRepository
    {
        public AppUserGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}