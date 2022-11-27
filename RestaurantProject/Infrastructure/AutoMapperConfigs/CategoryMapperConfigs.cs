using Application.Categories.DTO;
using AutoMapper;
using Domain.Categories;
using System.Collections.Generic;

namespace Infrastructure.AutoMapperConfigs
{
   public class CategoryMapperConfigs : Profile
    {

        public CategoryMapperConfigs()
        {
            CreateMap<List<ListCategoryDataModel>, Category>().ReverseMap();

            CreateMap<CategoryItemImage, AddNewCategoryItemImageDataModel>().ReverseMap();
            CreateMap<CategoryItem, AddCategoryItemDataModel>()
                    .ForMember(opt => opt.addNewCatalogItemImageDataModel, opt =>
                     opt.MapFrom(src => src.CategoryItemImage)).ReverseMap();
        }
        
    }
}
