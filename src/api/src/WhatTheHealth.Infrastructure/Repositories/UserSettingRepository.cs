using Microsoft.EntityFrameworkCore;
using WhatTheHealth.Core.Exceptions;
using WhatTheHealth.Core.Services.UserSettings;
using WhatTheHealth.Domain.Entities;
using WhatTheHealth.Infrastructure.Data;

namespace WhatTheHealth.Infrastructure.Repositories;

public class UserSettingRepository : IUserSettingRepository
{
    private readonly AppDbContext _appDbContext;

    public UserSettingRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<UserSetting> Create(UserSetting userSetting)
    {
        _appDbContext.UserSettings.Add(userSetting);

        var result = await _appDbContext.SaveChangesAsync(CancellationToken.None);

        if (result == 0)
        {
            throw new DbCreateException("Unable to store settings");
        }

        return userSetting;
    }

    public async Task Delete(UserSetting userSetting)
    {
        var result = await _appDbContext.UserSettings.Where(item => item.UserId == userSetting.UserId).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete settings");
        }
    }

    public async Task DeleteById(string userId)
    {
        var result = await _appDbContext.UserSettings.Where(userSetting => userSetting.UserId == userId).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete settings");
        }
    }

    public IEnumerable<UserSetting> GetAll()
    {
        return  _appDbContext.UserSettings;
    }

    public async Task<UserSetting> GetById(string userId)
    {
        var userSetting = await _appDbContext.UserSettings.Where(userSetting => userSetting.UserId == userId).Include("UserSetting").FirstOrDefaultAsync();

        if (userSetting == null)
        {
            throw new DbNotFoundException("Unable to find settings");
        }

        return userSetting;
    }

    public async Task<UserSetting> Update(UserSetting userSetting)
    {
        _appDbContext.Update(userSetting);

        var result = await _appDbContext.SaveChangesAsync();

        if (result == 0)
        {
            throw new DbEditException("Unable to update settings");
        }

        return userSetting;
    }
}
