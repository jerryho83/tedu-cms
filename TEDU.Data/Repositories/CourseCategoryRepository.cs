using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Data.Infrastructure;
using TEDU.Model.Models;

namespace TEDU.Data.Repositories
{
    public class CourseCategoryRepository : RepositoryBase<CourseCategory>, ICourseCategoryRepository
    {
        public CourseCategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

        public CourseCategory GetCategoryByName(string categoryName)
        {
            var category = this.DbContext.CourseCategories.Where(c => c.Name == categoryName).FirstOrDefault();

            return category;
        }

        public override void Update(CourseCategory entity)
        {
            base.Update(entity);
        }
    }

    public interface ICourseCategoryRepository : IRepository<CourseCategory>
    {
        CourseCategory GetCategoryByName(string categoryName);
    }
}
