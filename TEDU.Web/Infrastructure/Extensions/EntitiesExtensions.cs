using TEDU.Model;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Infrastructure.Extensions
{
    public static class EntitiesExtensions
    {
        public static void UpdateCategory(this Category category, CategoryViewModel categoryVm)
        {
            category.Name = categoryVm.Name;
            category.Alias = categoryVm.Alias;
            category.ParentID = categoryVm.ParentID;
            category.CreatedDate = categoryVm.CreatedDate;
            category.CreatedBy = categoryVm.CreatedBy;
            category.LastModifiedBy = categoryVm.LastModifiedBy;
            category.LastModifiedDate = categoryVm.LastModifiedDate;
            category.Status = categoryVm.Status;
        }
    }
}