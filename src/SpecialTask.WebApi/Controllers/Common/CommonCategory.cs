using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using SpecialTask.Application.Utils;
using SpecialTask.Service.Interfaces.Categories;
using SpecialTask.Service.Interfaces.Posts;
using SpecialTask.Service.Interfaces.Users;

namespace SpecialTask.WebApi.Controllers.Common
{
    [Route("api/common")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class CommonCategory : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly int maxPageSize = 50;
        private readonly ICategoryService _service;
        public CommonCategory(IUserService userService, IPostService postService, ICategoryService service)
        {
            this._userService = userService;
            this._postService = postService;
            this._service = service;
        }

        [HttpGet("categories")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _service.GetAllAsync(new PaginationParams(page, maxPageSize)));




    }
}
