using SocialNetwork_2.Dto.Post;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork_2.Interfaces
{
    public interface IPostService
    {
        List<GetPostDto> GetPostsByUserId(int userId);
        Task<List<GetPostDto>> GetPostsByUserIdAsync(int userId);
    }
}
