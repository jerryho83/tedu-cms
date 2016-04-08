using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEDU.Model;
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
        }
    }
}