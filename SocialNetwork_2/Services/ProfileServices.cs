using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork_2.Interfaces;
using Microsoft.EntityFrameworkCore;
using SocialNetwork_2.Database;
using AutoMapper;
using SocialNetwork_2.Dto.Profile;
using Profile = SocialNetwork_2.Database.DbEntities.Profile;

namespace SocialNetwork_2.Services
{
    public sealed class ProfileServices : IProfileService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public ProfileServices(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GetProfileDto GetProfileById(int id)
        {
            var profile = _dbContext.Profiles.SingleOrDefault(x => x.Id == id);
            return _mapper.Map<GetProfileDto>(profile);
        }

        public async Task<GetProfileDto> GetProfileByIdAsync(int id)
        {
            var profile = await _dbContext.Profiles.SingleOrDefaultAsync(x => x.Id == id);
            return _mapper.Map<GetProfileDto>(profile);
        }

        private static void AddProfileDtoValidate(AddProfileDto addProfileDto)
        {
            if (addProfileDto == null)
            {
                throw new ArgumentNullException(nameof(addProfileDto));
            }

            if (!addProfileDto.Validate())
            {
                throw new InvalidOperationException();
            }
        }

        public GetProfileDto AddProfile(AddProfileDto addProfileDto)
        {
            AddProfileDtoValidate(addProfileDto);

            var profile = _mapper.Map<Profile>(addProfileDto);
            _dbContext.Profiles.Add(profile);
            _dbContext.SaveChanges();
            return _mapper.Map<GetProfileDto>(profile);
        }

        public async Task<GetProfileDto> AddProfileAsync(AddProfileDto addProfileDto)
        {
            AddProfileDtoValidate(addProfileDto);

            var profile = _mapper.Map<Profile>(addProfileDto);
            await _dbContext.Profiles.AddAsync(profile);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<GetProfileDto>(profile);
        }
    }
}
