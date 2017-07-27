using ModernStore.Domain.Commands.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModernStore.Infra.Transactions;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands.Inputs;
using Microsoft.AspNetCore.Authorization;

namespace ModernStore.Api.Controllers
{
    public class OrderController:BaseController
    {
        private readonly OrderCommandHandler _handler;

        public OrderController(IUoW uow, OrderCommandHandler handler) : base(uow)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/orders")]
        [Authorize(Policy = "User")]
        public async Task<IActionResult> Post([FromBody] RegisterOrderCommand command)
        {
            command.Customer = User.Identity.Name;
            var result = _handler.Handle(command);
            return await ApiResponse(result, _handler.Notifications);
        }
    }
}
