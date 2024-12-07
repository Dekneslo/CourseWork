using CourseWork.Domain.Contracts.PostContracts;
using CourseWork.Domain.Entities;
using CourseWork.Domain.Exceptions;
using CourseWork.Domain.Interfaces;
using CourseWork.Persistence;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Application.Services
{
    public class PostService : IPostService
    {
        private readonly CharityDBContext _charityDbContext;
        
        private readonly IUserService _userService;
        public PostService(CharityDBContext charityDbContext, IUserService userService)
        {
            _charityDbContext = charityDbContext;
            _userService = userService;
        }

        public async Task<PostResponse[]> GetAllPostsAsync()
        {
            var posts = await _charityDbContext.Posts.Select(x => new PostResponse
            {
                DatePosted = x.DatePosted,
                IdPost = x.PostId,
                PostContent = x.Content,
                PostTitle = x.Title
            }).ToArrayAsync();
            return posts;
        }

        public async Task<PostResponse> CreatePostAsync(CreatePostRequest createPostRequest)
        {
            var user = await _userService.GetCurrentUser();
            
            var post = new Post
            {
                
                Title = createPostRequest.PostTitle,
                Content = createPostRequest.PostContent,
                User = user
            };

            await _charityDbContext.Posts.AddAsync(post);
            await _charityDbContext.SaveChangesAsync();

            return new PostResponse
            {
                DatePosted = post.DatePosted,
                IdPost = post.PostId,
                PostContent = post.Content,
                PostTitle = post.Title
            };
        }

        public async Task<PostResponse> UpdatePostAsync(int id, UpdatePostRequest request)
        {
            var user = await _userService.GetCurrentUser();
            var post = await _charityDbContext.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            
            if (post == null)
            {
                throw new PostNotFoundException();
            }

            if (post.User != user)
            {
                throw new AccessDeniedException();
            }
            
            post.Content = request.PostContent;
            post.Title = request.PostTitle;
            
            await _charityDbContext.SaveChangesAsync();

            return new PostResponse
            {
                DatePosted = post.DatePosted,
                IdPost = post.PostId,
                PostContent = post.Content,
                PostTitle = post.Title
            };
        }

        public async Task<PostResponse> DeletePostAsync(int id)
        {
            var user = await _userService.GetCurrentUser();
            var post = await _charityDbContext.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            
            if (post == null)
            {
                throw new PostNotFoundException();
            }

            if (post.User != user)
            {
                throw new AccessDeniedException();
            }
            _charityDbContext.Posts.Remove(post);
            await _charityDbContext.SaveChangesAsync();

            return new PostResponse
            {
                DatePosted = post.DatePosted,
                IdPost = post.PostId,
                PostContent = post.Content,
                PostTitle = post.Title
            };
        }

    }
}
