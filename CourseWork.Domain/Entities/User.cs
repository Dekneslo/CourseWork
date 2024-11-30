namespace CourseWork.Domain.Entities
{
    public class User
    {
        public User()
        {
            UsersCourses = new HashSet<UsersCourse>();
            Comments = new HashSet<Comment>();
            ChatRoomUsers = new HashSet<ChatRoomUser>();
            DailyUpdates = new HashSet<DailyUpdate>();
            FileAccesses = new HashSet<FileAccess>();
            Files = new HashSet<File>();

            MessageAsSender = new HashSet<Message>();
            
            MessagesAsRecipient = new HashSet<Message>();
            
            Posts = new HashSet<Post>();
            
            UserLanguages = new HashSet<UserLanguage>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        
        public string? City { get; set; }
        
        public string? Country { get; set; }
        
        public string PhoneNumber { get; set; }
        
        public string? Biography { get; set; }

        public virtual Role Role { get; set; }
        
        public virtual ICollection<UsersCourse> UsersCourses { get; set; }
        
        public virtual ICollection<Comment> Comments { get; set; }
        
        public virtual ICollection<DailyUpdate> DailyUpdates { get; set; }
        
        public virtual ICollection<FileAccess> FileAccesses { get; set; }
        
        public virtual ICollection<File> Files { get; set; }
        
        
        public virtual ICollection<LikeOnPost> LikesOnPosts { get; set; }
        
        public virtual ICollection<LikeOnCourse> LikesOnCourses { get; set; }
        
        public virtual ICollection<Message> MessagesAsRecipient { get; set; }
        
        public virtual ICollection<Message> MessageAsSender { get; set; }
        
        public virtual ICollection<Post> Posts { get; set; }
        
        public virtual ICollection<UserLanguage> UserLanguages { get; set; }
        
        public virtual ICollection<ChatRoomUser> ChatRoomUsers { get; set; }
    }
}
