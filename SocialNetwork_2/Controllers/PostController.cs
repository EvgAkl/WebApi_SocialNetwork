using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork_2.Interfaces;
using SocialNetwork_2.Dto.Post;

namespace SocialNetwork_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetPostDto>>> GetPostsByUserId([FromQuery]int userId)
        {
            var getPostDtos = await _postService.GetPostsByUserIdAsync(userId);
            if (getPostDtos.Count == 0)
            {
                return NotFound();
            }

            return Ok(getPostDtos);
        }
    }
}