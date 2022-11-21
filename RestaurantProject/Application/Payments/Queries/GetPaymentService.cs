using Application.Interfaces;
using Application.Interfaces.Payments;
using Application.Orders.DTO;
using Application.Payments.DTO;
using Common.Helper;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Payments.Queries
{
  public class GetPaymentService : IGetPaymentService
    {
        private readonly IDatabaseContext _context;
        private readonly UserManager<User> _userMager;
        public GetPaymentService(IDatabaseContext context , UserManager<User> userMager)
        {
            _context = context;
            _userMager = userMager;
        }

        public PaymentDataModel GetPaymentById(Guid Id)
        {
            var payment = _context.Payments
                         .Include(p => p.Order)
                         .ThenInclude(p => p.OrderItems)
                         .Include(p => p.Order)
                         .SingleOrDefault(p => p.Id == Id);
            var user = _userMager.Users.SingleOrDefault(p => p.Id == payment.Order.UserId);

            string description = $"پرداخت سفارش شماره {payment.OrderId} " + Environment.NewLine;
            description += "محصولات" + Environment.NewLine;

            foreach (var item in payment.Order.OrderItems.Select(p => p.ProductName))
            {
                description += $"-{item}";
            }

            return new PaymentDataModel
            {
                Amount = payment.Order.TotalPrice(),
                Description = description,
                Email = user.Email,
                Id = payment.Id,
                PhoneNumber = user.PhoneNumber,
                UserId = user.Id ,
                OrderId = payment.Order.Id
            };
        }


    }
}
