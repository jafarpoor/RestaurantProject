using Application.Categories.DTO;
using Application.Interfaces;
using Application.Interfaces.Categories;
using Application.PagerConfig;
using AutoMapper;
using Common.Helper;
using Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ResultServices AddCaregoryItem(AddCategoryItemDataModel model)
        {
            try
            {
                var Result = _mapper.Map<CategoryItem>(model);
                _dataBaseContxt.CategoryItems.Add(Result);
                _dataBaseContxt.SaveChanges();
                return new ResultServices {
                    Id = Result.Id.ToString(),
                    Message = Messages.Successed,
                    Result = true
                };
            }
            catch (Exception)
            {
                return new ResultServices
                {
                    Id = null,
                    Message = Messages.Error,
                    Result = false
                };
            }
          
        }
    }
}
