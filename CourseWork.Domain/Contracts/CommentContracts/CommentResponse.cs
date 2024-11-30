namespace CourseWork.Domain.Contracts.CommentContracts
{
    public class CommentResponse
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; }
        public DateTime DateCommented { get; set; }
        public string UserName { get; set; }
    }
}
