using System.Net;
using CourseWork.Domain;
using CourseWork.Domain.Exceptions;

namespace CourseWork.Domain.Exceptions;

public class InvalidLoginCredentialsException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public InvalidLoginCredentialsException() : base(HttpStatusCode.BadRequest, HttpErrors.InvalidLoginCredentials)
    {
    }
}