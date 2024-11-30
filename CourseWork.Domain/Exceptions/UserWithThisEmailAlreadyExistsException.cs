using System.Net;

namespace CourseWork.Domain.Exceptions;

public class UserWithThisEmailAlreadyExistsException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public UserWithThisEmailAlreadyExistsException() : base(HttpStatusCode.Conflict, HttpErrors.UserWithThisEmailAlreadyExists)
    {
    }
}