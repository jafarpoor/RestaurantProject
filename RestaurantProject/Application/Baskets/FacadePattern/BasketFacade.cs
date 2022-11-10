using Application.Baskets.Commands;
using Application.Interfaces;
using Application.Interfaces.Baskets;
using Application.UriComposer;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Baskets.FacadePattern
{
  public  class BasketFacade : IBasket
    {
        private readonly IDatabaseContext _dataBaseContxt;
        private readonly IUriComposerService _uriComposerService;
        private readonly IMapper _mapper;
        public BasketFacade(IDatabaseContext dataBaseContxt, IUriComposerService uriComposerService , IMapper mapper)
        {
            _dataBaseContxt = dataBaseContxt;
            _uriComposerService = uriComposerService;
            _mapper = mapper;
        }


        private IBasketService _basketService;
        public IBasketService basketService
        {
            get
            {
              return  _basketService = _basketService ?? new BasketService(_dataBaseContxt, _uriComposerService, _mapper);
            }
        }
    }
}
