using TEDU.Data.Infrastructure;
using TEDU.Model.Models;

namespace TEDU.Data.Repositories
{
    public interface IAppGroupRepository : IRepository<AppGroup>
    {
    }

    public class AppGroupRepository : RepositoryBase<AppGroup>, IAppGroupRepository
    {
        public AppGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}