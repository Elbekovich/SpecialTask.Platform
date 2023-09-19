using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using SpecialTask.Application.Utils;
using SpecialTask.Domain.Entities.Posts;
using SpecialTask.Persistance.Dtos.Categories;
using SpecialTask.Persistance.Validatons.Dtos.Categories;
using SpecialTask.Service.Interfaces.Categories;
using System.Reflection.Metadata.Ecma335;

namespace SpecialTask.WebApi.Controllers.AdminCategory
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class AdminCategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly int maxPageSize = 30;
        public AdminCategoryController(ICategoryService categoryService)
        {
            this._service = categoryService;
        }
        [HttpPost]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> CreateAsync([FromForm] CategoryCreateDto dto)
        {
            var validator = new CategoryCreateValidator();
            var result = validator.Validate(dto);
            if(result.IsValid) return Ok(await  _service.CreateAsync(dto));
            else return BadRequest(result);
        }

        [HttpPut]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> UpdateAsync(long categoryId, [FromForm] CategoryUpdateDto dto)
        {
            var updateValidator = new CategoryUpdateValidator();
            var result = updateValidator.Validate(dto);
            if (result.IsValid) return Ok(await _service.UpdateAsync(categoryId,dto));
            else return BadRequest(result.Errors);
        }

        [HttpDelete("{categoryId}")]
        //[Authorize(Roles ="Admin")]
        public async Task<IActionResult> DeleteAsync(long categoryId)
            => Ok(await _service.DeleteAsync(categoryId));


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));

/*
        [HttpGet("{categoryId")]
        [AllowAnonymous]

        public async Task<IActionResult> GetByIdAsync(long categoryId)
            => Ok(await _service.GetByIdAsync(categoryId));
*/


        [HttpGet("sort/byCategory")]
        [AllowAnonymous]
        public async Task<ActionResult<IList<Post>>> GetPostsByCategory(long category)
            => Ok(await _service.GetPostsByCategory(category));






    }
}
