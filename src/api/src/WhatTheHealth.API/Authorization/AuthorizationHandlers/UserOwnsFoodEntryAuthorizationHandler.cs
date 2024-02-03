using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using WhatTheHealth.API.Authorization.Requirements;
using WhatTheHealth.Core.Services.FoodEntries;

namespace WhatTheHealth.API.Authorization.AuthorizationHandlers;

public class UserOwnsFoodEntryAuthorizationHandler : AuthorizationHandler<UserOwnsFoodEntryRequirement>
{
    private readonly IFoodEntryService _foodEntryService;

    public UserOwnsFoodEntryAuthorizationHandler(IFoodEntryService foodEntryService)
    {
        _foodEntryService = foodEntryService;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, UserOwnsFoodEntryRequirement requirement)
    {
        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null)
        {
            return;
        }

        if (context.Resource is not HttpContext httpContext)
        {
            return;
        }

        var foodEntryId = httpContext.Request.RouteValues.TryGetValue("foodEntryId", out var foodEntryIdValue)
            ? (string?)foodEntryIdValue
            : null;

        if (string.IsNullOrWhiteSpace(foodEntryId))
        {
            return;
        }

        var foodEntry = await _foodEntryService.GetById(foodEntryId);

        if (foodEntry == null)
        {
            return;
        }

        if (foodEntry.UserId == userId)
        {
            context.Succeed(requirement);
        }
    }
}
