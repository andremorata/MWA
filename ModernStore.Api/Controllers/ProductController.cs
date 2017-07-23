using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Repositories;
using System;

namespace ModernStore.Api.Controllers
{
    public class ProductController: Controller
    {
        private readonly IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("v1/products")]
        [Authorize(Policy = "Administradores")]
        public IActionResult Get()
        {
            //return Ok(_repository.Get());
            var isUser = User.HasClaim("ModernStore", "User");
            var isAdmin = User.HasClaim("ModernStore", "Admins");
            
            var ret = new {
                teste = "OK",
                user = User.Identity.Name,
                authType = User.Identity.AuthenticationType,
                isUser = isUser,
                isAdmin = isAdmin
            };

            return Ok(ret);
        }

        [HttpGet]
        [Route("v1/products/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok($"Produto {id}");
        }

        [HttpPost]
        [Route("v1/products")]
        public IActionResult Post()
        {
            return Created("", $"Criando um novo produto");
        }
    }
}
