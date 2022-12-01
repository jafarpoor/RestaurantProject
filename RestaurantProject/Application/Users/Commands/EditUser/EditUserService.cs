using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Users;
using Application.Users.DTO;
using AutoMapper;
using Common.Helper;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using System;

namespace Application.Users.Commands.EditUser
{
    public class EditUserService : IEditUserService
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public EditUserService(IDatabaseContext context , IMapper mapper, UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;

        }
        public ResultDataModel Edit(EditUserDataModel editUserDataModel)
        {
            try
            {
                var User = _context.Users.Find(editUserDataModel.Id);
                User.FristName = editUserDataModel.FristName ;
                User.LastName = editUserDataModel.LastName;
                User.PhoneNumber = editUserDataModel.PhoneNumber;
                User.Email = editUserDataModel.Email;
                User.Address = editUserDataModel.Address;
                User.UserName = editUserDataModel.UserName;
                _context.SaveChanges();
                return new ResultDataModel
                {
                    Message = Messages.Successed,
                    IsSuccess = true
                };
            }
            catch (Exception)
            {
                return new ResultDataModel
                {
                    Message = Messages.Error,
                    IsSuccess = false
                };
            }
          

        }
    }
}
