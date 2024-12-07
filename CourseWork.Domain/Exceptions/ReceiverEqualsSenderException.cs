using System.Net;

namespace CourseWork.Domain.Exceptions;

public class ReceiverEqualsSenderException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public ReceiverEqualsSenderException() : base(HttpStatusCode.BadRequest, HttpErrors.ReceiverEqualsSender)
    {
    }
}