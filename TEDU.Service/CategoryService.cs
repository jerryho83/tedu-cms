using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEDU.Data.Infrastructure;
using TEDU.Data.Repositories;
using TEDU.Model;

namespace TEDU.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(int page, int pageSize, out int totalRow, string filter = null);
        Category GetCategory(int id);
        Category GetCategory(string name);
        void CreateCategory(Category category);
        void SaveCategory();
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
            IEnumerable<Category> model;
            if (!string.IsNullOrEmpty(filter))
            {
                model = categorysRepository
                    .GetMany(m => m.Name.ToLower()
                    .Contains(filter.ToLower().Trim()))
                    .OrderBy(m => m.ID)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                totalRow = categorysRepository
                    .GetMany(m => m.Name.ToLower()
                    .Contains(filter.ToLower().Trim()))
                    .Count();
            }
            else
            {
                model = categorysRepository
                    .GetAll()
                    .OrderBy(m => m.ID)
                    .Skip(page * pageSize)
                    .Take(pageSize)
                    .ToList();

                totalRow = categorysRepository.GetAll().Count();
            }

            return model;
        }

        public Category GetCategory(int id)
        {
            var category = categorysRepository.GetById(id);
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

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}