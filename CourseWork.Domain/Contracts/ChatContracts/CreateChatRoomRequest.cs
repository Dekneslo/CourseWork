namespace CourseWork.Domain.Contracts.ChatContracts
{
    public class CreateChatRoomRequest
    {
        public required int[] ReceiverIds { get; set; }
    }
}
