using Application.Baskets.DTO;
using AutoMapper;
using Domain.Baskets;

namespace Infrastructure.AutoMapperConfigs
{
  public  class BasketMapperConfig : Profile
    {

        public BasketMapperConfig()
        {
            CreateMap<BasketDataModel, Basket>().ReverseMap();
            CreateMap<BasketItemDataModel, BasketItem>().ReverseMap();
        }
    }
}
