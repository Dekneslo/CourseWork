using System.Net;

namespace CourseWork.Domain.Exceptions;

public class FileNotFoundException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public FileNotFoundException() : base(HttpStatusCode.NotFound, HttpErrors.FileNotFound)
    {
    }
}