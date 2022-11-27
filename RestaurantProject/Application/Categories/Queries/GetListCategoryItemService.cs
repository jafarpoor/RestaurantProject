using Application.Categories.DTO;
using Application.Interfaces;
using Application.Interfaces.Categories;
using Application.UriComposer;
using Common.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Categories.Queries
{
    public class GetListCategoryItemService : IGetListCategoryItemService
    {
        private readonly IDatabaseContext _Contetx;
        private readonly IUriComposerService _uriComposerService;
        public GetListCategoryItemService(IDatabaseContext Contetx , IUriComposerService uriComposerService)
        {
            _Contetx = Contetx;
            _uriComposerService = uriComposerService;
        }
        public List<ListCategoryItemDataModel> GetList(int ParentId)
        {
            var Result = _Contetx.CategoryItems
                           .Include(p=>p.CategoryItemImage)
                           .Where(p => p.CategoryId == ParentId).ToList();

           if(Result ==null)
                throw new Exception(Messages.NotFund);

            List<ListCategoryItemDataModel> modelList = new List<ListCategoryItemDataModel>();
            foreach (var item in Result)
            {
                ListCategoryItemDataModel listCategoryItemDataModel = new ListCategoryItemDataModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Note = item.Note,
                    Price = item.Price,
                    DiscountPercentage = item.DiscountPercentage,
                    SrcImage = _uriComposerService.ComposeImageUri(item.CategoryItemImage.Src)
                };
                modelList.Add(listCategoryItemDataModel);
            }
            return modelList;
        }

        public List<string> GetColumnsName()
        {
            List<string> ListName = new List<string>();
            ListCategoryItemDataModel model = new ListCategoryItemDataModel();
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
