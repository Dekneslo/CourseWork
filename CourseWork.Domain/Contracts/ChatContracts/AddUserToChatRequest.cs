namespace CourseWork.Domain.Contracts.ChatContracts
{
    public class AddUserToChatRequest
    {
        public required int ChatRoomId { get; set; }
        
        public required int UserId { get; set; }
    }
}
