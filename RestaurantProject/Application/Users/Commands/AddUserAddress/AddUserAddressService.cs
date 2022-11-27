using Application.Interfaces;
using Application.Interfaces.Users;
using Application.Users.DTO;
using AutoMapper;
using Domain.Users;
using System;


namespace Application.Users.Commands.AddUserAddress
{
    public class AddUserAddressService : IAddUserAddressService
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public AddUserAddressService(IDatabaseContext context , IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void CreatUserAddress(AddUserAddressDataModel addUserAddres)
        {
            try
            {
                var Result = _mapper.Map<UserAddress>(addUserAddres);
                _context.UserAddresses.Add(Result);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
