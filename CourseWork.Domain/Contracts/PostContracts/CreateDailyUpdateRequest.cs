namespace CourseWork.Domain.Contracts.PostContracts
{
    public class CreateDailyUpdateRequest
    {
        public string Description { get; set; }
        
        public int IdUser { get; set; }
        public DateTime DateOfPosted { get; set; }
    }
}
