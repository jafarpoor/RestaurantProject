using Application.Interfaces;
using Application.PagerConfig;
using Application.Users.DTO;
using AutoMapper;
using Domain.Users;
using Infrastructure.PagerConfig;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ResultServices Creat(RegisterDataModel model)
        {
            var user = _mapper.Map<User>(model);
            var Result = _userManager.CreateAsync(user, model.PasswordHash).Result;
            if (Result.Succeeded)
                return new ResultServices
                {
                    Result = true
                };
            else
                return new ResultServices
                {
                    Result = false
                };
        }
    }
}
