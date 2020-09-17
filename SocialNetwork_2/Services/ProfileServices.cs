using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialNetwork_2.Interfaces;
using Microsoft.EntityFrameworkCore;
using SocialNetwork_2.Database;
using AutoMapper;
using SocialNetwork_2.Dto;

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

        public GetProfileByIdDto GetProfileById(int id)
        {
            var profile = _dbContext.Profiles.SingleOrDefault(x => x.Id == id);
            return _mapper.Map<GetProfileByIdDto>(profile);
        }
    }
}
