using Application.Categories.DTO;
using Application.Interfaces;
using AutoMapper;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<ListCategoryDataModel> GetListCategory()
        {
            try
            {
                List<ListCategoryDataModel> listCategoryDataModels = new List<ListCategoryDataModel>();
                var Result = _context.Categories.ToList();
                foreach (var item in Result)
                {
                    ListCategoryDataModel model = new ListCategoryDataModel
                    {
                        Id = item.Id,
                        Name = item.TypeName
                    };
                    listCategoryDataModels.Add(model);
                }
                return (listCategoryDataModels);
                
                //if ()
                //{

                //}

                //else
                //{
                        // داده ای وجود ندارد
                //}
            }
            catch (Exception)
            {

                throw;
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
