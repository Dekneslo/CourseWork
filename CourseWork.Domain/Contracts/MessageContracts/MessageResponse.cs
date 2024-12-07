using CourseWork.Domain.Contracts.UserContracts;

namespace CourseWork.Domain.Contracts.MessageContracts
{
    public class MessageResponse
    {
        public required int MessageId { get; set; }
        
        public required string MessageText { get; set; }
        
        public required UserResponse Author { get; set; }
        
        public required DateTime SentDate { get; set; }
    }
}
