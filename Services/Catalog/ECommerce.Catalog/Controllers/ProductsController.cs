using ECommerce.Catalog.DTOs.ProductDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Repositories.ProductRepositories;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductRepository _repository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _repository.GetAllAsync();
            var mapped = products.Adapt<List<ResultProductDto>>();
            return Ok(mapped);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product is null)
            {
                return BadRequest("product bulunamadı");
            }
            var mapped = product.Adapt<ResultProductDto>();
            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var product = dto.Adapt<Product>();
            await _repository.CreateAsync(product);
            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductDto dto)
        {
            var product = await _repository.GetByIdAsync(dto.Id);
            if (product is null)
            {
                return BadRequest("product bulunamadı");
            }
            dto.Adapt(product);
            await _repository.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product is null)
            {
                return BadRequest("product bulunamadı");
            }
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
