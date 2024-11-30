using System.Net;

namespace CourseWork.Domain.Exceptions;

public class CourseNotFoundException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public CourseNotFoundException() : base(HttpStatusCode.NotFound, HttpErrors.CourseNotFound)
    {
    }
}