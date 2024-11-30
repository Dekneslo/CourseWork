namespace CourseWork.Domain.Entities
{
    public class ChatRoomUser
    {
        public int ChatRoomId { get; set; }
        
        public int UserId { get; set; }

        public virtual ChatRoom ChatRoom { get; set; }
        
        public virtual User User { get; set; }
    }
}
