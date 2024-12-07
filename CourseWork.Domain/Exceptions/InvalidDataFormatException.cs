using System.Net;

namespace CourseWork.Domain.Exceptions;

public class InvalidDataFormatException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public InvalidDataFormatException() : base(HttpStatusCode.BadRequest, HttpErrors.InvalidDataFormat)
    {
    }
}