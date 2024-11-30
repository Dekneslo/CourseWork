namespace CourseWork.Domain.Contracts.CourseContracts
{
    public class AddCommentToCourseRequest
    {
        public int UserId { get; set; }
        public string CommentText { get; set; }
    }
}
