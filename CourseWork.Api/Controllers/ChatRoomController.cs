using CourseWork.Domain.Contracts.ChatContracts;
using CourseWork.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ChatRoomController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatRoomController(IChatService chatService)
    {
        _chatService = chatService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateChatRoom([FromBody] CreateChatRoomRequest request)
    {
        var result = await _chatService.CreateChatRoom(request);
        return Ok(result);
    }
}