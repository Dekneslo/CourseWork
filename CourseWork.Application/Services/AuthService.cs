using CourseWork.Domain.Contracts.AuthContracts;
using CourseWork.Domain.Entities;
using CourseWork.Domain.Exceptions;
using CourseWork.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Application.Services;

public class AuthService : IAuthService
{
    private readonly ITokenService _tokenService;
    private readonly CharityDBContext _charityDbContext;

    public AuthService(ITokenService tokenService, CharityDBContext charityDbContext)
    {
        _tokenService = tokenService;
        _charityDbContext = charityDbContext;
    }
    
     public async Task<string> Login(LoginRequest loginRequest)
     {
        var authorizedUser = await VerifyLoginCredentials(loginRequest.PhoneNumber, loginRequest.Password);
        if (authorizedUser is null)
        {
            throw new InvalidLoginCredentialsException();
        }

        var tokenDto = _tokenService.GenerateToken(authorizedUser);
        return tokenDto;
     }

    public async Task<string> Register(RegisterRequest registerUserRequest)
    {
        if (string.IsNullOrWhiteSpace(registerUserRequest.PhoneNumber) || string.IsNullOrWhiteSpace(registerUserRequest.Password))
        {
            throw new InvalidRegistrationDataException();
        }
        
        if (await CheckUserExists(registerUserRequest.PhoneNumber))
        {
            throw new PhoneNumberAlreadyExistsException();
        }
        
        if (long.TryParse(registerUserRequest.PhoneNumber, out long test) == false)
        {
            throw new InvalidDataFormatException();
        }
        
        var passwordHash = PasswordHasher.HashPassword(registerUserRequest.Password);
        var userToAdd = new User
        {
            PhoneNumber = registerUserRequest.PhoneNumber,
            Email = registerUserRequest.Email,
            FirstName = registerUserRequest.FirstName,
            LastName = registerUserRequest.LastName,
            PasswordHash = passwordHash
        };

        await _charityDbContext.Users.AddAsync(userToAdd);
        await _charityDbContext.SaveChangesAsync();
        var tokenDto = _tokenService.GenerateToken(userToAdd);
        return tokenDto;
    }

    public async Task<bool> CheckUserExists(string phoneNumber)
    {
        var isUserExists = await _charityDbContext.Users.AsNoTracking().AnyAsync(x => x.PhoneNumber == phoneNumber);
        return isUserExists;
    }
    
    public async Task<User?> VerifyLoginCredentials(string phoneNumber, string password)
    {
        var user = await _charityDbContext.Users.AsNoTracking().FirstOrDefaultAsync(x =>
            x.PhoneNumber == phoneNumber);
        if (user is null)
        {
            throw new InvalidLoginCredentialsException();
        }
            
        var passwordMatch = BCrypt.Net.BCrypt.EnhancedVerify(password, user?.PasswordHash);
        return passwordMatch ? user : null;
    }

}

public interface IAuthService
{
    Task<string> Login(LoginRequest loginRequestDto);
    
    Task<string> Register(RegisterRequest registerUser);
    
    Task<bool> CheckUserExists(string phoneNumber);
    
    Task<User?> VerifyLoginCredentials(string phoneNumber, string password);

}