using CourseWork.Domain.Contracts.CommentContracts;
using CourseWork.Domain.Contracts.CourseContracts;
using CourseWork.Domain.Contracts.LikeContracts;
using CourseWork.Domain.Entities;
using CourseWork.Domain.Exceptions;
using CourseWork.Domain.Interfaces;
using CourseWork.Domain.Results;
using CourseWork.Persistence;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly CharityDBContext _charityDbContext;

        public CourseService(CharityDBContext charityDbContext)
        {
            _charityDbContext = charityDbContext;
        }

        public async Task<CourseResponse[]> GetAllCoursesAsync()
        {
            return await _charityDbContext.Courses.Select(x => new CourseResponse
            {
                CategoryName = x.Category.CategoryName,
                DateCreated = x.DateCreated,
                Description = x.Description,
                IdCategory = x.CategoryId,
                IdCourse = x.CourseId,
                NameCourse = x.CourseName
            }).ToArrayAsync();
        }

        public async Task<CourseResponse> GetCourseByIdAsync(int id)
        {
            var course = await _charityDbContext.Courses.FindAsync(id);

            return new CourseResponse
            {
                CategoryName = course.Category.CategoryName,
                DateCreated = course.DateCreated,
                Description = course.Description,
                IdCategory = course.CategoryId,
                IdCourse = course.CourseId,
                NameCourse = course.CourseName
            };
        }

        public async Task<CourseResponse> CreateCourseAsync(CreateCourseRequest courseRequest)
        {
            var course = new Course
            {
                CourseName = courseRequest.NameCourse,
                Description = courseRequest.Description,
                CategoryId = courseRequest.IdCategory
            };

            await _charityDbContext.Courses.AddAsync(course);
            await _charityDbContext.SaveChangesAsync();

            return new CourseResponse
            {
                CategoryName = course.Category.CategoryName,
                DateCreated = course.DateCreated,
                Description = course.Description,
                IdCategory = course.CategoryId,
                IdCourse = course.CourseId,
                NameCourse = course.CourseName
            };
        }

        public async Task<CourseResponse> UpdateCourseAsync(int id, CreateCourseRequest courseRequest)
        {
            var course = await _charityDbContext.Courses.FindAsync(id);
            if (course == null)
            {
                throw new CourseNotFoundException();
            }

            courseRequest.Adapt(course);

            course.CourseName = courseRequest.NameCourse;
            course.Description = courseRequest.Description;
            await _charityDbContext.SaveChangesAsync();

            return new CourseResponse
            {
                CategoryName = course.Category.CategoryName,
                DateCreated = course.DateCreated,
                Description = course.Description,
                IdCategory = course.CategoryId,
                IdCourse = course.CourseId,
                NameCourse = course.CourseName
            };
        }

        public async Task<CourseResponse> DeleteCourseAsync(int id)
        {
            var course = await _charityDbContext.Courses.FindAsync(id);
            if (course == null)
            {
                throw new CourseNotFoundException();
            }

            _charityDbContext.Courses.Remove(course);
            await _charityDbContext.SaveChangesAsync();

            return new CourseResponse
            {
                CategoryName = course.Category.CategoryName,
                DateCreated = course.DateCreated,
                Description = course.Description,
                IdCategory = course.CategoryId,
                IdCourse = course.CourseId,
                NameCourse = course.CourseName
            };
        }

        // Получить курсы по категории
        public async Task<CourseResponse[]> GetCoursesByCategoryAsync(int categoryId)
        {
            var courses =  await _charityDbContext.Courses.Where(x => x.CategoryId == categoryId).ToArrayAsync();
            return courses.Select(x => new CourseResponse
            {
                CategoryName = x.Category.CategoryName,
                DateCreated = x.DateCreated,
                Description = x.Description,
                IdCategory = x.CategoryId,
                IdCourse = x.CourseId,
                NameCourse = x.CourseName
            }).ToArray();
        }


        public async Task<LikeOnCourseResponse> LikeCourseAsync(LikeOnCourseRequest likeOnCourseRequest)
        {
            var like = new LikeOnCourse()
            {
                CourseId = likeOnCourseRequest.CourseId,
                UserId = likeOnCourseRequest.UserId
            };

            await _charityDbContext.LikesToCourses.AddAsync(like);
            return new LikeOnCourseResponse
            {
                CourseId = like.CourseId,
                UserId = like.UserId
            };
        }
        
        public async Task<CommentResponse> AddCommentAsync(int courseId, AddCommentRequest commentRequest)
        {
            var courseComment = new Comment
            {
                UserId = commentRequest.UserId,
                CourseId = courseId,
                CommentDescription = commentRequest.CommentText,
                DateCommented = DateTime.Now
            };

            var course = await _charityDbContext.Courses.FindAsync(courseId);
            course.Comments.Add(courseComment);
            await _charityDbContext.SaveChangesAsync();
            return new CommentResponse
            {
                CommentId = courseComment.CommentId,
                CommentText = courseComment.CommentDescription
            };
        }

        public async Task<CourseMediaResponse> AddMediaToCourseAsync(AddMediaToCourseRequest request)
        {
            var courseMedia = new CourseFile
            {
                CourseId = request.CourseId,
                FileId = request.FileId
            };

            await _charityDbContext.CoursesFiles.AddAsync(courseMedia);
            await _charityDbContext.SaveChangesAsync();

            return new CourseMediaResponse
            {
                CourseId = courseMedia.CourseId,
                FileName = courseMedia.File.FileName,
                MediaId = courseMedia.FileId
            };
        }

        public async Task<UsersCourse> EnrollUserInCourseAsync(int courseId, EnrollUserRequest enrollUserRequest)
        {
            var userCourse = new UsersCourse
            {
                CourseId = courseId,
                UserId = enrollUserRequest.UserId
            };

            await _charityDbContext.UsersCourses.AddAsync(userCourse);
            return userCourse;
        }

        public async Task<UsersCourse> UnenrollUserFromCourseAsync(int courseId, int userId)
        {
            var userCourse = await _charityDbContext.UsersCourses.FirstOrDefaultAsync(x =>
                    x.CourseId == courseId 
                    && x.UserId == userId);
            
            if (userCourse == null)
            {
                throw new UserIsNotEnrolledForCourseException();
            }

            _charityDbContext.UsersCourses.Remove(userCourse);
            await _charityDbContext.SaveChangesAsync();

            return userCourse;
        }
    }
}
