using Application.Baskets.Commands;
using Application.Baskets.Queries;
using Application.Interfaces;
using Application.Interfaces.Baskets;
using Application.UriComposer;
using AutoMapper;

namespace Application.Baskets.FacadePattern
{
  public  class BasketFacade : IBasketFacade
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


        private IAddOrGetItemToBasketService _basketService;
        public IAddOrGetItemToBasketService basketService
        {
            get
            {
              return  _basketService = _basketService ?? new AddOrGetItemToBasketService(_dataBaseContxt);
            }
        }

        private IGetCountCategoryItemsService _getCountCategoryItemsService;

        public IGetCountCategoryItemsService getCountCategoryItemsService
        {
            get
            {
              return  _getCountCategoryItemsService = _getCountCategoryItemsService ?? new GetCountCategoryItemsService(_dataBaseContxt);
            }
        }

        private IGetBasketByBuyerIdService _getBasketByBuyerIdService;

        public IGetBasketByBuyerIdService getBasketByBuyerIdService
        {
            get
            {
                return _getBasketByBuyerIdService = _getBasketByBuyerIdService ?? new GetBasketByBuyerIdService(_dataBaseContxt , _uriComposerService);
            }
        }

        private ITransferBasketService _transferBasketService;

        public ITransferBasketService transferBasketService
        {
            get
            {
                return _transferBasketService = _transferBasketService ?? new TransferBasketService(_dataBaseContxt);
            }
        }

        private IRemoveBasketItemService _removeBasketItemService;
        public IRemoveBasketItemService removeBasketItemService
        {
            get
            {
                return _removeBasketItemService = _removeBasketItemService ?? new RemoveBasketItemService(_dataBaseContxt);
            }
        }

        private IGetOrCreateBasketForUserService _getOrCreateBasketForUserService;

        public IGetOrCreateBasketForUserService getOrCreateBasketForUserService
        {
            get
            {
                return _getOrCreateBasketForUserService = _getOrCreateBasketForUserService ?? new GetOrCreateBasketForUserService(_dataBaseContxt , _mapper);
            }
        }

        private IAddOrGetItemToBasketService _addOrGetItemToBasketService;

        public IAddOrGetItemToBasketService addOrGetItemToBasketService
        {
            get
            {
                return _addOrGetItemToBasketService = _addOrGetItemToBasketService ?? new AddOrGetItemToBasketService(_dataBaseContxt);
            }
        }
    }
}
