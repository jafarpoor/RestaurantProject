using Application.Categories.DTO;
using AutoMapper;
using Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
