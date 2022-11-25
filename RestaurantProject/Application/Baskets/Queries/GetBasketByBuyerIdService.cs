using Application.Baskets.DTO;
using Application.Interfaces;
using Application.Interfaces.Baskets;
using Application.UriComposer;
using Common.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public BasketDataModel GetBasketByBuyerId(string BuyerId)
        {
            try
            {
                var Result = _dataBaseContxt.Baskets
                                   .Include(p => p.BasketItems)
                                   .ThenInclude(p => p.CategoryItem)
                                   .ThenInclude(p => p.CategoryItemImage)
                                   .SingleOrDefault(p => p.BuyerId == BuyerId);

                if (Result == null)
                    throw new Exception(Messages.NotFund);
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
                return BasketItemDto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
