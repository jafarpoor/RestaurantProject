using Application.Baskets.DTO;
using AutoMapper;
using Domain.Baskets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
