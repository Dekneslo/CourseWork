using CourseWork.Domain.Contracts.UserContracts;
using CourseWork.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    public UserProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }
    
    /// <summary>
    /// Изменение языка интерфейса пользователя
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    /// 
    ///     PUT /api/UserProfile/1/language
    ///     {
    ///        "LanguageCode": "EN"
    ///     }
    /// 
    /// </remarks>
    /// <param name="userId">ID пользователя</param>
    /// <param name="request">Запрос на изменение языка</param>
    /// <returns>Результат операции</returns>
    [HttpPut("{userId}/language")]
    public ActionResult ChangeUserLanguage(int userId, [FromBody] ChangeUserLanguageRequest request)
    {
        var result = _profileService.ChangeUserLanguageAsync(userId, request.LanguageCode);
        return Ok();
    }
}