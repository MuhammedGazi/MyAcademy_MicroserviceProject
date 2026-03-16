using ECommerce.Catalog.DTOs.CategoryDtos;
using ECommerce.Catalog.Entities;
using ECommerce.Catalog.Repositories.CategoryRepositories;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CategoriesController(ICategoryRepository _repository) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _repository.GetAllAsync();
            return Ok(categories.Adapt<List<ResultCategoryDto>>());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            var category = dto.Adapt<Category>();
            await _repository.CreateAsync(category);
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null)
                return BadRequest("category bulunamadı");
            return Ok(category.Adapt<ResultCategoryDto>());
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCategoryDto dto)
        {
            var category = await _repository.GetByIdAsync(dto.Id);
            if (category is null)
                return BadRequest("category bulunamadı");
            dto.Adapt(category);
            await _repository.UpdateAsync(category);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var category = await _repository.GetByIdAsync(id);
            if (category is null)
                return BadRequest("category bulunamadı");

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
