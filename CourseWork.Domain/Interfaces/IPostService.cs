
using CourseWork.Domain.Contracts.LikeContracts;
using CourseWork.Domain.Contracts.PostContracts;
using CourseWork.Domain.Entities;
using CourseWork.Domain.Results;

namespace CourseWork.Domain.Interfaces
{
    public interface IPostService
    {
        Task<PostResponse[]> GetAllPostsAsync();
        
        Task<DailyUpdateResponse[]> GetAllDailyUpdatesAsync();
        
        Task<PostResponse> CreatePostAsync(GetPostRequest getPostRequest);
        
        Task<DailyUpdateResponse> CreateDailyUpdateAsync(CreateDailyUpdateRequest updateRequest);
        
        Task<PostResponse> UpdatePostAsync(UpdatePostRequest request);
        
        Task<PostResponse> DeletePostAsync(int id);
        
        Task<LikeOnPostResponse> LikePostAsync(LikeOnPostRequest likeOnPostRequest, int postId);
        
        Task<PostFile> AddFileToPostAsync(AddMediaToPostRequest request, int postId);
    }
}
