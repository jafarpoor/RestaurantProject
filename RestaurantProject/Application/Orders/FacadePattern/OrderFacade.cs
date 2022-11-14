﻿using Application.Categories.Commands;
using Application.Interfaces;
using Application.Interfaces.Order;
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
  public  class OrderFacade :IOrders
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
    }

}
