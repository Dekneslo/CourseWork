using System.Net;

namespace CourseWork.Domain.Exceptions;

public class CategoryNotFoundException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public CategoryNotFoundException() : base(HttpStatusCode.NotFound, HttpErrors.CategoryNotFound)
    {
    }
}