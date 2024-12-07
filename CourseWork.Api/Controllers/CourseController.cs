using CourseWork.Domain.Contracts.CourseContracts;
using CourseWork.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            return Ok(course);
        }
        
        [HttpPost("{courseId}/enroll")]
        public async Task<IActionResult> EnrollInCourse(int courseId)
        {
            var result = await _courseService.EnrollUserInCourseAsync(courseId);
            return Ok(result);
        }

        [HttpDelete("{courseId}/unEnroll/")]
        public async Task<IActionResult> UnEnrollFromCourse(int courseId)
        {
            var result = await _courseService.UnEnrollUserFromCourseAsync(courseId);
            return Ok(result);
        }

    }
}
