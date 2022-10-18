using Application.Categories.DTO;
using Application.Interfaces.Categories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Admin.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategory _category;
        public CategoryController(ICategory category)
        {
            _category = category;
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
            return Json(_category.addCategory.Add(model));
        }

        [HttpGet]
        public IActionResult GetList()
        {
            return View(_category.getListCategoyService.GetListCategory());
        }

        [HttpGet]
        public IActionResult GetGategoryItems()
        {
            return View();
        }
    }
}
