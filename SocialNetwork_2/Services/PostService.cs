using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SocialNetwork_2.Database;
using SocialNetwork_2.Database.DbEntities;
using SocialNetwork_2.Dto.Post;
using SocialNetwork_2.Interfaces;
using System;
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

        private Post GetPost(int id)
        {
            var post = _dbContext.Posts.SingleOrDefault(x => x.Id == id);
            return post;
        }

        private async Task<Post> GetPostAsync(int id)
        {
            var post = await _dbContext.Posts.SingleOrDefaultAsync(x => x.Id == id);
            return post;
        }

        public GetPostDto GetPostById(int id)
        {
            var post = GetPost(id);
            return _mapper.Map<GetPostDto>(post);
        }

        public async Task<GetPostDto> GetPostByIdAsync(int id)
        {
            var post = await GetPostAsync(id);
            return _mapper.Map<GetPostDto>(post);
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

        private static void AddPostValidate(AddPostDto addPostDto)
        {
            if (addPostDto == null)
            {
                throw new ArgumentNullException(nameof(addPostDto));
            }

            if (!addPostDto.Validate())
            {
                throw new InvalidOperationException();
            }
        }

        public GetPostDto AddPost(AddPostDto addPostDto)
        {
            AddPostValidate(addPostDto);

            var post = _mapper.Map<Post>(addPostDto);
            post.Date = DateTime.Now;
            _dbContext.Posts.Add(post);
            _dbContext.SaveChanges();
            return _mapper.Map<GetPostDto>(post);

        }

        public async Task<GetPostDto> AddPostAsync(AddPostDto addPostDto)
        {
            AddPostValidate(addPostDto);

            var post = _mapper.Map<Post>(addPostDto);
            post.Date = DateTime.Now;
            await _dbContext.AddAsync(post);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<GetPostDto>(post);

        }

        private void UpdatePostValidate(UpdatePostDto updatePostDto)
        {
            if (updatePostDto == null)
            {
                throw new ArgumentNullException(nameof(updatePostDto));
            }

            if (!updatePostDto.Validate())
            {
                throw new InvalidOperationException();
            }
        }

        public void UpdatePost(UpdatePostDto updatePostDto)
        {
            UpdatePostValidate(updatePostDto);

            var post = GetPost(updatePostDto.Id);
            _mapper.Map(updatePostDto, post);
            post.Date = DateTime.Now;
            _dbContext.SaveChanges();
        }

        public async Task UpdatePostAsync(UpdatePostDto updatePostDto)
        {
            UpdatePostValidate(updatePostDto);

            var post = await GetPostAsync(updatePostDto.Id);
            _mapper.Map(updatePostDto, post);
            post.Date = DateTime.Now;
            await _dbContext.SaveChangesAsync();
        }

        public void DeletePost(int id)
        {
            var post = GetPost(id);
            if (post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }
            _dbContext.Remove(post);
            _dbContext.SaveChanges();
        }

        public async Task DeletePostAsync(int id)
        {
            var post = await GetPostAsync(id);
            if(post == null)
            {
                throw new ArgumentNullException(nameof(post));
            }
            _dbContext.Remove(post);
            await _dbContext.SaveChangesAsync();
        }
    }
}
