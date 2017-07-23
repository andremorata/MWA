using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Repositories;
using ModernStore.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.Api.Controllers
{
    public class CustomerController: BaseController
    {
        private readonly CustomerCommandHandler _handler;

        public CustomerController(IUoW uow, CustomerCommandHandler handler): base(uow)
        {
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/customers")]
        public IActionResult Get(Guid id)
        {
            return Ok("");
        }

        [HttpPost]
        [Route("v1/customers")]
        public async Task<IActionResult> Post([FromBody] RegisterCustomerCommand command)
        {
            var result = _handler.Handle(command);
            return await ApiResponse(result, _handler.Notifications);
        }
    }
}
