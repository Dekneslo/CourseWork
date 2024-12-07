using CourseWork.Application.Services;
using CourseWork.Domain.Contracts.UserContracts;
using CourseWork.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseWork.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserProfileController : ControllerBase
{
    private readonly IUserProfileService _userProfileService;

    private readonly IUserService _userService;
    public UserProfileController(IUserProfileService userProfileService, IUserService userService)
    {
        _userProfileService = userProfileService;
        _userService = userService;
    }
    
    [HttpGet("me")]
    public async Task<IActionResult> GetMe()
    {
        var currentUser = await _userProfileService.GetMe();
        return Ok(currentUser);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateUserData(ChangeUserDataRequest changeUserDataRequest)
    {
        var currentUser = await _userProfileService.ChangeUserData(changeUserDataRequest);
        return Ok(currentUser);
    }
}