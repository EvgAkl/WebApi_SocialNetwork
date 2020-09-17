using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialNetwork_2.Database;
using SocialNetwork_2.Dto.Post;
using SocialNetwork_2.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork_2.Services
{
    public class PostService : IPostService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;

        public PostService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<GetPostDto> GetPostsByUserId(int userId)
        {
            var posts = _dbContext.Posts.Where(x => x.ProfileId == userId).ToList();
            return _mapper.Map<List<GetPostDto>>(posts);
        }

        public async Task<List<GetPostDto>> GetPostsByUserIdAsync(int userId)
        {
            var posts = await _dbContext.Posts.Where(x => x.ProfileId == userId).ToListAsync();
            return _mapper.Map<List<GetPostDto>>(posts);
        }
    }
}
