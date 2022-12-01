using Application.Categories.DTO;
using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Categories;
using AutoMapper;
using Common.Helper;
using Domain.Categories;
using System;

namespace Application.Categories.Commands.AddCategoryItems
{
   public class AddCategoryItemService : IAddCategoryItemService
    {
        private readonly IDatabaseContext _dataBaseContxt;
        private readonly IMapper _mapper;

        public AddCategoryItemService(IDatabaseContext dataBaseContxt , IMapper mapper)
        {
            _dataBaseContxt = dataBaseContxt;
            _mapper = mapper;
        }

        public ResultDataModel AddCaregoryItem(AddCategoryItemDataModel model)
        {
            try
            {
                var Result = _mapper.Map<CategoryItem>(model);
                _dataBaseContxt.CategoryItems.Add(Result);
                _dataBaseContxt.SaveChanges();
                return new ResultDataModel
                {
                    Message = Messages.Successed,
                    IsSuccess = true
                };
            }
            catch (Exception)
            {
                return new ResultDataModel
                {
                    Message = Messages.Error,
                    IsSuccess = false
                };
            }
          
        }
    }
}
