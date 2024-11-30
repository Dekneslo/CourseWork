using CourseWork.Domain.Contracts.RoleContracts;

namespace CourseWork.Domain.Interfaces
{
    public interface IRoleService
    {
        Task<RoleResponse[]> GetAllRolesAsync();
        
        Task<RoleResponse> CreateRoleAsync(CreateRoleRequest request);
        
        Task<RoleResponse> UpdateRoleAsync(int id, UpdateRoleRequest request);
        
        Task<RoleResponse> DeleteRoleAsync(int id);
    }
}
