﻿using Application.Categories.Commands;
using Application.Interfaces;
using Application.Interfaces.Order;
using Application.Orders.Commands;
using Application.Orders.Queries;
using Application.UriComposer;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Orders.FacadePattern
{
  public  class OrderFacade : IOrderFacade
    {
        private readonly IHostingEnvironment _environment;
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IUriComposerService _uriComposerService;

        public OrderFacade(IHostingEnvironment environment , IDatabaseContext context , IMapper mapper , IUriComposerService uriComposerService)
        {
            _environment = environment;
            _context = context;
            _mapper = mapper;
            _uriComposerService = uriComposerService;
        }

        private ICreatOrderService _creatOrderService;
        public ICreatOrderService creatOrderService
        {
            get
            {
               return _creatOrderService = _creatOrderService ?? new CreatOrderService(_context , _uriComposerService ,_mapper);
                     
            }
        }

        private IGetOrdersCustomerService _getOrdersCustomer;
        public IGetOrdersCustomerService getOrdersCustomer
        {
            get
            {
                return _getOrdersCustomer = _getOrdersCustomer ?? new GetOrdersCustomerService(_context);
            }
        }

        private IGetOrderCodeService _getOrderCodeService;
        public IGetOrderCodeService getOrderCoedService
        {
            get
            {
                return _getOrderCodeService = _getOrderCodeService ?? new GetOrderCodeService(_context);
            }
        }

        private IGetListOrdersForSendService _getListOrdersForSendService;
        public IGetListOrdersForSendService getListOrdersForSendService
        {
            get
            {
                return _getListOrdersForSendService = _getListOrdersForSendService ?? new GetListOrdersForSendService(_context);
            }
        }
    }

}
