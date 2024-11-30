using System.Net;

namespace CourseWork.Domain.Exceptions;

public class RoleNotFoundException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public RoleNotFoundException() : base(HttpStatusCode.NotFound, HttpErrors.RoleNotFound)
    {
    }
}