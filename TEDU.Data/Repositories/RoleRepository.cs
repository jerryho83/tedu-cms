using TEDU.Data.Infrastructure;
using TEDU.Model.Models;

namespace TEDU.Data.Repositories
{
    public interface IAppRoleRepository : IRepository<AppRole>
    {
    }

    public class AppRoleRepository : RepositoryBase<AppRole>, IAppRoleRepository
    {
        public AppRoleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}