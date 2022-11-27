using Application.Interfaces;
using Application.Interfaces.Users;
using Application.Users.DTO;
using AutoMapper;
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
        public List<GetUserAddressDataModel> GetUserAddress(string UserId)
        {
            try
            {
                var Result = _context.UserAddresses.Where(p => p.UserId == UserId);
                return _mapper.Map<List<GetUserAddressDataModel>>(Result);
            }
            catch (Exception)
            {

                throw;
            }
        
        }
    }
}
