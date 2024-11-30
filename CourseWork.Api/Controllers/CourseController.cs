using CourseWork.Domain.Contracts.CommentContracts;
using CourseWork.Domain.Contracts.CourseContracts;
using CourseWork.Domain.Contracts.LikeContracts;
using CourseWork.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// Получение всех курсов
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET /api/Course
        ///
        /// </remarks>
        /// <returns>Список всех курсов</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }

        /// <summary>
        /// Получение информации о курсе по ID
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     GET /api/Course/1
        /// 
        /// </remarks>
        /// <param name="id">ID курса</param>
        /// <returns>Информация о курсе</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            return Ok(course);
        }

        /// <summary>
        /// Создание нового курса
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     POST /api/Course
        ///     {
        ///        "CourseName" : "Программирование на C#",
        ///        "Description" : "Курс по основам программирования на C#",
        ///        "CategoryId" : 1
        ///     }
        /// 
        /// </remarks>
        /// <param name="courseDto">Модель курса</param>
        /// <returns>Созданный курс</returns>
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest courseRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _courseService.CreateCourseAsync(courseRequest);
            return Ok(result);
        }

        /// <summary>
        /// Обновление курса
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     PUT /api/Course/1
        ///     {
        ///        "CourseName" : "Программирование на C# - Обновленный",
        ///        "Description" : "Обновленная информация по курсу"
        ///     }
        /// 
        /// </remarks>
        /// <param name="id">ID курса</param>
        /// <param name="courseDto">Модель для обновления курса</param>
        /// <returns>Обновленный курс</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CreateCourseRequest courseRequest)
        {
            var result = await _courseService.UpdateCourseAsync(id, courseRequest);
            return Ok(result);
        }

        /// <summary>
        /// Удаление курса
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        /// 
        ///     DELETE /api/Course/1
        /// 
        /// </remarks>
        /// <param name="id">ID курса</param>
        /// <returns>Результат операции</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _courseService.DeleteCourseAsync(id);
            return NoContent();
        }

        /// <summary>
        /// Лайк курса
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /api/Course/1/like
        ///
        /// </remarks>
        /// <param name="courseId">ID курса</param>
        /// <param name="request">Запрос с ID пользователя</param>
        /// <returns>Результат операции</returns>
        [HttpPost("{courseId}/like")]
        public async Task<IActionResult> LikeCourse([FromBody] LikeOnCourseRequest request)
        {
            var result = await _courseService.LikeCourseAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// Записать пользователя на курс
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /api/Course/1/enroll
        ///     {
        ///         "userId": 1
        ///     }
        /// </remarks>
        [HttpPost("{courseId}/enroll")]
        public async Task<IActionResult> EnrollUserInCourse(int courseId, [FromBody] EnrollUserRequest request)
        {
            var result = await _courseService.EnrollUserInCourseAsync(courseId, request);
            return Ok(result);
        }

        /// <summary>
        /// Удалить пользователя с курса
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     DELETE /api/Course/1/unenroll/1
        /// </remarks>
        [HttpDelete("{courseId}/unenroll/{userId}")]
        public async Task<IActionResult> UnenrollUserFromCourse(int courseId, int userId)
        {
            var result = await _courseService.UnenrollUserFromCourseAsync(courseId, userId);
            return Ok(result);
        }

        /// <summary>
        /// Добавление медиа к курсу
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /api/Course/1/media
        ///
        /// </remarks>
        /// <param name="courseId">ID курса</param>
        /// <param name="request">Запрос с данными медиафайлов</param>
        /// <returns>Результат операции</returns>
        [HttpPost("{courseId}/media")]
        public async Task<IActionResult> AddMediaToCourse(int courseId, [FromBody] AddMediaToCourseRequest request)
        {
            var result = await _courseService.AddMediaToCourseAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// Добавление комментария к курсу
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /api/Course/1/comment
        ///     {
        ///        "CommentText": "Отличный курс!",
        ///        "UserId": 1
        ///     }
        ///
        /// </remarks>
        /// <param name="courseId">ID курса</param>
        /// <param name="request">Запрос с данными комментария</param>
        /// <returns>Результат операции</returns>
        [HttpPost("{courseId}/comment")]
        public async Task<IActionResult> AddCommentToCourse(int courseId, [FromBody] AddCommentRequest request)
        {
            var result = await _courseService.AddCommentAsync(courseId, request);
            return Ok(result);
        }

        /// <summary>
        /// Добавление комментария к курсу
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /api/Course/1/comment
        ///
        /// </remarks>
        /// <param name="courseId">ID курса</param>
        /// <param name="request">Запрос для добавления комментария</param>
        /// <returns>Результат операции</returns>
        [HttpPost("{courseId}/add-comment")]
        public async Task<IActionResult> CommentOnCourse(int courseId, [FromBody] AddCommentRequest request)
        {
            var result = await _courseService.AddCommentAsync(courseId, request);
            return Ok(result);
        }
    }
}
