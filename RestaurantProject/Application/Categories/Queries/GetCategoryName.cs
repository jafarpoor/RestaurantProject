using Application.Interfaces;
using Application.Interfaces.Categories;
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
        public string GetName(int ParentId)
        {
            try
            {
                var Result = _context.Categories.SingleOrDefault(p => p.Id == ParentId).TypeName;
                return Result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
