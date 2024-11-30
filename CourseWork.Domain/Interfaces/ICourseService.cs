using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork.Domain.Contracts.CommentContracts;
using CourseWork.Domain.Contracts.CourseContracts;
using CourseWork.Domain.Contracts.LikeContracts;
using CourseWork.Domain.Entities;
using CourseWork.Domain.Results;

namespace CourseWork.Domain.Interfaces
{
    public interface ICourseService
    {
        Task<CourseResponse[]> GetAllCoursesAsync();
        
        Task<CourseResponse> GetCourseByIdAsync(int id);
        
        Task<CourseResponse> CreateCourseAsync(CreateCourseRequest courseRequest);
        
        Task<CourseResponse> UpdateCourseAsync(int id, CreateCourseRequest courseRequest);
        
        Task<CourseResponse> DeleteCourseAsync(int id);
        
        Task<LikeOnCourseResponse> LikeCourseAsync(LikeOnCourseRequest likeOnCourseRequest);
        
        Task<CommentResponse> AddCommentAsync(int courseId, AddCommentRequest commentRequest);  
        
        Task<CourseMediaResponse> AddMediaToCourseAsync(AddMediaToCourseRequest request);  
        
        Task<UsersCourse> EnrollUserInCourseAsync(int userId, EnrollUserRequest enrollUserRequest);
        
        Task<UsersCourse> UnenrollUserFromCourseAsync(int courseId, int userId);
    }
}
