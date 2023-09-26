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
    public class CommonUser : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly int maxPageSize = 50;
        public CommonUser(IUserService userService, IPostService postService)
        {
            this._userService = userService;
            this._postService = postService;
        }
        [HttpGet("users")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1)
            => Ok(await _userService.GetAllAsync(new PaginationParams(page, maxPageSize)));

        
    }
}
