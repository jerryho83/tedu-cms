using AutoMapper;
using TEDU.Model;
using TEDU.Model.Models;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();

            Mapper.CreateMap<Ebook, EbookViewModel>();
            Mapper.CreateMap<Page, PageViewModel>();
            Mapper.CreateMap<CourseCategory, CourseCategoryViewModel>();
            Mapper.CreateMap<Course, CourseViewModel>();
            Mapper.CreateMap<AppGroup, AppGroupViewModel>();
            Mapper.CreateMap<AppRole, AppRoleViewModel>();
            Mapper.CreateMap<AppUser, AppUserViewModel>();
            Mapper.CreateMap<AppUserGroup, AppUserGroupViewModel>();
            Mapper.CreateMap<Trainer, TrainerViewModel>();
            Mapper.CreateMap<CourseVideo, CourseVideoViewModel>();
            Mapper.CreateMap<TechLine, TechLineViewModel>();
            Mapper.CreateMap<CourseUser, CourseUserViewModel>();

        }
    }
}