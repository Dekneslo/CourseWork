namespace CourseWork.Domain.Entities
{
    public class Post
    {
        public int PostId { get; set; }
        
        public string Title { get; set; }
        
        public string Content { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.UtcNow;
        
        public User User { get; set; }
    }

    public enum PostType
    {
        Post = 0,
        DailyUpdate = 1
    }
}
