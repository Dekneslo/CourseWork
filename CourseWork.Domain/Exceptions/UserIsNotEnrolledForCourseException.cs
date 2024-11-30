using System.Net;

namespace CourseWork.Domain.Exceptions;

public class UserIsNotEnrolledForCourseException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public UserIsNotEnrolledForCourseException() : base(HttpStatusCode.BadRequest, HttpErrors.UserIsNotEnrolledForCourse)
    {
    }
}