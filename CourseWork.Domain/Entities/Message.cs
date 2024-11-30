namespace CourseWork.Domain.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        
        public int SenderId { get; set; }
        
        public int RecipientId { get; set; }
        
        public DateTime SendingDatetime { get; set; } = DateTime.UtcNow;
        
        public string MessageText { get; set; }

        public virtual User Recipient { get; set; }
        
        public virtual User Sender { get; set; }
    }
}
