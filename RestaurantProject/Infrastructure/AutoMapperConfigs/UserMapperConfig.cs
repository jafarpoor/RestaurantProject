using Application.Categories.DTO;
using Application.Users.DTO;
using AutoMapper;
using Domain.Categories;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.AutoMapperConfigs
{
  public  class UserMapperConfig : Profile
    {
        public UserMapperConfig()
        {
            CreateMap<RegisterDataModel, User>().ReverseMap();
            CreateMap<List<ListCategoryDataModel>, Category>().ReverseMap();
            CreateMap<User , EditUserDataModel>().ReverseMap();
            CreateMap<User, ListUsersDataModel>();
        }
    }
       
}
