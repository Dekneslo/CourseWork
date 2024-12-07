using System.Net;

namespace CourseWork.Domain.Exceptions;

public class UserAlreadyEnrolledForCourseException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public UserAlreadyEnrolledForCourseException() : base(HttpStatusCode.BadRequest, HttpErrors.UserAlreadyEnrolledForCourse)
    {
    }
}