using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork_2.Interfaces;
using SocialNetwork_2.Dto.Profile;

namespace SocialNetwork_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpGet("{id}", Name = nameof(GetProfileById))]
        public async Task<ActionResult<GetProfileDto>> GetProfileById(int id)
        {
            var getProfileByIdDto = await _profileService.GetProfileByIdAsync(id);
            if (getProfileByIdDto == null)
            {
                return NotFound();
            }

            return Ok(getProfileByIdDto);
        }

        [HttpPost]
        public async Task<ActionResult<GetProfileDto>> CreateProfile(AddProfileDto addProfileDto)
        {
            GetProfileDto getProfileDto = null;
            try
            {
                getProfileDto = await _profileService.AddProfileAsync(addProfileDto);
            }
            catch
            {
                return BadRequest();
            }

            return CreatedAtRoute(nameof(GetProfileById), new { id = getProfileDto.Id }, getProfileDto);
        }

    }
}