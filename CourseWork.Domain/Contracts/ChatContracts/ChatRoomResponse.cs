using CourseWork.Domain.Contracts.UserContracts;
using CourseWork.Domain.Entities;

namespace CourseWork.Domain.Contracts.ChatContracts;

public class ChatRoomResponse
{
    public required int ChatRoomId { get; set; }
    
    public required ChatRoomType ChatRoomType { get; set; }
    
    public required UserResponse[] Participants { get; set; }
}