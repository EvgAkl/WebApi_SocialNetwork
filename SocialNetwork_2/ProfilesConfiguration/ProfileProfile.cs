using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Profile = SocialNetwork_2.Database.DbEntities.Profile;
using SocialNetwork_2.Dto;

namespace SocialNetwork_2.ProfilesConfiguration
{
    public class ProfileProfile : AutoMapper.Profile
    {
        public ProfileProfile()
        {
            CreateMap<Profile, GetProfileByIdDto>();
        }
    }
}
