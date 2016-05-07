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
        }
    }
}