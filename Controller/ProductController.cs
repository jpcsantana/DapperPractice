using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperPrac.Dto;
using DapperPrac.Service;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace DapperPrac.Controller
{
    [Route("product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return Ok(await _service.GetProductsAsync());
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductsById(int id)
        {
            return Ok(await _service.GetProductByIdAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct product)
        {
            return await _service.CreateProductAsync(product) ? Ok("Product successfully created.") : BadRequest("Something went wrong.");
        }
    }
}