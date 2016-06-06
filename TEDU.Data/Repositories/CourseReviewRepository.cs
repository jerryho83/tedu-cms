using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Data.Infrastructure;
using TEDU.Model.Models;

namespace TEDU.Data.Repositories
{
    public class CourseReviewRepository : RepositoryBase<CourseReview>, ICourseReviewRepository
    {
        public CourseReviewRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }
    }

    public interface ICourseReviewRepository : IRepository<CourseReview>
    {
    }
}
