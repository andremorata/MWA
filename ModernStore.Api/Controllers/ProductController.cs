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
        public IActionResult Get()
        {
            return Ok(_repository.Get());
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
