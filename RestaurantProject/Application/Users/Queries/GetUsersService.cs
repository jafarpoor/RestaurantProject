using Application.Interfaces;
using Application.Interfaces.Users;
using Application.Users.DTO;
using AutoMapper;
using Common.Helper;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;


namespace Application.Users.Queries
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public GetUsersService(IDatabaseContext context , IMapper mapper , UserManager<User> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        public List<ListUsersDataModel> GetList()
        {
            var Result = _mapper.Map<List<ListUsersDataModel>>(_context.Users.ToList());
            return Result;
        }

        public List<string> GetColumnsName()
        {
            List<string> ListName = new List<string>();
            ListUsersDataModel model = new ListUsersDataModel();
            var propertyInfos = model.GetType().GetProperties().ToList();
            foreach (var item in propertyInfos)
            {
                var Name = (GetDisplayAttributesName.Display(item));
                if (!string.IsNullOrEmpty(Name))
                    ListName.Add(Name);
            }
            return ListName;
        }

        public EditUserDataModel Find(string Id)
        {
            var user = _userManager.FindByIdAsync(Id).Result;
            var Result = _mapper.Map<EditUserDataModel>(user);
            return Result;
        }
    }
}
