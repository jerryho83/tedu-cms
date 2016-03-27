using TEDU.Common.Helper;
using TEDU.Model;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Infrastructure.Extensions
{
    public static class EntitiesExtensions
    {
        public static void UpdateCategory(this Category category, CategoryViewModel categoryVm)
        {
            category.Name = categoryVm.Name;
            category.Alias = string.IsNullOrEmpty(categoryVm.Alias) ? StringHelper.ToUnsignString(categoryVm.Name) : categoryVm.Alias;
            category.ParentID = categoryVm.ParentID;
            category.CreatedDate = categoryVm.CreatedDate;
            category.CreatedBy = categoryVm.CreatedBy;
            category.LastModifiedBy = categoryVm.LastModifiedBy;
            category.LastModifiedDate = categoryVm.LastModifiedDate;
            category.Status = categoryVm.Status;
            category.MetaKeyword = categoryVm.MetaKeyword;
            category.MetaDescription = categoryVm.MetaDescription;

        }

        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.Name = postVm.Name;
            post.Alias = string.IsNullOrEmpty(postVm.Alias) ? StringHelper.ToUnsignString(postVm.Name) : postVm.Alias;
            post.Description = postVm.Description;
            post.CategoryID = postVm.CategoryID;
            post.Image = postVm.Image;
            post.Content = postVm.Content;
            post.PostType = postVm.PostType;

            post.Source = postVm.Source;
            post.Status = postVm.Status;
            post.Tags = postVm.Tags;
            post.OtherStatus = postVm.OtherStatus;
            
            post.Status = postVm.Status;
            post.MetaKeyword = postVm.MetaKeyword;
            post.MetaDescription = postVm.MetaDescription;

        }
    }
}