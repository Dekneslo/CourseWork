using CourseWork.Domain.Contracts.MessageContracts;

namespace CourseWork.Domain.Interfaces
{
    public interface IMessageService
    {
        Task<MessageResponse[]> GetMessages(int chatRoomId); 
        
        Task<MessageResponse> SendMessageAsync(SendMessageRequest messageRequest); 
    }
}
