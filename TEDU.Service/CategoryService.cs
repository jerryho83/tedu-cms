using System.Collections.Generic;
using System.Linq;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model;

namespace TEDU.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(int page, int pageSize, out int totalRow, string filter = null);

        IEnumerable<Category> GetCategories();

        Category GetCategory(int id);

        Category GetCategory(string name);

        void CreateCategory(Category category);

        void Delete(Category category);

        void SaveCategory();

        IEnumerable<Category> GetHomeCategories(int top);

        Category GetCategoryByAlias(string alias);
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categorysRepository;
        private readonly IUnitOfWork unitOfWork;

        public CategoryService(ICategoryRepository categorysRepository, IUnitOfWork unitOfWork)
        {
            this.categorysRepository = categorysRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Category> GetCategories(int page, int pageSize, out int totalRow, string filter = null)
        {
            IQueryable<Category> model;
            if (!string.IsNullOrEmpty(filter))
            {
                model = categorysRepository.GetMulti(x => x.Name.Contains(filter));
            }
            else
            {
                model = categorysRepository.GetAll();
            }
            totalRow = model.Count();

            return model.OrderByDescending(x=>x.CreatedDate).Skip(page * pageSize).Take(pageSize);
        }

        public Category GetCategory(int id)
        {
            var category = categorysRepository.GetSingleById(id);
            return category;
        }

        public Category GetCategory(string name)
        {
            var category = categorysRepository.GetCategoryByName(name);
            return category;
        }

        public void CreateCategory(Category category)
        {
            categorysRepository.Add(category);
        }

        public void Delete(Category category)
        {
            categorysRepository.Delete(category);
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }

        public IEnumerable<Category> GetCategories()
        {
            IEnumerable<Category> model;
            model = categorysRepository
                   .GetMulti(x => x.Status)
                   .OrderBy(m => m.ParentID)
                   .ToList();

            return model;
        }

        public IEnumerable<Category> GetHomeCategories(int top)
        {
            IEnumerable<Category> model;
            model = categorysRepository
                   .GetMulti(x => x.Status && x.ShowHome.HasValue)
                   .Take(top)
                   .OrderByDescending(m => m.ShowHome)
                   .ToList();

            return model;
        }

        public Category GetCategoryByAlias(string alias)
        {
            var category = categorysRepository.GetSingleByCondition(x => x.Alias == alias);
            return category;
        }

        #endregion ICategoryService Members
    }
}