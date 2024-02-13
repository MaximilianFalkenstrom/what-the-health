using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WhatTheHealth.API.Authorization.Constants;
using WhatTheHealth.API.Dtos;
using WhatTheHealth.API.Dtos.Extensions;
using WhatTheHealth.Core.Services.UserSettings;

namespace WhatTheHealth.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserSettingsController : ControllerBase
{
    private readonly IUserSettingService _userSettingService;

    public UserSettingsController(IUserSettingService userSettingService)
    {
        _userSettingService = userSettingService;
    }

    [HttpPost]
    public async Task<ActionResult<UserSettingDto>> CreateAsync(UserSettingDto userSettingDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("Could not find user id"); // TODO: Actual validation

        var userSetting = userSettingDto.ToUserSetting(userId);

        var createdUserSetting = await _userSettingService.Create(userSetting);

        return createdUserSetting.ToUserSettingDto();
    }

    [HttpGet]
    public async Task<UserSettingDto> Get()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("Could not find user id"); // TODO: Actual validation

        var userSettings = await _userSettingService.GetById(userId);

        return userSettings.ToUserSettingDto();
    }


    [HttpPatch("{UserId}")]
    public async Task<ActionResult<UserSettingDto>> Update([FromRoute] string UserId, [FromBody] UserSettingDto userSettingDto)
    {

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("Could not find user id"); // TODO: Actual validation

        var userSetting = userSettingDto.ToUserSetting(userId);
        
        var updatedUserSetting = await _userSettingService.Edit(userSetting);

        return updatedUserSetting.ToUserSettingDto();
    }

    [HttpDelete("{UserId}")]
    public async Task<ActionResult> DeleteById([FromRoute] string UserId)
    {
        await _userSettingService.RemoveById(UserId);

        return Ok();
    }
}
