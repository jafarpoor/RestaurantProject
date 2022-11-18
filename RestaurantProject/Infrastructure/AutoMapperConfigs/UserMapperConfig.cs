using Application.Categories.DTO;
using Application.Users.DTO;
using AutoMapper;
using Domain.Categories;
using Domain.Orders;
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
            CreateMap<User , EditUserDataModel>().ReverseMap();
            CreateMap<User, ListUsersDataModel>();
            CreateMap<UserAddress, GetUserAddressDataModel>().ReverseMap();
            CreateMap<UserAddress, AddUserAddressDataModel>().ReverseMap();
            CreateMap<UserAddress, EditUserAddressDataModel>().ReverseMap();
            CreateMap<Address, UserAddress>().ReverseMap();
        }
    }
       
}
