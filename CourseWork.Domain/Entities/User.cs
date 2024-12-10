using Domain.Models;

namespace CourseWork.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public string PhoneNumber { get; set; }

        public string? Biography { get; set; }
        
        public virtual ICollection<Course> EnrolledCourses { get; set; } = new List<Course>();
        
        public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();

        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        
        public virtual ICollection<ChatRoom> ChatRooms { get; set; } = new List<ChatRoom>();
    }
}
