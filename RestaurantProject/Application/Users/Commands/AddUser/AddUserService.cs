using Application.DTO;
using Application.Users.DTO;
using AutoMapper;
using Common.Helper;
using Domain.Users;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;


namespace Application.Users.Commands.AddUser
{
   public class AddUserService : IAddUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHostingEnvironment _environment;
        private readonly IMapper _mapper;
        public AddUserService(IHostingEnvironment environment,  UserManager<User> userManager , IMapper mapper)
        {
            _environment = environment;
            _userManager = userManager;
            _mapper = mapper;
        }

        public ResultDataModel Creat(RegisterDataModel model)
        {
            var user = _mapper.Map<User>(model);
            var Result = _userManager.CreateAsync(user, model.PasswordHash).Result;
            if (Result.Succeeded)
                return new ResultDataModel
                {
                    Message =Messages.Successed ,
                    IsSuccess = true
                };
            else
                return new ResultDataModel
                {
                    Message = Messages.NotFund,
                    IsSuccess = false
                };
        }
    }
}
