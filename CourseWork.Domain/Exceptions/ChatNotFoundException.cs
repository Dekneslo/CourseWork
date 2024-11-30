using System.Net;

namespace CourseWork.Domain.Exceptions;

public class ChatNotFoundException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public ChatNotFoundException() : base(HttpStatusCode.NotFound, HttpErrors.ChatNotFound)
    {
    }
}