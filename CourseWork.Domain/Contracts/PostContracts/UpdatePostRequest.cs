namespace CourseWork.Domain.Contracts.PostContracts
{
    public class UpdatePostRequest
    {
        public int IdPost { get; set; } 
        
        public string PostTitle { get; set; }
        
        public string PostContent { get; set; }
    }
}
