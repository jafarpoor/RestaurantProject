using Application.Interfaces.Categories;
using Infrastructure.Api.ImageApi;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IImageUploadService _imageUploadService;
        private readonly ICategory _category;

        public CatalogController(IImageUploadService  imageUploadService , ICategory category)
        {
            _imageUploadService = imageUploadService;
            _category = category;
        }
        public IActionResult Index(int parentId)
        {
            return View(_category.getListCategoryItemService.GetList(parentId));
        }

    }
}
