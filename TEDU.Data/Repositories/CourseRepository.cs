using TEDU.Data.Infrastructure;
using TEDU.Model.Models;

namespace TEDU.Data.Repositories
{
    public class CourseRepository : RepositoryBase<Course>, ICourseRepository
    {
        public CourseRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }
    }

    public interface ICourseRepository : IRepository<Course>
    {
    }
}