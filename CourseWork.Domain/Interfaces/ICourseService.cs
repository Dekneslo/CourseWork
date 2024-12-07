using CourseWork.Domain.Contracts.CourseContracts;

namespace CourseWork.Domain.Interfaces
{
    public interface ICourseService
    {
        Task<CourseResponse[]> GetAllCoursesAsync();
        
        Task<CourseResponse> GetCourseByIdAsync(int id);

        Task<CourseResponse> EnrollUserInCourseAsync(int courseId);
        
        Task<CourseResponse> UnEnrollUserFromCourseAsync(int courseId);
    }
}
