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

        [HttpGet("{id}")]
        public async Task<ActionResult<GetProfileByIdDto>> GetProfileById(int id)
        {
            var getProfileByIdDto = await _profileService.GetProfileByIdAsync(id);
            if (getProfileByIdDto == null)
            {
                return NotFound();
            }

            return Ok(getProfileByIdDto);
        }

    }
}