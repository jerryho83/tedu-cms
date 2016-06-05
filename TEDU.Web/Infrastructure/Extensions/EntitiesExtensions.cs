using TEDU.Common;
using TEDU.Common.Helper;
using TEDU.Model;
using TEDU.Model.Models;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Infrastructure.Extensions
{
    public static class EntitiesExtensions
    {
        public static void UpdatePage(this Page page, PageViewModel pageVM)
        {
            page.Name = pageVM.Name;
            page.Alias = string.IsNullOrEmpty(pageVM.Alias) ? StringHelper.ToUnsignString(pageVM.Name) : pageVM.Alias;
            page.Content = pageVM.Content;
            page.CreatedDate = pageVM.CreatedDate;
            page.CreateBy = pageVM.CreateBy;
            page.Status = pageVM.Status;

            page.MetaKeyword = pageVM.MetaKeyword;
            page.MetaDescription = pageVM.MetaDescription;
        }

        public static void UpdateEbook(this Ebook ebook, EbookViewModel ebookVm)
        {
            ebook.Name = ebookVm.Name;
            ebook.Alias = string.IsNullOrEmpty(ebookVm.Alias) ? StringHelper.ToUnsignString(ebookVm.Name) : ebookVm.Alias;
            ebook.Image = ebookVm.Image;
            ebook.CreatedDate = ebookVm.CreatedDate;
            ebook.CreatedBy = ebookVm.CreatedBy;
            ebook.Description = ebookVm.Description;
            ebook.Content = ebookVm.Content;
            ebook.Status = ebookVm.Status;
            ebook.DownloadLink = ebookVm.DownloadLink;
            ebook.DisplayOrder = ebookVm.DisplayOrder;
            ebook.Status = ebookVm.Status;

            ebook.MetaKeyword = ebookVm.MetaKeyword;
            ebook.MetaDescription = ebookVm.MetaDescription;
        }

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
            category.ShowHome = categoryVm.ShowHome;
        }
        public static void UpdateCourseCategory(this CourseCategory category, CourseCategoryViewModel categoryVm)
        {
            category.Name = categoryVm.Name;
            category.Alias = string.IsNullOrEmpty(categoryVm.Alias) ? StringHelper.ToUnsignString(categoryVm.Name) : categoryVm.Alias;
            category.DisplayOrder = categoryVm.DisplayOrder;
            category.Status = categoryVm.Status;
            category.MetaKeyword = categoryVm.MetaKeyword;
            category.MetaDescription = categoryVm.MetaDescription;
            category.ShowHome = categoryVm.ShowHome;
        }

        public static void UpdatePost(this Post post, PostViewModel postVm, string action = "add")
        {
            post.Name = postVm.Name;
            post.Alias = string.IsNullOrEmpty(postVm.Alias) ? StringHelper.ToUnsignString(postVm.Name) : postVm.Alias;
            post.Description = postVm.Description;
            post.CategoryID = postVm.CategoryID;
            post.Image = postVm.Image;
            post.Content = postVm.Content;
            post.PostType = postVm.PostType;
            post.CreatedDate = postVm.CreatedDate;
            post.CreateBy = postVm.CreateBy;
            post.LastModifiedBy = postVm.LastModifiedBy;
            post.LastModifiedDate = postVm.LastModifiedDate;
            post.Source = postVm.Source;
            post.Status = postVm.Status;
            post.Tags = postVm.Tags;
            post.OtherStatus = postVm.OtherStatus;

            post.Status = postVm.Status;
            post.MetaKeyword = postVm.MetaKeyword;
            post.MetaDescription = postVm.MetaDescription;
            post.PostType = PostTypeEnum.Article.ToString();
            post.HotFlag = postVm.HotFlag;
            post.SlideFlag = postVm.SlideFlag;
        }
    }
}