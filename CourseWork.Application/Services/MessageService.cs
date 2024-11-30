 using CourseWork.Domain.Contracts.MessageContracts;
 using CourseWork.Domain.Contracts.PostContracts;
 using CourseWork.Domain.Entities;
using CourseWork.Domain.Interfaces;
using CourseWork.Domain.Results;
using CourseWork.Persistence;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly CharityDBContext _charityDbContext;

        public MessageService(CharityDBContext charityDbContext)
        {
            _charityDbContext = charityDbContext;
        }

        public async Task<MessageResponse[]> GetMessagesByUserAsync(int userId)
        {
            var messages = await _charityDbContext.Messages.Where(x => x.SenderId == userId).Select(x => new MessageResponse
            {
                IdMessage = x.MessageId,
                MessageText = x.MessageText,
                RecipientId = x.RecipientId,
                SenderId = x.SenderId,
                SentDate = x.SendingDatetime
            }).ToArrayAsync();
            return messages;
        }

        public async Task<MessageResponse> SendMessageAsync(SendMessageRequest messageRequest)
        {
            var message = new Message
            {
                RecipientId = messageRequest.IdRecipient,
                SenderId = messageRequest.IdSender,
                MessageText = messageRequest.MessageText
            };

            await _charityDbContext.Messages.AddAsync(message);

            return new MessageResponse
            {
                IdMessage = message.MessageId,
                MessageText = message.MessageText,
                RecipientId = message.RecipientId,
                SenderId = message.SenderId
            };
        }

        public async Task<MessageResponse[]> GetMessagesBetweenUsersAsync(int senderId, int recipientId)
        {
            var messages = await _charityDbContext.Messages
                .Where(x => x.RecipientId == recipientId && x.SenderId == senderId).Select(x => new MessageResponse
                {
                    IdMessage = x.MessageId,
                    MessageText = x.MessageText,
                    RecipientId = x.RecipientId,
                    SenderId = x.SenderId,
                    SentDate = x.SendingDatetime
                }).ToArrayAsync();

            return messages;
        }
    }
}
