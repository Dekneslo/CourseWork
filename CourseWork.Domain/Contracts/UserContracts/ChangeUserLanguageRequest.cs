namespace CourseWork.Domain.Contracts.UserContracts
{
    public class ChangeUserLanguageRequest
    {
        public int UserId { get; set; }
        public string LanguageCode { get; set; }
    }
}
