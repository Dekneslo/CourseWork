namespace CourseWork.Application.Services;

public static class PasswordHasher
{
    public static string HashPassword(string password)
    {
        var passwordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        return passwordHash;
    }
}