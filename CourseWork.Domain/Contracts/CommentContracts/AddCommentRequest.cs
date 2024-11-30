namespace CourseWork.Domain.Contracts.CommentContracts
{
    public class AddCommentRequest
    {
        public int UserId { get; set; }
        public int? PostId { get; set; }
        public int? CourseId { get; set; }
        public string CommentText { get; set; }
    }
}
