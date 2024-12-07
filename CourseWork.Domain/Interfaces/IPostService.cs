
using CourseWork.Domain.Contracts.PostContracts;

namespace CourseWork.Domain.Interfaces
{
    public interface IPostService
    {
        
        Task<PostResponse> CreatePostAsync(CreatePostRequest createPostRequest);
        
        Task<PostResponse> UpdatePostAsync(int id, UpdatePostRequest request);
        
        Task<PostResponse> DeletePostAsync(int id);
    }
}
