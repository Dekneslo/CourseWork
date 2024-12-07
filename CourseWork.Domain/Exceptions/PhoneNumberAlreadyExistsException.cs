using System.Net;
using CourseWork.Domain;
using CourseWork.Domain.Exceptions;

namespace CourseWork.Domain.Exceptions;

public class PhoneNumberAlreadyExistsException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public PhoneNumberAlreadyExistsException() : base(HttpStatusCode.Conflict, HttpErrors.PhoneNumberAlreadyExists)
    {
    }
}