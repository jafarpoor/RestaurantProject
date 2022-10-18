using Application.Categories.Commands.AddCategories;
using Application.Categories.Queries;
using Application.Interfaces;
using Application.Interfaces.Categories;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.FacadePattern
{
    public class CategoryFacade : ICategory
    {
        private readonly IHostingEnvironment _environment;
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public CategoryFacade(IHostingEnvironment environment , IDatabaseContext context , IMapper mapper)
        {
            _environment = environment;
            _context = context;
            _mapper = mapper;
        }

        private  IAddCategoryService _addCategory;
        public IAddCategoryService addCategory
        {
            get
            {
              return  _addCategory = _addCategory ?? new AddCategoryService(_context);
            }
        }

        private IGetListCategoyService _getListCategoyService;
        public IGetListCategoyService getListCategoyService
        {
            get
            {
                return _getListCategoyService = _getListCategoyService ?? new GetListCategoyService(_context, _mapper);
            }
        }
    }
}
