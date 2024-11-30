using CourseWork.Domain.Contracts.ChatContracts;
using CourseWork.Domain.Entities;
using CourseWork.Domain.Exceptions;
using CourseWork.Domain.Interfaces;
using CourseWork.Domain.Results;
using CourseWork.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Application.Services
{
    public class ChatService : IChatService
    {
        
        private readonly CharityDBContext _charityDbContext;

        public ChatService(CharityDBContext charityDbContext)
        {
            _charityDbContext = charityDbContext;
        }

        public async Task<ChatRoomResponse> CreateChatRoomAsync(CreateChatRoomRequest request)
        {
            var chatRoom = new ChatRoom
            {
                RoomName = request.ChatRoomName
            };
            await _charityDbContext.ChatRooms.AddAsync(chatRoom);
            await _charityDbContext.SaveChangesAsync();
            return new ChatRoomResponse
            {
                IdChatRoom = chatRoom.ChatRoomId,
                NameRoom = chatRoom.RoomName
            };
        }

        public async Task<ChatRoomUserResponse> AddUserToChatAsync(AddUserToChatRequest request)
        {
            var chatRoom = await _charityDbContext.ChatRooms
                .Include(c => c.ChatRoomUsers)
                .FirstOrDefaultAsync(c => c.ChatRoomId == request.ChatRoomId);

            if (chatRoom == null)
            {
                throw new ChatNotFoundException();
            }

            var user = await _charityDbContext.Users.FindAsync(request.UserId);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            var chatRoomUser = new ChatRoomUser
            {
                ChatRoomId = request.ChatRoomId,
                UserId = request.UserId
            };

            await _charityDbContext.ChatRoomUsers.AddAsync(chatRoomUser);
            await _charityDbContext.SaveChangesAsync();
            
            return new ChatRoomUserResponse
            {
                IdChatRoom = chatRoomUser.ChatRoomId,
                IdUser = chatRoomUser.UserId
            };
        }

        public async Task<ChatRoomUserResponse> RemoveUserFromChatAsync(RemoveUserFromChatRequest request)
        {
            var chatRoomUser = await _charityDbContext.ChatRoomUsers
                .FirstOrDefaultAsync(cru => cru.ChatRoomId == request.ChatRoomId && cru.UserId == request.UserId);
            if (chatRoomUser == null)
            {
                throw new UserNotFoundException();
            }

            _charityDbContext.ChatRoomUsers.Remove(chatRoomUser);
            await _charityDbContext.SaveChangesAsync();
            return new ChatRoomUserResponse
            {
                IdChatRoom = chatRoomUser.ChatRoomId,
                IdUser = chatRoomUser.UserId
            };
        }

        public async Task<ChatRoomResponse> DeleteChatRoomAsync(int chatRoomId)
        {
            var chatRoom = await _charityDbContext.ChatRooms
                .Include(c => c.ChatRoomUsers)
                .FirstOrDefaultAsync(c => c.ChatRoomId == chatRoomId);
            _charityDbContext.ChatRooms.Remove(chatRoom);
            await _charityDbContext.SaveChangesAsync();
            return new ChatRoomResponse
            {
                IdChatRoom = chatRoom.ChatRoomId,
                NameRoom = chatRoom.RoomName
            };
        }
        
        
        public async Task<ChatRoomResponse> CreatePrivateChatAsync(CreateChatRoomRequest request)
        {
            var privateChat = new ChatRoom
            {
                RoomName = request.ChatRoomName
            };
            await _charityDbContext.ChatRooms.AddAsync(privateChat);
            await _charityDbContext.SaveChangesAsync();
            return new ChatRoomResponse
            {
                IdChatRoom = privateChat.ChatRoomId,
                NameRoom = privateChat.RoomName
            };
        }
        
        
    }
}
