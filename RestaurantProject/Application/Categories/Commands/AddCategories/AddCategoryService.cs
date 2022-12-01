using Application.Categories.DTO;
using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Categories;
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
        public ResultDataModel<string> Add(AddCategoryDataModel model)
        {
            try
            {
                Category category = new Category()
                {
                    TypeName = model.Name
                };
                _context.Categories.Add(category);
                _context.SaveChanges();
                return new ResultDataModel<string>
                {
                    IsSuccess =true ,
                    Message = Messages.Successed,
                    Data = category.Id.ToString()
                };
            }
            catch (Exception)
            {
                return new ResultDataModel<string>
                {
                    IsSuccess = false,
                    Message = Messages.Error,
                    Data = null
                };
            }
        }
    }
}
