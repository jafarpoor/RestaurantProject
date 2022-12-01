using Application.Categories.DTO;
using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Categories;
using AutoMapper;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Categories.Queries
{
    public class GetListCategoyService : IGetListCategoyService
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public GetListCategoyService(IDatabaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDataModel<List<ListCategoryDataModel>> GetListCategory()
        {
            try
            {
                List<ListCategoryDataModel> listCategoryDataModels = new List<ListCategoryDataModel>();
                var Result = _context.Categories.ToList();
                if (Result == null)
                    return new ResultDataModel<List<ListCategoryDataModel>>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = Messages.NullMassages
                    };
                foreach (var item in Result)
                {
                    ListCategoryDataModel model = new ListCategoryDataModel
                    {
                        Id = item.Id,
                        Name = item.TypeName
                    };
                    listCategoryDataModels.Add(model);
                }

                ResultDataModel<List<ListCategoryDataModel>> resultDataModel = new ResultDataModel<List<ListCategoryDataModel>>()
                {
                    Data = listCategoryDataModels,
                    IsSuccess = true,
                    Message = Messages.Successed
                };

                return (resultDataModel);              
            }
            catch (Exception)
            {
                return new ResultDataModel<List<ListCategoryDataModel>>
                {
                    Data  =null ,
                    IsSuccess = false ,
                    Message = Messages.UnexpectedError
                };
            }
        }

        public List<string> GetColumnsName()
        {
            List<string> ListName = new List<string>();
            ListCategoryDataModel model = new ListCategoryDataModel();
            var propertyInfos = model.GetType().GetProperties().ToList();
            foreach (var item in propertyInfos)
            {
                var Name = (GetDisplayAttributesName.Display(item));
                if (!string.IsNullOrEmpty(Name))
                    ListName.Add(Name);
            }
            return ListName;
        }
    }
}
