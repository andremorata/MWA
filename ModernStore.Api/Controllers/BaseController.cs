using FluentValidator;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Infra.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernStore.Api.Controllers
{
    public class BaseController: Controller
    {
        private readonly IUoW _uow;

        public BaseController(IUoW uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Response(
            object result,  
            IEnumerable<Notification> notifications)
        {
            if (!notifications.Any())
            {
                try
                {
                    _uow.Commit();
                    return Ok(new
                    {
                        success = true,
                        data = result
                    });
                }
                catch (Exception e)
                {
                    //Log do erro (Elmah)
                    return BadRequest(new
                    {
                        success = false,
                        errors = new[] { "Ocorreu uma falha interna no servidor." },
                        exception = e.Message
                    });
                }
            }
            else
            {
                return BadRequest(new
                {
                    success = false,
                    errors = notifications
                });
            }
        }
    }
}
