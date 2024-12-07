namespace CourseWork.Domain.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        
        public DateTime SentDate { get; set; } = DateTime.UtcNow;
        
        public string Content { get; set; }

        public User User { get; set; }
    }
}
