using Application.DTO;
using Application.Interfaces;
using Application.Interfaces.Users;
using Application.Users.DTO;
using AutoMapper;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Application.Users.Queries
{
    public class GetUserAddressService : IGetUserAddressService
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public GetUserAddressService(IDatabaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public ResultDataModel<List<GetUserAddressDataModel>> GetUserAddress(string UserId)
        {
            try
            {
                var Result = _context.UserAddresses.Where(p => p.UserId == UserId);
                return new ResultDataModel<List<GetUserAddressDataModel>>
                {
                    Data = _mapper.Map<List<GetUserAddressDataModel>>(Result),
                    IsSuccess = true,
                    Message = Messages.Successed
                };
            }
            catch (Exception)
            {
                return new ResultDataModel<List<GetUserAddressDataModel>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = Messages.UnexpectedError
                };
            }
        
        }
    }
}
