using System.Net;

namespace CourseWork.Domain.Exceptions;

public class OldPasswordDoesNotMatchException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public OldPasswordDoesNotMatchException() : base(HttpStatusCode.NotFound, HttpErrors.ChatNotFound)
    {
        
    }
} 