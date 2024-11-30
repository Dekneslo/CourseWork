namespace CourseWork.Domain.Entities
{
    public class Comment
    {
        public Comment()
        {
            CommentFiles = new HashSet<CommentFile>();
        }

        public int CommentId { get; set; }
        public int UserId { get; set; }
        
        public int? PostId { get; set; }
        public int? CourseId { get; set; }
        public string CommentDescription { get; set; } = null!;
        public DateTime DateCommented { get; set; }

        public virtual Course? Course { get; set; }
        
        public virtual Post? Post { get; set; }
        
        public virtual User User { get; set; } = null!;
        public virtual ICollection<CommentFile> CommentFiles { get; set; }
    }
}
