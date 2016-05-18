using System;
using System.Linq;
using TEDU.Data.Infrastructure;
using TEDU.Model;

namespace TEDU.Data.Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory dbFactory)
            : base(dbFactory)
        { }

        public Category GetCategoryByName(string categoryName)
        {
            var category = this.DbContext.Categories.Where(c => c.Name == categoryName).FirstOrDefault();

            return category;
        }

        public override void Update(Category entity)
        {
            entity.LastModifiedDate = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryByName(string categoryName);
    }
}