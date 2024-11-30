namespace CourseWork.Domain.Contracts.ChatContracts
{
    public class AddUserToChatRequest
    {
        public int ChatRoomId { get; set; }
        public int UserId { get; set; }
    }
}
