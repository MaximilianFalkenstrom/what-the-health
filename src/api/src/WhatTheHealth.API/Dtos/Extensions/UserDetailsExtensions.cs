using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.API.Dtos.Extensions;

public static class UserDetailsExtension
{
    public static UserDetails ToUserDetails(this UserDetailsDto userDetailsDto, string userId)
    {
        return new UserDetails
        {
            UserId = userId,
            Name = userDetailsDto.Name,
            Birthday = userDetailsDto.Birthday,
            Height = userDetailsDto.Height,
            Weight = userDetailsDto.Weight,
            Calories = userDetailsDto.Calories,
        };
    }

    public static UserDetailsDto ToUserDetailsDto(this UserDetails userDetails)
    {
        return new UserDetailsDto
        {
            Name = userDetails.Name,
            Calories = userDetails.Calories,
            Birthday = userDetails.Birthday,
            Height = userDetails.Height,
            Weight = userDetails.Weight
        };
    }
}
