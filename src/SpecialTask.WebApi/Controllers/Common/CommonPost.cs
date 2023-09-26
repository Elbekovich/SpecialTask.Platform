using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using SpecialTask.Application.Utils;
using SpecialTask.Service.Interfaces.Posts;
using SpecialTask.Service.Interfaces.Users;

namespace SpecialTask.WebApi.Controllers.Common
{
    [Route("api/common")]
    [ApiController]
    [EnableRateLimiting("fixed")]
    public class CommonPost : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly int maxPageSize = 50;
        public CommonPost(IUserService userService, IPostService postService)
        {
            this._userService = userService;
            this._postService = postService;
        }

        [HttpGet("posts")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllUserAsync([FromQuery] int page = 1)
            => Ok(await _postService.GetAllAsync(new PaginationParams(page, maxPageSize)));
    }
}
