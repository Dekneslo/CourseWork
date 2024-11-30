using CourseWork.Domain.Contracts.MessageContracts;

namespace CourseWork.Domain.Interfaces
{
    public interface IMessageService
    {
        Task<MessageResponse[]> GetMessagesByUserAsync(int userId); 
        
        Task<MessageResponse> SendMessageAsync(SendMessageRequest messageRequest); 
        
        Task<MessageResponse[]> GetMessagesBetweenUsersAsync(int senderId, int recipientId);
    }
}
