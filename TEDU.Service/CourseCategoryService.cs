using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model.Models;

namespace TEDU.Service
{
    public interface ICourseCategoryService
    {
        IEnumerable<CourseCategory> GetCategories(int page, int pageSize, out int totalRow, string filter = null);

        IEnumerable<CourseCategory> GetCategories();

        CourseCategory GetCategory(int id);

        CourseCategory GetCategory(string name);

        void CreateCategory(CourseCategory category);

        void Delete(CourseCategory category);

        void SaveCategory();

        IEnumerable<CourseCategory> GetHomeCategories(int top);

        CourseCategory GetCategoryByAlias(string alias);
    }

    public class CourseCategoryService : ICourseCategoryService
    {
        private readonly ICourseCategoryRepository courseCategorysRepository;
        private readonly IUnitOfWork unitOfWork;

        public CourseCategoryService(ICourseCategoryRepository courseCategorysRepository, IUnitOfWork unitOfWork)
        {
            this.courseCategorysRepository = courseCategorysRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<CourseCategory> GetCategories(int page, int pageSize, out int totalRow, string filter = null)
        {
            IEnumerable<CourseCategory> model =
                courseCategorysRepository.GetMulti(x => x.Name.Contains(filter));

            totalRow = model.Count();

            return model.Skip(page * pageSize).Take(pageSize);
        }

        public CourseCategory GetCategory(int id)
        {
            var category = courseCategorysRepository.GetSingleById(id);
            return category;
        }

        public CourseCategory GetCategory(string name)
        {
            var category = courseCategorysRepository.GetCategoryByName(name);
            return category;
        }

        public void CreateCategory(CourseCategory category)
        {
            courseCategorysRepository.Add(category);
        }

        public void Delete(CourseCategory category)
        {
            courseCategorysRepository.Delete(category);
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<CourseCategory> GetCategories()
        {
            IEnumerable<CourseCategory> model;
            model = courseCategorysRepository
                   .GetMulti(x => x.Status)
                   .OrderBy(m => m.DisplayOrder)
                   .ToList();

            return model;
        }

        public IEnumerable<CourseCategory> GetHomeCategories(int top)
        {
            IEnumerable<CourseCategory> model;
            model = courseCategorysRepository
                   .GetMulti(x => x.Status && x.ShowHome.HasValue)
                   .Take(top)
                   .OrderByDescending(m => m.ShowHome)
                   .ToList();

            return model;
        }

        public CourseCategory GetCategoryByAlias(string alias)
        {
            var category = courseCategorysRepository.GetSingleByCondition(x => x.Alias == alias);
            return category;
        }

        #endregion ICategoryService Members
    }
}
