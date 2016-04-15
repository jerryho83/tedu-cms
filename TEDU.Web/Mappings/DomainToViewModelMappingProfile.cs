using AutoMapper;
using TEDU.Model;
using TEDU.Model.Models;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Category, CategoryViewModel>();
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();
        }
    }
}