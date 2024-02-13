using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.API.Dtos.Extensions;

public static class UserSettingExtension
{
    public static UserSetting ToUserSetting(this UserSettingDto userSettingDto, string userId)
    {
        return new UserSetting
        {
            UserId = userId,
            Name = userSettingDto.Name,
            Birthday = userSettingDto.Birthday,
            Height = userSettingDto.Height,
            Weight = userSettingDto.Weight,
            Calories = userSettingDto.Calories,
        };
    }

    public static UserSettingDto ToUserSettingDto(this UserSetting userSetting)
    {
        return new UserSettingDto
        {
            Name = userSetting.Name,
            Calories = userSetting.Calories,
            Birthday = userSetting.Birthday,
            Height = userSetting.Height,
            Weight = userSetting.Weight
        };
    }
}
