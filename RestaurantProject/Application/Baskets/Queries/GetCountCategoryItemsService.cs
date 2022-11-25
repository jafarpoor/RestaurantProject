using Application.Interfaces;
using Application.Interfaces.Baskets;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Baskets.Queries
{
  public  class GetCountCategoryItemsService : IGetCountCategoryItemsService
    {
        private readonly IDatabaseContext _dataBaseContxt;

        public GetCountCategoryItemsService(IDatabaseContext dataBaseContxt)
        {
            _dataBaseContxt = dataBaseContxt;
        }
        public int GetCountCategoryItems(string userId, int CategoryItem)
        {
            if (userId != null && CategoryItem != 0)
            {
                int Result = _dataBaseContxt.BasketItems
                           .Include(p => p.Basket)
                           .Where(p => p.Basket.BuyerId == userId && p.CategoryItemId == CategoryItem)
                           .Select(p => p.Qty).FirstOrDefault();

                return Result;
            }
            return 0;

        }
    }
}
