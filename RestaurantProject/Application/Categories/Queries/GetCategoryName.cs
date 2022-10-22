using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
