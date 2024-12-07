using System.Net;

namespace CourseWork.Domain.Exceptions;

public class ChatRoomNotFoundException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public ChatRoomNotFoundException() : base(HttpStatusCode.NotFound, HttpErrors.ChatNotFound)
    {
    }
}