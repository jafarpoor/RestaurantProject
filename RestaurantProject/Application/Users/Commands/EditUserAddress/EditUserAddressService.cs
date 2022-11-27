using Application.Interfaces;
using Application.Interfaces.Users;
using Application.Users.DTO;
using AutoMapper;
using Common.Helper;
using Domain.Users;
using System;
using System.Linq;

namespace Application.Users.Commands.EditUserAddress
{
   public class EditUserAddressService : IEditUserAddressService
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;

        public EditUserAddressService(IDatabaseContext contex , IMapper mapper)
        {
            _context = contex;
            _mapper = mapper;
        }

        public EditUserAddressDataModel FindUserAddress(int Id)
        {
            var Result = _context.UserAddresses.SingleOrDefault(p => p.Id == Id);
            if (Result == null)
                throw new Exception(Messages.NotFund);

            return _mapper.Map<EditUserAddressDataModel>(Result);
        }
        public void EditAddress(EditUserAddressDataModel editUser)
        {
            try
            {
                var Result = _context.UserAddresses.SingleOrDefault(p => p.Id == editUser.Id);
                if (Result == null)
                    throw new Exception(Messages.Error);

                Result.PostalAddress = editUser.PostalAddress;
                Result.ReciverName = editUser.ReciverName;
                Result.State = editUser.State;
                Result.ZipCode = editUser.ZipCode;

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        
        }
    }
}
