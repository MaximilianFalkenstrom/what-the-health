using Microsoft.EntityFrameworkCore;
using WhatTheHealth.Core.Exceptions;
using WhatTheHealth.Core.Services.MealTypes;
using WhatTheHealth.Domain.Entities;
using WhatTheHealth.Infrastructure.Data;

namespace WhatTheHealth.Infrastructure.Repositories;

public class MealTypeRepository : IMealTypeRepository
{
    private readonly AppDbContext _appDbContext;

    public MealTypeRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<MealType> Create(MealType mealType)
    {
        _appDbContext.MealType.Add(mealType);

        var result = await _appDbContext.SaveChangesAsync(CancellationToken.None);

        if (result == 0)
        {
            throw new DbCreateException("Unable to store settings");
        }

        return mealType;
    }

    public async Task Delete(MealType mealType)
    {
        var result = await _appDbContext.MealType.Where(item => item.Id == mealType.Id).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete settings");
        }
    }

    public async Task DeleteById(Guid Id)
    {
        var result = await _appDbContext.MealType.Where(mealType => mealType.Id == Id).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete settings");
        }
    }

    public IEnumerable<MealType> GetAll()
    {
        return  _appDbContext.MealType;
    }

    public async Task<MealType> GetById(Guid Id)
    {
        var mealType = await _appDbContext.MealType.Where(mealType => mealType.Id == Id).FirstOrDefaultAsync();

        if (mealType == null)
        {
            throw new DbNotFoundException("Unable to find settings");
        }

        return mealType;
    }

    public async Task<MealType> Update(MealType mealType)
    {
        _appDbContext.Update(mealType);

        var result = await _appDbContext.SaveChangesAsync();

        if (result == 0)
        {
            throw new DbEditException("Unable to update settings");
        }

        return mealType;
    }
}
