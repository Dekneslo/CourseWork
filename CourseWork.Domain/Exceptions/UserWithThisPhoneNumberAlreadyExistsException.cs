using System.Net;

namespace CourseWork.Domain.Exceptions;

public class UserWithThisPhoneNumberAlreadyExistsException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public UserWithThisPhoneNumberAlreadyExistsException() : base(HttpStatusCode.Conflict, HttpErrors.UserAlreadyEnrolledForCourse)
    {
    }
}