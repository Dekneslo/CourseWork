using System.Net;
using CourseWork.Domain;
using CourseWork.Domain.Exceptions;

namespace CourseWork.Domain.Exceptions;

public class InvalidRegistrationDataException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public InvalidRegistrationDataException() : base(HttpStatusCode.BadRequest, HttpErrors.InvalidRegistrationData)
    {
    }
}