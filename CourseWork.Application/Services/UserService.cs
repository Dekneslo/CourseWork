using CourseWork.Domain.Contracts.UserContracts;
using CourseWork.Domain.Entities;
using CourseWork.Domain.Results;
using CourseWork.Domain.Exceptions;
using CourseWork.Domain.Interfaces;
using CourseWork.Persistence;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Application.Services
{
    public class UserService : IUserService
    {
        private readonly CharityDBContext _charityDbContext;

        public UserService(CharityDBContext charityDbContext)
        {
            _charityDbContext = charityDbContext;
        }

        public async Task<UserResponse[]> GetAllUsersAsync()
        {
            var users = await _charityDbContext.Users.Select(x => new UserResponse
            {
                Email = x.Email,
                FirstName = x.FirstName,
                IdUser = x.UserId,
                LastName = x.LastName,
                Role = x.RoleId,
                Biography = x.Biography,
                PhoneNumber = x.PhoneNumber,
                City = x.City,
                Country = x.Country
            }).ToArrayAsync();
            return users;
        }

        public async Task<UserResponse> GetUserByIdAsync(int id)
        {
            var user = await _charityDbContext.Users.FindAsync(id);
            
            if (user == null)
                throw new UserNotFoundException();

            return new UserResponse
            {
                Email = user.Email,
                FirstName = user.FirstName,
                IdUser = user.UserId,
                LastName = user.LastName,
                Role = user.RoleId,
                Biography = user.Biography,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                Country = user.Country
            };
        }

        public async Task<UserResponse[]> GetUsersByRoleAsync(int role)
        {
            var users = await _charityDbContext.Users.Where(x => x.RoleId == role).Select(x => new UserResponse
            {
                Email = x.Email,
                FirstName = x.FirstName,
                IdUser = x.UserId,
                LastName = x.LastName,
                Role = x.RoleId,
                Biography = x.Biography,
                PhoneNumber = x.PhoneNumber,
                City = x.City,
                Country = x.Country
            }).ToArrayAsync();
            return users;
        }

        public async Task<UserResponse> RegisterUserAsync(CreateUserRequest request)
        {
            if (await _charityDbContext.Users.FirstOrDefaultAsync(x => x.Email == request.Email) != null)
            {
                throw new UserWithThisEmailAlreadyExistsException();
            }

            var user = new User
            {
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                RoleId = request.Role
            };
            await _charityDbContext.Users.AddAsync(user);
            await _charityDbContext.SaveChangesAsync();
            
            return new UserResponse
            {
                Email = user.Email,
                FirstName = user.FirstName,
                IdUser = user.UserId,
                LastName = user.LastName,
                Role = user.RoleId,
                Biography = user.Biography,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                Country = user.Country
            };
        }
        
        public async Task<UserResponse> UpdateUserAsync(int id, UpdateUserRequest request)
        {
            var user = await _charityDbContext.Users.FindAsync(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            user.Email = request.Email;
            user.LastName = request.LastName;
            user.FirstName = request.FirstName;
            user.RoleId = request.Role;
            await _charityDbContext.SaveChangesAsync();

            return new UserResponse
            {
                Email = user.Email,
                FirstName = user.FirstName,
                IdUser = user.UserId,
                LastName = user.LastName,
                Role = user.RoleId,
                Biography = user.Biography,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                Country = user.Country
            };
        }

        public async Task<UserResponse> DeleteUserAsync(int id)
        {
            var user = await _charityDbContext.Users.FindAsync(id);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            _charityDbContext.Users.Remove(user);
            await _charityDbContext.SaveChangesAsync();
            
            return new UserResponse
            {
                Email = user.Email,
                FirstName = user.FirstName,
                IdUser = user.UserId,
                LastName = user.LastName,
                Role = user.RoleId,
                Biography = user.Biography,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                Country = user.Country
            };
        }

        public async Task<UserResponse> ChangeUserPasswordAsync(ChangeUserPasswordRequest request)
        {
            var user = await _charityDbContext.Users.FindAsync(request.IdUser);
            if (user == null)
            {
                throw new UserNotFoundException();
            }

            if (user.Password != request.OldPassword)
            {
                throw new OldPasswordDoesNotMatchException();
            }

            user.Password = request.NewPassword;
            await _charityDbContext.SaveChangesAsync();

            return new UserResponse
            {
                Email = user.Email,
                FirstName = user.FirstName,
                IdUser = user.UserId,
                LastName = user.LastName,
                Role = user.RoleId,
                Biography = user.Biography,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                Country = user.Country
            };
        }

     

    }
}
