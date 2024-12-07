using CourseWork.Domain.Contracts.ChatContracts;
using CourseWork.Domain.Contracts.UserContracts;
using CourseWork.Domain.Entities;
using CourseWork.Domain.Exceptions;
using CourseWork.Domain.Interfaces;
using CourseWork.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Application.Services
{
    public class ChatService : IChatService
    {
        private readonly CharityDBContext _charityDbContext;

        private readonly IUserService _userService;
        
        
        public ChatService(CharityDBContext charityDbContext, IUserService userService)
        {
            _charityDbContext = charityDbContext;
            _userService = userService;
        }

        public async Task<ChatRoomResponse> CreateChatRoom(CreateChatRoomRequest conversationRequestDto)
        {
            var currentUser = await _userService.GetCurrentUser();

            var receivers = await _charityDbContext.Users
                .Where(u => conversationRequestDto.ReceiverIds.Contains(u.UserId))
                .ToListAsync();

            if (receivers.Count != conversationRequestDto.ReceiverIds.Length)
                throw new WrongConversationParticipantsIdsException();

            if (receivers.Contains(currentUser)) 
                throw new ReceiverEqualsSenderException();

            receivers.Add(currentUser);

            var participants = new List<User>(receivers);
            var conversationType = receivers.Count > 2 ? ChatRoomType.Conversation : ChatRoomType.Dialogue;


            var existingChat = await _charityDbContext.ChatRooms
                .Include(x => x.Users)
                .FirstOrDefaultAsync(p => p.Users
                    .All(c => receivers.Contains(c) && p.ChatRoomType == ChatRoomType.Dialogue));

            if (existingChat is not null)
            {
                return new ChatRoomResponse
                {
                    ChatRoomId = existingChat.ChatRoomId,
                    ChatRoomType = existingChat.ChatRoomType,
                    Participants = participants.Select(x => new UserResponse
                    {
                        Biography = x.Biography,
                        City = x.City,
                        Country = x.Country,
                        Email = x.Email,
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        PhoneNumber = x.PhoneNumber
                    }).ToArray()
                };
            }

            var conversation = new ChatRoom()
            {
                ChatRoomType = conversationType,
                Users = participants
            };

            await _charityDbContext.ChatRooms.AddAsync(conversation);
            await _charityDbContext.SaveChangesAsync();

            return new ChatRoomResponse
            {
                ChatRoomType = conversationType,
                ChatRoomId = conversation.ChatRoomId,
                Participants = participants.Select(x => new UserResponse
                {
                    Biography = x.Biography,
                    City = x.City,
                    Country = x.Country,
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    PhoneNumber = x.PhoneNumber
                }).ToArray()
            };
        }
    }
}
