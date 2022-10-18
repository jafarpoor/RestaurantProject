using Application.Interfaces;
using Application.Interfaces.Users;
using Application.Users.Commands.AddUser;
using Application.Users.Commands.EditUser;
using Application.Users.Queries;
using AutoMapper;
using Domain.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.FacadePattern
{
    public class UserFacade : IUsers
    {
        private readonly IHostingEnvironment _environment;
        private readonly UserManager<User> _userManager;
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;

        public UserFacade(IHostingEnvironment environment ,  UserManager<User> userManager , IDatabaseContext context , IMapper mapper)
        {
            _environment = environment;
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
        }


        private IAddUserService _addUserService;
        public IAddUserService addUserService{
            get
            {
                return _addUserService = _addUserService ?? new AddUserService(_environment  , _userManager ,_mapper);
            }
         }


        private  IGetUsersService _getUsers;
        public IGetUsersService getUsers
        {
            get
            {
                return _getUsers = _getUsers ?? new GetUsersService(_context , _mapper,_userManager); 
            }
        }

        private IEditUserService _editUser;

        public IEditUserService editUser
        {
            get
            {
                return _editUser = _editUser ?? new EditUserService(_context,_mapper ,_userManager);
            }
        }
    }
}
