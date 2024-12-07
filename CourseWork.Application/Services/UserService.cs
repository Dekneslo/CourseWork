using System.Security.Claims;
using CourseWork.Domain.Entities;
using CourseWork.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Application.Services;

public class UserService(IHttpContextAccessor httpContextAccessor, CharityDBContext appDbContext) : IUserService
{
    public async Task<User> GetCurrentUser()
    {
        var currentUserIdString =
            httpContextAccessor.HttpContext!.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Sid)!.Value;
        var currentUserIdLong = Convert.ToInt64(currentUserIdString);
        var currentUser = await appDbContext.Users.Include(x => x.ChatRooms)
            .FirstAsync(x => x.UserId == currentUserIdLong);
        return currentUser;
    }

}

public interface IUserService
{
    Task<User> GetCurrentUser();
}