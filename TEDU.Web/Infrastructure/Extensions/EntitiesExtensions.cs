using System;
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

        public static void UpdateCourse(this Course course, CourseViewModel courseVm)
        {
            course.Name = courseVm.Name;

            course.Alias = string.IsNullOrEmpty(courseVm.Alias)
                ? StringHelper.ToUnsignString(courseVm.Name) : courseVm.Alias;

            course.Description = courseVm.Description;
            course.CategoryId = courseVm.CategoryId;
            course.Image = courseVm.Image;
            course.Duration = courseVm.Duration;
            course.Price = courseVm.Price;
            course.PromotionPrice = courseVm.PromotionPrice;
            course.Content = courseVm.Content;
            course.Level = courseVm.Level;
            course.DisplayOrder = courseVm.DisplayOrder;
            course.ViewCount = courseVm.ViewCount;
            course.TrainerId = courseVm.TrainerId;
            course.CreatedDate = courseVm.CreatedDate;
            course.CreateBy = courseVm.CreateBy;
            course.LastModifiedBy = courseVm.LastModifiedBy;
            course.LastModifiedDate = courseVm.LastModifiedDate;
            course.Status = courseVm.Status;

            course.Status = courseVm.Status;
            course.MetaKeyword = courseVm.MetaKeyword;
            course.MetaDescription = courseVm.MetaDescription;
            course.HotFlag = courseVm.HotFlag;
            course.SlideFlag = courseVm.SlideFlag;
        }

        public static void UpdateAppGroup(this AppGroup appGroup, AppGroupViewModel appGroupViewModel)
        {
            appGroup.Id = appGroupViewModel.Id;
            appGroup.Name = appGroupViewModel.Name;
        }
        public static void UpdateAppRole(this AppRole appRole, AppRoleViewModel appRoleViewModel, string action = "add")
        {
            if (action == "update")
                appRole.Id = appRoleViewModel.Id;
            else
                appRole.Id = Guid.NewGuid().ToString();
            appRole.Name = appRoleViewModel.Name;
            appRole.Description = appRoleViewModel.Description;
        }
        public static void UpdateUser(this AppUser appUser, AppUserViewModel appUserViewModel, string action = "add")
        {

            appUser.Id = appUserViewModel.Id;
            appUser.FullName = appUserViewModel.FullName;
            appUser.BirthDate = appUserViewModel.BirthDate;
            appUser.Bio = appUserViewModel.Bio;
            appUser.Email = appUserViewModel.Email;
            appUser.UserName = appUserViewModel.UserName;
            appUser.PhoneNumber = appUserViewModel.PhoneNumber;
        }

        public static void UpdateTrainer(this Trainer trainer, TrainerViewModel appUserViewModel, string action = "add")
        {

            trainer.ID = appUserViewModel.ID;
            trainer.Name = appUserViewModel.Name;
            trainer.Portfolio = appUserViewModel.Portfolio;
            trainer.Image = appUserViewModel.Image;
            trainer.JobTitle = appUserViewModel.JobTitle;
        }

        public static void UpdateCourseVideo(this CourseVideo courseVideo, CourseVideoViewModel courseVideoViewModel, string action = "add")
        {
            courseVideo.ID = courseVideoViewModel.ID;
            courseVideo.Name = courseVideoViewModel.Name;
            courseVideo.Alias = courseVideoViewModel.Alias;
            courseVideo.Path = courseVideoViewModel.Path;
            courseVideo.Duration = courseVideoViewModel.Duration;
            courseVideo.SlidePath = courseVideoViewModel.SlidePath;
            courseVideo.SourceCodePath = courseVideoViewModel.SourceCodePath;
            courseVideo.Reference = courseVideoViewModel.Reference;
            courseVideo.CourseId = courseVideoViewModel.CourseId;
            courseVideo.Chapter = courseVideoViewModel.Chapter;
            courseVideo.DisplayOrder = courseVideoViewModel.DisplayOrder;
            courseVideo.AllowTrialView = courseVideoViewModel.AllowTrialView;
            courseVideo.TrialViewTime = courseVideoViewModel.TrialViewTime;
            if(action=="add")
            {
                courseVideo.CreatedDate = DateTime.Now;
            }
            else
            {
                courseVideo.LastModifiedDate = DateTime.Now;
            }
            courseVideo.Status = courseVideoViewModel.Status;
        }
    }
}