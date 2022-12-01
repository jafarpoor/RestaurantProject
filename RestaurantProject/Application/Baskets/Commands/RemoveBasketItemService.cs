using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Baskets;
using Common.Helper;
using System;
using System.Linq;


namespace Application.Baskets.Commands
{
    public class RemoveBasketItemService : IRemoveBasketItemService
    {
        private readonly IDatabaseContext _dataBaseContxt;
        public RemoveBasketItemService(IDatabaseContext dataBaseContxt)
        {
            _dataBaseContxt = dataBaseContxt;
        }

        public ResultDataModel RemoveBasketItem(int ItemId)
        {
            try
            {
                var Result = _dataBaseContxt.BasketItems.SingleOrDefault(p => p.Id == ItemId);
                if (Result == null)
                    return new ResultDataModel
                    {
                        IsSuccess = false,
                        Message = Messages.NotFund
                    };
                _dataBaseContxt.BasketItems.Remove(Result);
                _dataBaseContxt.SaveChanges();
                return new ResultDataModel
                {
                    IsSuccess = true,
                    Message = Messages.Successed
                };
            }
            catch (Exception)
            {
                return new ResultDataModel
                {
                    IsSuccess = false,
                    Message = Messages.UnexpectedError
                };
            }

        }
    }
}
