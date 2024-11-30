using CourseWork.Domain.Contracts.UserContracts;

namespace CourseWork.Domain.Interfaces
{
    public interface IUserService
    {
        Task<UserResponse[]> GetAllUsersAsync();
        
        Task<UserResponse> GetUserByIdAsync(int id);  
        
        Task<UserResponse[]> GetUsersByRoleAsync(int role);
        
        Task<UserResponse> RegisterUserAsync(CreateUserRequest request);
        
        Task<UserResponse> UpdateUserAsync(int id, UpdateUserRequest request);
        
        Task<UserResponse> DeleteUserAsync(int id);
        
        Task<UserResponse> ChangeUserPasswordAsync(ChangeUserPasswordRequest request);
    }
}
