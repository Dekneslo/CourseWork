using System.Net;

namespace CourseWork.Domain.Exceptions;

public class AccessDeniedException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public AccessDeniedException() : base(HttpStatusCode.Forbidden, HttpErrors.AccessDenied)
    {
    }
}