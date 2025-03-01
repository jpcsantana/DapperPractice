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
        public async Task<IActionResult> CreateProduct([FromBody] InputProduct product)
        {
            return await _service.CreateProductAsync(product) ? CreatedAtAction(nameof(CreateProduct), "Product successfully created.") : BadRequest("Something went wrong.");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] InputProduct product)
        {
            return await _service.UpdateProductAsync(id, product) ? Ok("Product successfully updated.") : BadRequest("Something went wrong.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return await _service.DeleteProductAsync(id) ? NoContent() : BadRequest("Something went wrong.");
        }
    }
}