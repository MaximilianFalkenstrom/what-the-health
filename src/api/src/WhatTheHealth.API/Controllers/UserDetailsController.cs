using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WhatTheHealth.API.Authorization.Constants;
using WhatTheHealth.API.Dtos;
using WhatTheHealth.API.Dtos.Extensions;
using WhatTheHealth.Core.Services.UserDetails;
using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserDetailsController : ControllerBase
{
    private readonly IUserDetailsService _userSettingDetails;

    public UserDetailsController(IUserDetailsService userSettingDetails)
    {
        _userSettingDetails = userSettingDetails;
    }

    [HttpPost]
    public async Task<ActionResult<UserDetailsDto>> CreateAsync(UserDetailsDto userDetailsDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("Could not find user id"); // TODO: Actual validation

        var userDetails = userDetailsDto.ToUserDetails(userId);

        var createdUserDetails = await _userSettingDetails.Create(userDetails);

        return createdUserDetails.ToUserDetailsDto();
    }

    [HttpGet]
    public async Task<UserDetailsDto> Get()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("Could not find user id"); // TODO: Actual validation

        var userDetails = await _userSettingDetails.GetById(userId);

        return userDetails.ToUserDetailsDto();
    }


    [HttpPatch]
    public async Task<ActionResult<UserDetailsDto>> Update([FromBody] UserDetailsDto userDetailsDto)
    {

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("Could not find user id"); // TODO: Actual validation

        var userDetails = userDetailsDto.ToUserDetails(userId);
        
        var updatedUserDetails = await _userSettingDetails.Edit(userDetails);

        return updatedUserDetails.ToUserDetailsDto();
    }

    [HttpDelete("{UserId}")]
    public async Task<ActionResult> DeleteById([FromRoute] string UserId)
    {
        await _userSettingDetails.RemoveById(UserId);

        return Ok();
    }
}
