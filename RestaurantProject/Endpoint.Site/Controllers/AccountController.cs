using Application.Interfaces;
using Application.Interfaces.Baskets;
using Application.Users.Commands.AddUser;
using Application.Users.DTO;
using Domain.Users;
using EndPoint.Site.Utilities;
using EndPoint.Site.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUsers _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManagerIdentity;
        private readonly IBasket _basket;
        public AccountController(IUsers userManager , SignInManager<User> signInManager,
            UserManager<User> userManagerIdentity ,
            IBasket basket)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userManagerIdentity = userManagerIdentity;
            _basket = basket;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
                return View(registerViewModel);

            RegisterDataModel register = new RegisterDataModel() { 
                FristName = registerViewModel.FristName ,
                LastName = registerViewModel.LastName ,
                Email = registerViewModel.Email ,
                PasswordHash = registerViewModel.Password ,
                PhoneNumber = registerViewModel.PhoneNumber ,
               UserName = registerViewModel.Email 
            };
            _userManager.addUserService.Creat(register);
            var user = _userManagerIdentity.FindByNameAsync(register.Email).Result;
            TransferBasketForuser(user.Id);
            return View();
        }

        public IActionResult Login(string returnUrl = "/")
        {
            return View(new LoginViewModel
            {
                ReturnUrl = returnUrl,
            });
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _userManagerIdentity.FindByNameAsync(model.Email).Result;
            if (user == null)
            {
                ModelState.AddModelError("", "کاربر یافت نشد");

                return View(model);
            }
            _signInManager.SignOutAsync();
            var Result = _signInManager.PasswordSignInAsync(user, model.Password
                , model.IsPersistent, false).Result;
            if (Result.Succeeded)
            {
                TransferBasketForuser(user.Id);
                return Redirect(model.ReturnUrl);
            }
            return View();
        }


        private void TransferBasketForuser(string userId)
        {
            if (Request.Cookies.ContainsKey(ClaimUtility.basketCookieName))
            {
                var anonymousId = Request.Cookies[ClaimUtility.basketCookieName];
                _basket.basketService.TransferBasket(anonymousId, userId);
                Response.Cookies.Delete(ClaimUtility.basketCookieName);
            }
        }
    }
}
