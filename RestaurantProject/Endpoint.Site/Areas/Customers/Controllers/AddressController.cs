using Application.Interfaces;
using Application.Users.DTO;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Customers.Controllers
{
    [Authorize]
    [Area("Customers")]
    public class AddressController : Controller
    {
        private readonly IUserFacade _userService;

        public AddressController(IUserFacade userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            var Result = _userService.getUserAddressService.GetUserAddress(ClaimUtility.GetUserId(User));
            return View(Result);
        }


        [HttpGet]
        public IActionResult AddNewAddress()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddNewAddress(AddUserAddressDataModel addUserAddressDataModel)
        {
            var userId = ClaimUtility.GetUserId(User);
            addUserAddressDataModel.UserId = userId;
            _userService.addUserAddressService.CreatUserAddress(addUserAddressDataModel);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult EditUserAddress(int Id)
        {
            var Result = _userService.editUserAddressService.FindUserAddress(Id);
            return View(Result);
        }

        [HttpPost]

        public IActionResult EditUserAddress(EditUserAddressDataModel editUser)
        {
            _userService.editUserAddressService.EditAddress(editUser);
            return RedirectToAction(nameof(Index));
        }
    }
}
