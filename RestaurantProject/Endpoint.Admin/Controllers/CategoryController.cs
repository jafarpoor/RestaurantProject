using Application.Categories.DTO;
using Application.Interfaces.Categories;
using EndPoint.Admin.Models;
using Infrastructure.Api.ImageApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IImageUploadService _imageUploadService;
        private readonly ICategoryFacade _category;
        public CategoryController(ICategoryFacade category , IImageUploadService imageUploadService)
        {
            _category = category;
            _imageUploadService = imageUploadService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(AddCategoryDataModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            return Json(_category.addCategory.Add(model));
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return View(_category.getListCategoyService.GetListCategory());
        }


        [HttpGet]
        public IActionResult GetGategoryItems(int parentId)
        {
            ListCategoryViewModel listView = new ListCategoryViewModel();
            listView.listCategoryItemDataModels = _category.getListCategoryItemService.GetList(parentId);
            listView.columnsName = _category.getListCategoryItemService.GetColumnsName();
            ViewBag.CategoryName = _category.getCategoryName.GetName(parentId);
            return View(listView);
        }

        [HttpGet]
        public IActionResult AddCategoryItem()
        {
            var selectList = new List<SelectListItem>();
            List<ListCategoryDataModel> categoryList =_category.getListCategoyService.GetListCategory();
            foreach (var item in categoryList)
            {
                var itemList = new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name
                };
                selectList.Add(itemList);
            }
            AddCategoryItemViewModel model = new AddCategoryItemViewModel();
            model.Caregories = selectList;
            return View(model);
        }

        [HttpPost]
        public IActionResult AddCategoryItem(AddCategoryItemViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            List<AddNewCategoryItemImageDataModel> images = new List<AddNewCategoryItemImageDataModel>();
            if (model.Files != null)
            {
                //Upload 
                var result = _imageUploadService.Upload(model.Files);
                var MyAddNewCategoryItemImageDataModel = new AddNewCategoryItemImageDataModel { Src = result };
                model.addCategoryItemDataModel.addNewCatalogItemImageDataModel = MyAddNewCategoryItemImageDataModel;
            }
            return Json(_category.addCategoryItemService.AddCaregoryItem(model.addCategoryItemDataModel));
        }
    }
}
