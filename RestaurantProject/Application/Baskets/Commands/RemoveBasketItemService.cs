using Application.Interfaces;
using Application.Interfaces.Baskets;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Baskets.Commands
{
  public  class RemoveBasketItemService : IRemoveBasketItemService
    {
        private readonly IDatabaseContext _dataBaseContxt;
        public RemoveBasketItemService(IDatabaseContext dataBaseContxt)
        {
            _dataBaseContxt = dataBaseContxt;
        }

        public bool RemoveBasketItem(int ItemId)
        {
            try
            {
                var Result = _dataBaseContxt.BasketItems.SingleOrDefault(p => p.Id == ItemId);
                if (Result == null)
                    throw new Exception(Messages.NotFund);
                _dataBaseContxt.BasketItems.Remove(Result);
                _dataBaseContxt.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
