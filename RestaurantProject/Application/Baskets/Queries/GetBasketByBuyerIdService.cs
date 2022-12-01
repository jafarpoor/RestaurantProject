using Application.Baskets.DTO;
using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Baskets;
using Application.UriComposer;
using Common.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Application.Baskets.Queries
{
    public class GetBasketByBuyerIdService : IGetBasketByBuyerIdService
    {
        private readonly IDatabaseContext _dataBaseContxt;
        private readonly IUriComposerService _uriComposerService;
        public GetBasketByBuyerIdService(IDatabaseContext dataBaseContxt , IUriComposerService uriComposerService)
        {
            _dataBaseContxt = dataBaseContxt;
            _uriComposerService = uriComposerService;
        }

        public ResultDataModel<BasketDataModel> GetBasketByBuyerId(string BuyerId)
        {
            try
            {
                var Result = _dataBaseContxt.Baskets
                                   .Include(p => p.BasketItems)
                                   .ThenInclude(p => p.CategoryItem)
                                   .ThenInclude(p => p.CategoryItemImage)
                                   .SingleOrDefault(p => p.BuyerId == BuyerId);

                if (Result == null)
                    return new ResultDataModel<BasketDataModel>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = Messages.NullMassages
                    };
                BasketDataModel BasketItemDto = new BasketDataModel()
                {
                    BuyerId = Result.BuyerId,
                    Id = Result.Id,
                    Items = Result.BasketItems.Select(p => new BasketItemDataModel
                    {
                        Id = p.Id,
                        CatalogName = p.CategoryItem.Name,
                        ImageUrl = _uriComposerService.ComposeImageUri(p.ImageUrl),
                        Qty = p.Qty,
                        UnitPrice = p.UnitPrice,
                        TotalPrice = p.UnitPrice * p.Qty,
                        CategoryItemId = p.CategoryItemId

                    }).ToList()
                };
                return new ResultDataModel<BasketDataModel>
                {
                    Data = BasketItemDto,
                    IsSuccess = true,
                    Message = Messages.Successed
                };
            }
            catch (Exception)
            {
                return new ResultDataModel<BasketDataModel>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = Messages.UnexpectedError
                };
            }
        }
    }
}
