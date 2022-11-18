using Application.Interfaces;
using Application.Interfaces.Payments;
using Application.Payments.Commands;
using Application.Payments.Queries;
using AutoMapper;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payments.FacadePattern
{
   public class PaymentFacade :IPaymentFacade
    {
        private readonly IDatabaseContext _context;
        private readonly UserManager<User> _userMager;
        private readonly IMapper _mapper;

        public PaymentFacade(IDatabaseContext context , IMapper mapper , UserManager<User> userMager)
        {
            _context = context;
            _mapper = mapper;
            _userMager = userMager;
        }

        private ICreatPaymentService _creatPayment;

        public ICreatPaymentService creatPayment
        {
            get
            {
                return _creatPayment = _creatPayment ?? new CreatPaymentService(_context);
            }
        }

        private IGetPaymentService _getPayment;

        public IGetPaymentService getPayment
        {
            get
            {
                return _getPayment = _getPayment ?? new GetPaymentService(_context,_userMager);
            }
        }
    }
}
