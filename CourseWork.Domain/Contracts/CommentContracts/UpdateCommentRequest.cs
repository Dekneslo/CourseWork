namespace CourseWork.Domain.Contracts.CommentContracts
{
    public class UpdateCommentRequest
    {
        public string CommentText { get; set; }
        public DateTime DateUpdated { get; set; } = DateTime.Now;
    }
}
