using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Categories;
using Common.Helper;
using System;
using System.Linq;


namespace Application.Categories.Queries
{
    public class GetCategoryName : IGetCategoryName
    {
        private readonly IDatabaseContext _context;
        public GetCategoryName(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultDataModel<string> GetName(int ParentId)
        {
            try
            {
                var Result = _context.Categories.SingleOrDefault(p => p.Id == ParentId).TypeName;
                if(Result == null)
                    return new ResultDataModel<string>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = Messages.NullMassages
                    }; 
                else
                return new ResultDataModel<string>
                {
                    Data = Result ,
                    IsSuccess =true ,
                    Message = Messages.Successed
                };
            }
            catch (Exception)
            {

                return new ResultDataModel<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = Messages.UnexpectedError
                };
            }
        }
    }
}
