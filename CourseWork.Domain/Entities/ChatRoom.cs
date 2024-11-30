namespace CourseWork.Domain.Entities
{
    public class ChatRoom
    {
        public ChatRoom()
        {
            ChatRoomUsers = new HashSet<ChatRoomUser>();
        }

        public int ChatRoomId { get; set; }
        
        public string RoomName { get; set; }

        public virtual ICollection<ChatRoomUser> ChatRoomUsers { get; set; }
    }
}
