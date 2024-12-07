namespace CourseWork.Domain.Contracts.MessageContracts
{
    public class SendMessageRequest
    {
        public required string MessageText { get; set; }
        
        public required int ChatRoomId { get; set; }
    }
}
