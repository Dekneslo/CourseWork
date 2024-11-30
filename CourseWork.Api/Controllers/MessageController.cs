using CourseWork.Domain.Contracts.MessageContracts;
using CourseWork.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        /// <summary>
        /// ��������� ��������� ������������
        /// </summary>
        /// <remarks>
        /// ������ �������:
        ///
        ///     GET /api/MessagesAsReciepent/1
        ///
        /// </remarks>
        /// <param name="userId">ID ������������</param>
        /// <returns>������ ��������� ������������</returns>
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetMessagesByUser(int userId)
        {
            var messages = await _messageService.GetMessagesByUserAsync(userId);
            return Ok(messages);
        }

        /// <summary>
        /// �������� ������ ���������
        /// </summary>
        /// <remarks>
        /// ������ �������:
        ///
        ///     POST /api/MessagesAsReciepent
        ///     {
        ///        "SenderId": 1,
        ///        "RecipientId": 2,
        ///        "MessageText": "������, ��� ����?"
        ///     }
        ///
        /// </remarks>
        /// <param name="messageDto">������ ���������</param>
        /// <returns>��������� ��������</returns>
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest messageRequest)
        {
            var message = await _messageService.SendMessageAsync(messageRequest);
            return Ok(message);
        }
        //�������� ���� ��??
        /// <summary>
        /// �������� ��� ��������� ����� ����� ��������������
        /// </summary>
        /// <param name="senderId">ID �����������</param>
        /// <param name="recipientId">ID ����������</param>
        /// <returns>������ ���������</returns>
        [HttpGet("{senderId}/to/{recipientId}")]
        public async Task<IActionResult> GetMessagesBetweenUsers(int senderId, int recipientId)
        {
            var messages = await _messageService.GetMessagesBetweenUsersAsync(senderId, recipientId);
            return Ok(messages);
        }
    }
}