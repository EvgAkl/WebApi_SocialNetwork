using SocialNetwork_2.Dto.Post;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork_2.Interfaces
{
    public interface IPostService
    {
        GetPostDto GetPostById(int id);
        Task<GetPostDto> GetPostByIdAsync(int id);
        List<GetPostDto> GetPostsByUserId(int userId);
        Task<List<GetPostDto>> GetPostsByUserIdAsync(int userId);
        GetPostDto AddPost(AddPostDto addPostDto);
        Task<GetPostDto> AddPostAsync(AddPostDto addPostDto);
        void UpdatePost(UpdatePostDto updatePostDto);
        Task UpdatePostAsync(UpdatePostDto updatePostDto);
        void DeletePost(int id);
        Task DeletePostAsync(int id);
    }
}
