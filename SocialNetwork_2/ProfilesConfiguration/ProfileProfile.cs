using SocialNetwork_2.Dto.Profile;
using Profile = SocialNetwork_2.Database.DbEntities.Profile;

namespace SocialNetwork_2.ProfilesConfiguration
{
    public class ProfileProfile : AutoMapper.Profile
    {
        public ProfileProfile()
        {
            CreateMap<Profile, GetProfileDto>();
        }
    }
}
