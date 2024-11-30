using CourseWork.Domain.Contracts.LikeContracts;
using CourseWork.Domain.Contracts.PostContracts;
using CourseWork.Domain.Entities;
using CourseWork.Domain.Exceptions;
using CourseWork.Domain.Interfaces;
using CourseWork.Domain.Results;
using CourseWork.Persistence;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Application.Services
{
    public class PostService : IPostService
    {
        private readonly CharityDBContext _charityDbContext;

        public PostService(CharityDBContext charityDbContext)
        {
            _charityDbContext = charityDbContext;
        }

        // Получение всех постов
        public async Task<PostResponse[]> GetAllPostsAsync()
        {
            var posts = await _charityDbContext.Posts.Select(x => new PostResponse
            {
                DatePosted = x.DatePosted,
                IdPost = x.PostId,
                PostContent = x.PostContent,
                PostTitle = x.PostTitle
            }).ToArrayAsync();
            return posts;
        }

        // Получение всех ежедневных обновлений
        public async Task<DailyUpdateResponse[]> GetAllDailyUpdatesAsync()
        {
            var posts = await _charityDbContext.DailyUpdates.Select(x => new DailyUpdateResponse()
            {
              DateOfPosted = x.DateOfPosted,
              Description = x.Description,
              IdUpdate = x.DailyUpdateId
            }).ToArrayAsync();
            return posts;
        }

        // Создание поста
        public async Task<PostResponse> CreatePostAsync(GetPostRequest getPostRequest)
        {
            if (await _charityDbContext.Users.FindAsync(getPostRequest.IdUser) == null)
            {
                throw new UserNotFoundException();
            }
            
            var post = new Post
            {
                UserId = getPostRequest.IdUser,
                PostTitle = getPostRequest.PostTitle,
                DatePosted = getPostRequest.DatePosted,
                PostContent = getPostRequest.PostContent
            };

            await _charityDbContext.Posts.AddAsync(post);
            await _charityDbContext.SaveChangesAsync();

            return new PostResponse
            {
                DatePosted = post.DatePosted,
                IdPost = post.PostId,
                PostContent = post.PostContent,
                PostTitle = post.PostTitle
            };
        }

        // Создание нового ежедневного обновления
        public async Task<DailyUpdateResponse> CreateDailyUpdateAsync(CreateDailyUpdateRequest updateRequest)
        {
            var update = new DailyUpdate
            {
                DateOfPosted = updateRequest.DateOfPosted,
                Description = updateRequest.Description,
                UserId = updateRequest.IdUser
            };
            await _charityDbContext.DailyUpdates.AddAsync(update);
            await _charityDbContext.SaveChangesAsync();
            return new DailyUpdateResponse
            {
                DateOfPosted = update.DateOfPosted,
                Description = update.Description,
                IdUpdate = update.DailyUpdateId
            };
        }

        // Обновление поста
        public async Task<PostResponse> UpdatePostAsync(UpdatePostRequest request)
        {
            var post = await _charityDbContext.Posts.FirstOrDefaultAsync(x => x.PostId == request.IdPost);
            if (post == null)
            {
                throw new PostNotFoundException();
            }

            post.PostContent = request.PostContent;
            post.PostTitle = request.PostTitle;
            
            await _charityDbContext.SaveChangesAsync();

            return new PostResponse
            {
                DatePosted = post.DatePosted,
                IdPost = post.PostId,
                PostContent = post.PostContent,
                PostTitle = post.PostTitle
            };
        }

        // Удаление поста
        public async Task<PostResponse> DeletePostAsync(int id)
        {
            var post = await _charityDbContext.Posts.FindAsync(id);
            if (post == null)
            {
                throw new PostNotFoundException();
            }

            _charityDbContext.Posts.Remove(post);
            await _charityDbContext.SaveChangesAsync();

            return new PostResponse
            {
                DatePosted = post.DatePosted,
                IdPost = post.PostId,
                PostContent = post.PostContent,
                PostTitle = post.PostTitle
            };
        }

        // Лайк поста
        public async Task<LikeOnPostResponse> LikePostAsync(LikeOnPostRequest likeOnPostRequest, int postId)
        {
            var post = await _charityDbContext.Posts.FindAsync(postId);
            var user = await _charityDbContext.Users.FindAsync(likeOnPostRequest.UserId);
            if (post == null)
            {
                throw new PostNotFoundException();
            }
            
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            
            var like = new LikeOnPost()
            {
                PostId = postId,
                UserId = likeOnPostRequest.UserId
            };

            await _charityDbContext.LikesToPosts.AddAsync(like);
            await _charityDbContext.SaveChangesAsync();
            return new LikeOnPostResponse()
            {
                PostId = like.PostId,
                UserId = like.UserId
            };
        }

        // Добавление медиафайла к посту
        public async Task<PostFile> AddFileToPostAsync(AddMediaToPostRequest request, int postId)
        {
            var post = await _charityDbContext.Posts.FindAsync(postId);
            if (post == null)
            {
                throw new PostNotFoundException();
            }

            var file = new PostFile()
            {
                FileId = post.PostId,
                PostId = post.PostId
            };

            await _charityDbContext.PostsFiles.AddAsync(file);
            await _charityDbContext.SaveChangesAsync();

            return file;
        }
    }
}
