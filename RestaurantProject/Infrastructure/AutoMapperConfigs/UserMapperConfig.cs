using Application.Users.DTO;
using AutoMapper;
using Domain.Orders;
using Domain.Users;


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
