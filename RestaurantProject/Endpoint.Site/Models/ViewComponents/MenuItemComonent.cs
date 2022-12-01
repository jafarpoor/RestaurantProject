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
        private readonly ICategoryFacade _categoy;
        public MenuItemComonent(ICategoryFacade categoy)
        {
            _categoy = categoy;
        }

        public IViewComponentResult Invoke()
        {

            List<ListCategoryDataModel> categoryList = null;

            categoryList = _categoy.getListCategoyService.GetListCategory().Data;
            return View(viewName: "MenuItemComonent", model: categoryList);
        }
    }
}
