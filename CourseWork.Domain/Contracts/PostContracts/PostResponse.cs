namespace CourseWork.Domain.Contracts.PostContracts
{
    public class PostResponse
    {
        public int IdPost { get; set; }
        
        public string PostTitle { get; set; }
        
        public string PostContent { get; set; }
        
        public DateTime DatePosted { get; set; }
    }
}
