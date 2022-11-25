using Application.Interfaces.Baskets;
using Application.Interfaces.Categories;
using Domain.Users;
using EndPoint.Site.Utilities;
using EndPoint.Site.ViewModels;
using Infrastructure.Api.ImageApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    [Route("~/Category/{action}")]
    public class CategoryController : Controller
    {
        private readonly IImageUploadService _imageUploadService;
        private readonly ICategoryFacade _category;
        private readonly IBasketFacade _basket;
        private readonly SignInManager<User> _signInManager;
        private string UserId = null;

        public CategoryController(IImageUploadService  imageUploadService , ICategoryFacade category , IBasketFacade basket , SignInManager<User> signInManager)
        {
            _imageUploadService = imageUploadService;
            _category = category;
            _basket = basket;
            _signInManager = signInManager;
        }
        public IActionResult Index(int parentId)
        {
            GetUserIdInBasket();
            var Result = _category.getListCategoryItemService.GetList(parentId).Select(p=> new ListCategoryItemViewModel { 
                Price= p.Price ,
                DiscountPercentage = p.DiscountPercentage ,
                Id = p.Id ,
                Name = p.Name,
                Note = p.Note,
                SrcImage = p.SrcImage ,
                CountCategoryInBasket = _basket.getCountCategoryItemsService.GetCountCategoryItems(UserId, p.Id)
            }).ToList();
            return View(Result);
        }

        private void GetUserIdInBasket()
        {
            if (_signInManager.IsSignedIn(User))
                UserId = ClaimUtility.GetUserId(User);
            else if (Request.Cookies.ContainsKey(ClaimUtility.basketCookieName))
                UserId = Request.Cookies[ClaimUtility.basketCookieName];
        }

    }
}
