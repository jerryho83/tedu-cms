using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Data.Infrastructure;
using TEDU.Model.Models;

namespace TEDU.Data.Repositories
{
    public interface IAppRoleGroupRepository : IRepository<AppRoleGroup>
    {
    }

    public class AppRoleGroupRepository : RepositoryBase<AppRoleGroup>, IAppRoleGroupRepository
    {
        public AppRoleGroupRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
