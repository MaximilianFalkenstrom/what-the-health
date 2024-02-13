using Microsoft.EntityFrameworkCore;
using WhatTheHealth.Core.Exceptions;
using WhatTheHealth.Core.Services.UserDetails;
using WhatTheHealth.Domain.Entities;
using WhatTheHealth.Infrastructure.Data;

namespace WhatTheHealth.Infrastructure.Repositories;

public class UserDetailsRepository : IUserDetailsRepository
{
    private readonly AppDbContext _appDbContext;

    public UserDetailsRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<UserDetails> Create(UserDetails userDetails)
    {
        _appDbContext.UserDetails.Add(userDetails);

        var result = await _appDbContext.SaveChangesAsync(CancellationToken.None);

        if (result == 0)
        {
            throw new DbCreateException("Unable to store settings");
        }

        return userDetails;
    }

    public async Task Delete(UserDetails userDetails)
    {
        var result = await _appDbContext.UserDetails.Where(item => item.UserId == userDetails.UserId).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete settings");
        }
    }

    public async Task DeleteById(string userId)
    {
        var result = await _appDbContext.UserDetails.Where(UserDetails => UserDetails.UserId == userId).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete settings");
        }
    }

    public IEnumerable<UserDetails> GetAll()
    {
        return  _appDbContext.UserDetails;
    }

    public async Task<UserDetails> GetById(string userId)
    {
        var userDetails = await _appDbContext.UserDetails.Where(userDetails => userDetails.UserId == userId).FirstOrDefaultAsync();

        if (userDetails == null)
        {
            throw new DbNotFoundException("Unable to find settings");
        }

        return userDetails;
    }

    public async Task<UserDetails> Update(UserDetails userDetails)
    {
        _appDbContext.Update(userDetails);

        var result = await _appDbContext.SaveChangesAsync();

        if (result == 0)
        {
            throw new DbEditException("Unable to update settings");
        }

        return userDetails;
    }
}
