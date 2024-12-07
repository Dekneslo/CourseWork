namespace CourseWork.Domain.Contracts.AuthContracts;

public class LoginRequest
{
    public required string PhoneNumber { get; set; }
    
    public required string Password { get; set; }
}