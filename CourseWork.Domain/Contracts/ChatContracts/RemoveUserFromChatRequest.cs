namespace CourseWork.Domain.Contracts.ChatContracts
{
    public class RemoveUserFromChatRequest
    {
        public int ChatRoomId { get; set; }
        public int UserId { get; set; }
    }
}
