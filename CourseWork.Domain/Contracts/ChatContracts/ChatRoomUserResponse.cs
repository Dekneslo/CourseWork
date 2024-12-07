namespace CourseWork.Domain.Contracts.ChatContracts;

public class ChatRoomUserResponse
{
    public required int IdChatRoom { get; set; }
    
    public required int IdUser { get; set; }
}