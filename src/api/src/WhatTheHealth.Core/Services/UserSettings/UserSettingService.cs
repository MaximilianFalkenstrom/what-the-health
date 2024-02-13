using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.UserSettings;

public class UserSettingService : IUserSettingService
{
    private readonly IUserSettingRepository _userSettingRepository;

    public UserSettingService(IUserSettingRepository userSettingRepository)
    {
        _userSettingRepository = userSettingRepository;
    }

    public async Task<UserSetting> Create(UserSetting userSetting)
    {
        return await _userSettingRepository.Create(userSetting);
    }

    public async Task<UserSetting> Edit(UserSetting userSetting)
    {
        return await _userSettingRepository.Update(userSetting);
    }

    public IEnumerable<UserSetting> GetAll() 
    {
        var userSettings = _userSettingRepository.GetAll();

        return userSettings;
    }

    public async Task<UserSetting> GetById(string id)
    {
        var guid = Guid.Parse(id);

        return await _userSettingRepository.GetById(id);
    }

    public async Task RemoveById(string id)
    {
        var guid = Guid.Parse(id);

        await _userSettingRepository.DeleteById(id);
    }
}
