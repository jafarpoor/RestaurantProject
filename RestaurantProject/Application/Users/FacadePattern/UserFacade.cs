using Application.Interfaces;
using Application.Interfaces.Users;
using Application.Users.Commands.AddUser;
using Application.Users.Commands.AddUserAddress;
using Application.Users.Commands.EditUser;
using Application.Users.Commands.EditUserAddress;
using Application.Users.Commands.Token;
using Application.Users.Queries;
using AutoMapper;
using Domain.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace Application.Users.FacadePattern
{
    public class UserFacade : IUserFacade
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


        private IGetUserAddressService _getUserAddressService;
        public IGetUserAddressService getUserAddressService
        {
            get
            {
                return _getUserAddressService = _getUserAddressService ?? new GetUserAddressService(_context ,_mapper);
            }
        }

        private IAddUserAddressService _addUserAddressService;

        public IAddUserAddressService addUserAddressService
        {
            get
            {
                return _addUserAddressService = _addUserAddressService ?? new AddUserAddressService(_context , _mapper);
            }
        }

        private IEditUserAddressService _editUserAddressService;
        public IEditUserAddressService editUserAddressService
        {
            get
            {
                return _editUserAddressService = _editUserAddressService ?? new EditUserAddressService(_context , _mapper);
            }
        }

        private ICreatUserTokenService _creatUserTokenService;
        public ICreatUserTokenService creatUserTokenService
        {
            get
            {
                return _creatUserTokenService = _creatUserTokenService ?? new CreatUserTokenService(_context);
            }
        }

    }
}
