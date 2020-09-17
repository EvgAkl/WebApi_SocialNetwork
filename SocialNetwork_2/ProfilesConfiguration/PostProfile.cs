using SocialNetwork_2.Database.DbEntities;
using SocialNetwork_2.Dto.Post;

namespace SocialNetwork_2.ProfilesConfiguration
{
    public class PostProfile : AutoMapper.Profile
    {
        public PostProfile()
        {
            CreateMap<Post, GetPostDto>();
        }

    }
}
