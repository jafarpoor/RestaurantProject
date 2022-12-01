using Application.DTO;
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
        public ResultDataModel<List<ListUsersDataModel>> GetList()
        {
            try
            {
                return new ResultDataModel<List<ListUsersDataModel>>
                {
                    Data = _mapper.Map<List<ListUsersDataModel>>(_context.Users.ToList()),
                    IsSuccess = true,
                    Message = Messages.Successed
                };
            }
            catch (System.Exception)
            {
                return new ResultDataModel<List<ListUsersDataModel>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = Messages.UnexpectedError
                };
            }
         
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

        public ResultDataModel<EditUserDataModel> Find(string Id)
        {
            try
            {
                var user = _userManager.FindByIdAsync(Id).Result;
                return new ResultDataModel<EditUserDataModel>
                {
                    Data = _mapper.Map<EditUserDataModel>(user),
                    IsSuccess = true,
                    Message = Messages.Successed
                };
            }
            catch (System.Exception)
            {
                return new ResultDataModel<EditUserDataModel>
                {
                    Data =null,
                    IsSuccess = false,
                    Message = Messages.UnexpectedError
                };
            }
        }
    }
}
