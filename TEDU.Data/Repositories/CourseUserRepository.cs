using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Data.Infrastructure;
using TEDU.Model.Models;

namespace TEDU.Data.Repositories
{
    public class CourseUserRepository : RepositoryBase<CourseUser>, ICourseUserRepository
    {
        public CourseUserRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }
    }

    public interface ICourseUserRepository : IRepository<CourseUser>
    {
    }
}
