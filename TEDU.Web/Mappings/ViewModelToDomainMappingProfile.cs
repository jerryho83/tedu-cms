using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TEDU.Model;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Mappings
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<PostFormViewModel, Post>()
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                .ForMember(g => g.Description, map => map.MapFrom(vm => vm.Description))
                .ForMember(g => g.Image, map => map.MapFrom(vm => vm.Image.FileName))
                .ForMember(g => g.CategoryID, map => map.MapFrom(vm => vm.CategoryID));
        }
    }
}