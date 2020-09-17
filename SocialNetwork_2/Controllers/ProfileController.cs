using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork_2.Interfaces;
using SocialNetwork_2.Dto;

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
        public ActionResult<GetProfileByIdDto> GetProfileById(int id)
        {
            var getProfileByIdDto = _profileService.GetProfileById(id);
            if (getProfileByIdDto == null)
            {
                return NotFound();
            }

            return Ok(getProfileByIdDto);
        }

    }
}