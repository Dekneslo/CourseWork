namespace CourseWork.Domain.Entities
{
    public class CommentFile
    {
        public int FileId { get; set; }

        public int CommentId { get; set; }

        public virtual Comment Comment { get; set; }

        public virtual File File { get; set; }
    }
}
