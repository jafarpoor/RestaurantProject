using Application.Categories.Commands.AddCategories;
using Application.Categories.Commands.AddCategoryItems;
using Application.Categories.Queries;
using Application.Interfaces;
using Application.Interfaces.Categories;
using Application.UriComposer;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;


namespace Application.Categories.FacadePattern
{
    public class CategoryFacade : ICategoryFacade
    {
        private readonly IHostingEnvironment _environment;
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IUriComposerService _uriComposerService;
        public CategoryFacade(IHostingEnvironment environment , IDatabaseContext context , IMapper mapper, IUriComposerService uriComposerService)
        {
            _environment = environment;
            _context = context;
            _mapper = mapper;
            _uriComposerService = uriComposerService;
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

        private IAddCategoryItemService _addCategoryItemService;
        public IAddCategoryItemService addCategoryItemService
        {
            get
            {
                return _addCategoryItemService = _addCategoryItemService ?? new AddCategoryItemService(_context , _mapper);
            }
        }

        private IGetListCategoryItemService _getListCategoryItemService;
        public IGetListCategoryItemService getListCategoryItemService
        {
            get
            {
                return _getListCategoryItemService = _getListCategoryItemService ?? new GetListCategoryItemService(_context , _uriComposerService);
            }
        }

        private IGetCategoryName _getCategoryName;
        public IGetCategoryName getCategoryName
        {
            get
            {
                return _getCategoryName = _getCategoryName ?? new GetCategoryName(_context);
            }
        }
    }
}
