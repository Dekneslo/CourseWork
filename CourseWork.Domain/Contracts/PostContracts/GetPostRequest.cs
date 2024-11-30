namespace CourseWork.Domain.Contracts.PostContracts
{
    public class GetPostRequest
    {
        public string PostTitle { get; set; }
        
        public string PostContent { get; set; }
        
        public DateTime DatePosted { get; set; }
        
        public int IdUser { get; set; }
    }
}
