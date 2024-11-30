using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseWork.Domain.Contracts.ChatContracts;
using CourseWork.Domain.Entities;

namespace CourseWork.Domain.Interfaces
{
    public interface IChatService
    {
        Task<ChatRoomResponse> CreateChatRoomAsync(CreateChatRoomRequest request);
        
        Task<ChatRoomUserResponse> AddUserToChatAsync(AddUserToChatRequest request);
        
        Task<ChatRoomUserResponse> RemoveUserFromChatAsync(RemoveUserFromChatRequest request);
        
        Task<ChatRoomResponse> CreatePrivateChatAsync(CreateChatRoomRequest request);
        
        Task<ChatRoomResponse> DeleteChatRoomAsync(int chatRoomId);
    }
}
