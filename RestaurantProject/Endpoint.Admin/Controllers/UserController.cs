using Application.Interfaces;
using Application.Users.DTO;
using Common.Helper;
using EndPoint.Admin.Models;
using Infrastructure.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EndPoint.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserFacade _userManager;

        public UserController(IUserFacade userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()      
        {
            ListUsersViewModels listUsersViewModels = new ListUsersViewModels();
            
            listUsersViewModels.listUsersDataModels = _userManager.getUsers.GetList();
            listUsersViewModels.columnsName = _userManager.getUsers.GetColumnsName();

            return View(listUsersViewModels);
        }

        [HttpGet]
        public IActionResult Profile(string Id)
        {

            return View(_userManager.getUsers.Find(Id));
        }

        [HttpPost]
        public IActionResult Profile(EditUserDataModel editUser)
        {
           var Result= _userManager.editUser.Edit(editUser);
            return Json(Result);
        }
    }
}
