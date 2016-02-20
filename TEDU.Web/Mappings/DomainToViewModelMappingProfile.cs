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
#pragma warning disable CS0618 // Type or member is obsolete
            Mapper.CreateMap<Category, CategoryViewModel>();
#pragma warning restore CS0618 // Type or member is obsolete
            Mapper.CreateMap<Post, PostViewModel>();
        }
    }
}