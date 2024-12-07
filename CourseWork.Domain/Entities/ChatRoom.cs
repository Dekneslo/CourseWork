namespace CourseWork.Domain.Entities
{
    public class ChatRoom
    {
        public int ChatRoomId { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
        
        public ChatRoomType ChatRoomType { get; set; }

        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
    }

    public enum ChatRoomType
    {
        Dialogue = 0,
        Conversation = 1
    }
}
