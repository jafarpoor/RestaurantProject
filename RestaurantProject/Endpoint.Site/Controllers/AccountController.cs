using Application.Interfaces;
using Application.Users.Commands.AddUser;
using Application.Users.DTO;
using Domain.Users;
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

        public AccountController(IUsers userManager , SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
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
            return View();
        }
    }
}
