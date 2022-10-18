using Application.Interfaces;
using Application.Interfaces.Users;
using Application.PagerConfig;
using Application.Users.DTO;
using AutoMapper;
using Common.Helper;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ResultServices Edit(EditUserDataModel editUserDataModel)
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
                return new ResultServices
                {
                    Id = editUserDataModel.Id,
                    Message = Messages.Successed,
                    Result = true
                };
            }
            catch (Exception)
            {
                return new ResultServices
                {
                    Id = null,
                    Message = Messages.Error,
                    Result = false
                };
            }
          

        }
    }
}
