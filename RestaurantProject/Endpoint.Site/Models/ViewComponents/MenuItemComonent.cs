using Application.Categories.DTO;
using Application.Interfaces.Categories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Models.ViewComponents
{
    public class MenuItemComonent : ViewComponent
    {
        private readonly ICategory _categoy;
        public MenuItemComonent(ICategory categoy)
        {
            _categoy = categoy;
        }

        public IViewComponentResult Invoke()
        {

            List<ListCategoryDataModel> categoryList = null;

            categoryList = _categoy.getListCategoyService.GetListCategory();
            return View(viewName: "MenuItemComonent", model: categoryList);
        }
    }
}
