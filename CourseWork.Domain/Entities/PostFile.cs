namespace CourseWork.Domain.Entities
{
    public class PostFile
    {
        public int PostId { get; set; }
        
        public int FileId { get; set; }

        public virtual File File { get; set; } = null!;
        
        public virtual Post Post { get; set; } = null!;
    }
}
