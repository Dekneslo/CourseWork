namespace CourseWork.Domain.Contracts.UserContracts
{
    public class ChangeUserPasswordRequest
    {
        public int IdUser { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
