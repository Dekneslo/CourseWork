 using System.Xml.Schema;
 using CourseWork.Domain.Contracts.MessageContracts;
 using CourseWork.Domain.Contracts.PostContracts;
 using CourseWork.Domain.Contracts.UserContracts;
 using CourseWork.Domain.Entities;
 using CourseWork.Domain.Exceptions;
 using CourseWork.Domain.Interfaces;
using CourseWork.Persistence;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Application.Services
{
    public class MessagesService : IMessageService
    {
        private readonly CharityDBContext _charityDbContext;
        private readonly IUserService _userService;

        public MessagesService(CharityDBContext charityDbContext, IUserService userService)
        {
            _charityDbContext = charityDbContext;
            _userService = userService;
        }

        public async Task<MessageResponse[]> GetMessages(int chatRoomId)
        {
            var user =  await _userService.GetCurrentUser();
            
            var chatRoom = await _charityDbContext.ChatRooms.FirstOrDefaultAsync(x => x.ChatRoomId == chatRoomId);

            if (chatRoom == null)
            {
                throw new ChatRoomNotFoundException();
            }

            if (chatRoom.Users.All(x => x.UserId != user.UserId))
            {
                throw new AccessDeniedException();
            }

            var messages = chatRoom.Messages.Select(x => new MessageResponse
            {
                Author = new UserResponse
                {
                    Biography = x.User.Biography,
                    City = x.User.City,
                    Country = x.User.Country,
                    Email = x.User.Email,
                    FirstName = x.User.FirstName,
                    LastName = x.User.LastName,
                    PhoneNumber = x.User.PhoneNumber
                },
                MessageId = x.MessageId,
                MessageText = x.Content,
                SentDate = x.SentDate
            }).ToArray();

            return messages;
        }
        
        public async Task<MessageResponse> SendMessageAsync(SendMessageRequest messageRequest)
        {
            var user =  await _userService.GetCurrentUser();
            
            var message = new Message
            {
                Content = messageRequest.MessageText,
                User = user
            };

            var chatRoom = await _charityDbContext.ChatRooms.FirstOrDefaultAsync(x => x.ChatRoomId == messageRequest.ChatRoomId);

            if (chatRoom == null)
            {
                throw new ChatRoomNotFoundException();
            }
            
            chatRoom.Messages.Add(message);
            await _charityDbContext.SaveChangesAsync();
            
            return new MessageResponse
            {
                MessageId = message.MessageId,
                Author = new UserResponse
                {
                    Biography = user.Biography,
                    City = user.City,
                    Country = user.Country,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber
                },
                SentDate = message.SentDate,
                MessageText = message.Content
            };
        }
    }
}
