using Application.Categories.DTO;
using Application.Interfaces;
using Application.Interfaces.Categories;
using Application.PagerConfig;
using Common.Helper;
using Domain.Categories;
using System;

namespace Application.Categories.Commands.AddCategories
{
    public class AddCategoryService : IAddCategoryService
    {
        private readonly IDatabaseContext _context;

        public AddCategoryService(IDatabaseContext context)
        {
            _context = context;
        }
        public ResultServices Add(AddCategoryDataModel model)
        {
            try
            {
                Category category = new Category()
                {
                    TypeName = model.Name
                };
                _context.Categories.Add(category);
                _context.SaveChanges();
                return new ResultServices
                {
                    Result =true ,
                    Message = Messages.Successed,
                    Id = category.Id.ToString()
                };
            }
            catch (Exception)
            {
                return new ResultServices
                {
                    Result = false,
                    Message = Messages.Error,
                    Id = null
                };
            }
        }
    }
}
