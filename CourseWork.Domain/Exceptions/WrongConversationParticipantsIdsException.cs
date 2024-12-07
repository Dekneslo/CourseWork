using System.Net;
using CourseWork.Domain;
using CourseWork.Domain.Exceptions;

namespace CourseWork.Domain.Exceptions;

public class WrongConversationParticipantsIdsException : BaseException
{
    /// <summary>
    ///     Конструктор исключения, в котором указывается код и текст ошибки.
    /// </summary>
    public WrongConversationParticipantsIdsException() : base(HttpStatusCode.BadRequest,
        HttpErrors.WrongConversationParticipants)
    {
    }
}