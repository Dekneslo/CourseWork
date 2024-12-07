using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CourseWork.Domain.Contracts.AuthContracts;
using CourseWork.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CourseWork.Application.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly TimeProvider _timeProvider;

    public TokenService(IConfiguration configuration, TimeProvider timeProvider)
    {
        _configuration = configuration;
        _timeProvider = timeProvider;
    }
    
    public string GenerateToken(User user)
    {
        var claims = new List<Claim>();
        
        claims.Add(new Claim(ClaimTypes.Sid, user.UserId.ToString()));

        var issuer = _configuration.GetSection("AuthOptions:Issuer").Value;
        var audience = _configuration.GetSection("AuthOptions:Audience").Value;
        var accessTokenValidityInDays = Convert.ToInt32(_configuration.GetSection("AuthOptions:AccessTokenValidityInDays").Value);
        var accessTokenValidityDateTime = _timeProvider.GetUtcNow().AddDays(accessTokenValidityInDays).DateTime;
        var key = _configuration.GetSection("AuthOptions:Key").Value;
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!));
            
        var jwt = new JwtSecurityToken(issuer,
            audience,
            claims,
            expires: accessTokenValidityDateTime,
            signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256));

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt;
    }
   
}

public interface ITokenService
{
    public string GenerateToken(User user);
}