using Microsoft.EntityFrameworkCore;
using WhatTheHealth.Core.Exceptions;
using WhatTheHealth.Core.Services.FoodEntries;
using WhatTheHealth.Domain.Entities;
using WhatTheHealth.Infrastructure.Data;

namespace WhatTheHealth.Infrastructure.Repositories;

public class FoodEntryRepository : IFoodEntryRepository
{
    private readonly AppDbContext _appDbContext;

    public FoodEntryRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<FoodEntry> Create(FoodEntry foodEntry)
    {
        _appDbContext.FoodEntries.Add(foodEntry);

        var result = await _appDbContext.SaveChangesAsync(CancellationToken.None);

        if (result == 0)
        {
            throw new DbCreateException("Unable to store FoodEntry");
        }

        return foodEntry;
    }

    public async Task Delete(FoodEntry foodEntry)
    {
        var result = await _appDbContext.FoodEntries.Where(item => item.Id == foodEntry.Id).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete FoodEntry");
        }
    }

    public async Task DeleteById(Guid id)
    {
        var result = await _appDbContext.FoodEntries.Where(foodEntry => foodEntry.Id == id).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete FoodEntry");
        }
    }

    public IEnumerable<FoodEntry> GetAllByDate(DateOnly date, string userId)
    {
        return _appDbContext.FoodEntries.Include(fe => fe.FoodItem).Where(foodEntry => foodEntry.UserId == userId && foodEntry.Date == date);
    }

    public async Task<FoodEntry> GetById(Guid id)
    {
        var foodEntry = await _appDbContext.FoodEntries.Where(foodEntry => foodEntry.Id == id).Include("FoodItem").FirstOrDefaultAsync();

        if (foodEntry == null)
        {
            throw new DbNotFoundException("Unable to find FoodEntry");
        }

        return foodEntry;
    }

    public async Task<FoodEntry> Update(FoodEntry foodEntry)
    {
        _appDbContext.Update(foodEntry);

        var result = await _appDbContext.SaveChangesAsync();

        if (result == 0)
        {
            throw new DbEditException("Unable to update FoodEntry");
        }

        return foodEntry;
    }
}
