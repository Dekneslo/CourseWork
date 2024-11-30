namespace CourseWork.Domain.Entities
{
    public class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
            
            LikesToPosts = new HashSet<LikeOnPost>();
            
            PostFile = new HashSet<PostFile>();
        }
        
        public int PostId { get; set; }
        
        public int UserId { get; set; }
        
        public string PostTitle { get; set; }
        
        public string PostContent { get; set; }

        public DateTime DatePosted { get; set; } = DateTime.UtcNow;
        
        public virtual User User { get; set; }
        
        public virtual ICollection<Comment> Comments { get; set; }
        
        public virtual ICollection<LikeOnPost> LikesToPosts { get; set; }
        
        public virtual ICollection<PostFile> PostFile { get; set; }
    }
}
