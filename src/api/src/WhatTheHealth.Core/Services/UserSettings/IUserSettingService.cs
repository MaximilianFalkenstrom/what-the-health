using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.UserSettings;

public interface IUserSettingService
{
    Task<UserSetting> Create(UserSetting userSettings);

    IEnumerable<UserSetting> GetAll();

    Task<UserSetting> GetById(string id);

    Task<UserSetting> Edit(UserSetting userSettings);

    Task RemoveById(string id);
}
