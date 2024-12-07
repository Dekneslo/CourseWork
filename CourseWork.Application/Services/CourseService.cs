using CourseWork.Domain.Contracts.CourseContracts;
using CourseWork.Domain.Contracts.UserContracts;
using CourseWork.Domain.Entities;
using CourseWork.Domain.Exceptions;
using CourseWork.Domain.Interfaces;
using CourseWork.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly CharityDBContext _charityDbContext;
        
        private readonly IUserService _userService;

        public CourseService(CharityDBContext charityDbContext, IUserService userService)
        {
            _charityDbContext = charityDbContext;
            _userService = userService;
        }

        public async Task<CourseResponse[]> GetAllCoursesAsync()
        {
            return await _charityDbContext.Courses.Select(x => new CourseResponse
            {
                CategoryName = x.Category.Name,
                DateCreated = x.DateCreated,
                Description = x.Description,
                CategoryId = x.Category.CategoryId,
                CourseId = x.CourseId,
                CourseName = x.Name
            }).ToArrayAsync();
        }

        public async Task<CourseResponse> GetCourseByIdAsync(int id)
        {
            var course = await _charityDbContext.Courses.Include(x => x.Category).FirstOrDefaultAsync(x => x.CourseId == id);

            if (course == null)
            {
                throw new CourseNotFoundException();
            }
            
            return new CourseResponse
            {
                CategoryName = course.Category.Name,
                DateCreated = course.DateCreated,
                Description = course.Description,
                CategoryId = course.Category.CategoryId,
                CourseId = course.CourseId,
                CourseName = course.Name
            };
        }

        public async Task<CourseResponse> EnrollUserInCourseAsync(int courseId)
        {
            var currentUser = await _userService.GetCurrentUser();
            
            var course = await _charityDbContext.Courses
                .Include(x => x.Category).Include(x => x.EnrolledUsers)
                .FirstOrDefaultAsync(x => x.CourseId == courseId);
            if (course == null)
            {
                throw new CourseNotFoundException();
            }

            if (course.EnrolledUsers.Any(x => x.UserId == currentUser.UserId))
            {
                throw new UserAlreadyEnrolledForCourseException();
            }
            
            currentUser.EnrolledCourses.Add(course);
            await _charityDbContext.SaveChangesAsync();
            return new CourseResponse
            {
                CategoryName = course.Category.Name,
                DateCreated = course.DateCreated,
                Description = course.Description,
                CategoryId = course.Category.CategoryId,
                CourseId = course.CourseId,
                CourseName = course.Name
            };
        }

        public async Task<CourseResponse> UnEnrollUserFromCourseAsync(int courseId)
        {
            var currentUser = await _userService.GetCurrentUser();
            
            var course = await _charityDbContext.Courses
                .Include(x => x.Category).Include(x => x.EnrolledUsers)
                .FirstOrDefaultAsync(x => x.CourseId == courseId);
            
            if (course.EnrolledUsers.Contains(currentUser) == false)
            {
                throw new UserIsNotEnrolledForCourseException();
            }

            currentUser.EnrolledCourses.Remove(course);
            await _charityDbContext.SaveChangesAsync();

            return new CourseResponse
            {
                CategoryName = course.Category.Name,
                DateCreated = course.DateCreated,
                Description = course.Description,
                CategoryId = course.Category.CategoryId,
                CourseId = course.CourseId,
                CourseName = course.Name
            };
        }
    }
}
