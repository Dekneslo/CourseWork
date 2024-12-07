using CourseWork.Domain.Contracts.MessageContracts;
using CourseWork.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("{conversationId}")]
        public async Task<IActionResult> GetMessages(int conversationId)
        {
            var messages = await _messageService.GetMessages(conversationId);
            return Ok(messages);
        }
        
        [HttpPost]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest messageRequest)
        {
            var message = await _messageService.SendMessageAsync(messageRequest);
            return Ok(message);
        }
    }
}