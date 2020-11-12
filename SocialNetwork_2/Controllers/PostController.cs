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

        [HttpGet("{id}", Name = nameof(GetPostById))]
        public async Task<ActionResult<GetPostDto>> GetPostById(int id)
        {
            var getPostDto = await _postService.GetPostByIdAsync(id);
            if(getPostDto == null)
            {
                return NotFound();
            }
            return Ok(getPostDto);
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

        [HttpPost]
        public async Task<ActionResult<GetPostDto>> CreatePost(AddPostDto addPostDto)
        {
            GetPostDto getPostDto = null;
            try
            {
                getPostDto = await _postService.AddPostAsync(addPostDto);
            }
            catch
            {
                return BadRequest();
            }

            return CreatedAtRoute(nameof(GetPostById), new { id = getPostDto.Id }, getPostDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdatePost(UpdatePostDto updatePostDto)
        {
            try
            {
                await _postService.UpdatePostAsync(updatePostDto);
            }
            catch
            {
                BadRequest();
            }
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePost(int id)
        {
            try
            {
                await _postService.DeletePostAsync(id);
            }
            catch
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}