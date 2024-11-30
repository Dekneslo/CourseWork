using System.Net;

namespace CourseWork.Domain.Exceptions;

public class PostNotFoundException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public PostNotFoundException() : base(HttpStatusCode.NotFound, HttpErrors.PostNotFound)
    {
    }
}