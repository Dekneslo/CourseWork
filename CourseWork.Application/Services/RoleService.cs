using CourseWork.Domain.Contracts.RoleContracts;
using CourseWork.Domain.Entities;
using CourseWork.Domain.Exceptions;
using CourseWork.Domain.Interfaces;
using CourseWork.Domain.Results;
using CourseWork.Persistence;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace CourseWork.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly CharityDBContext _charityDbContext;

        public RoleService(CharityDBContext charityDbContext)
        {
            _charityDbContext = charityDbContext;
        }

        public async Task<RoleResponse[]> GetAllRolesAsync()
        {
            var roles = await _charityDbContext.Roles.Select(x => new RoleResponse
            {
                IdRole = x.RoleId,
                NameRole = x.RoleName
            }).ToArrayAsync();
            return roles;
        }

        public async Task<RoleResponse> CreateRoleAsync(CreateRoleRequest request)
        {
            var role = new Role { RoleName = request.NameRole };
            await _charityDbContext.Roles.AddAsync(role);
            await _charityDbContext.SaveChangesAsync();
            return new RoleResponse
            {
                IdRole = role.RoleId,
                NameRole = role.RoleName
            };
        }

        public async Task<RoleResponse> UpdateRoleAsync(int id, UpdateRoleRequest request)
        {
            var role = await _charityDbContext.Roles.FindAsync(id);
            if (role == null)
            {
                throw new RoleNotFoundException();
            }

            role.RoleName = request.NameRole;
            await _charityDbContext.SaveChangesAsync();
            return new RoleResponse
            {
                IdRole = role.RoleId,
                NameRole = role.RoleName
            };
        }

        public async Task<RoleResponse> DeleteRoleAsync(int id)
        {
            var role = await _charityDbContext.Roles.FindAsync(id);
            if (role == null)
            {
                throw new RoleNotFoundException();
            }

            _charityDbContext.Roles.Remove(role);
            await _charityDbContext.SaveChangesAsync();
            return new RoleResponse
            {
                IdRole = role.RoleId,
                NameRole = role.RoleName
            };
        }
    }
}
