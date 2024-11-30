using CourseWork.Domain.Contracts.RoleContracts;
using CourseWork.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// Получение всех ролей
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET /api/RoleId
        ///
        /// </remarks>
        /// <returns>Список всех ролей</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        /// <summary>
        /// Создание новой роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /api/RoleId
        ///     {
        ///        "Name": "Admin"
        ///     }
        ///
        /// </remarks>
        /// <param name="request">Запрос на создание новой роли</param>
        /// <returns>Созданная роль</returns>
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request)
        {
            var result = await _roleService.CreateRoleAsync(request);
            return Ok(result);
        }

        /// <summary>
        /// Обновление роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /api/RoleId/1
        ///     {
        ///        "Name": "Moderator"
        ///     }
        ///
        /// </remarks>
        /// <param name="id">ID роли</param>
        /// <param name="request">Данные для обновления роли</param>
        /// <returns>Обновленная роль</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] UpdateRoleRequest request)
        {
            var result = await _roleService.UpdateRoleAsync(id, request);
            return Ok(result);
        }

        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     DELETE /api/RoleId/1
        ///
        /// </remarks>
        /// <param name="id">ID роли</param>
        /// <returns>Результат операции</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            return Ok(result);
        }
    }

}
