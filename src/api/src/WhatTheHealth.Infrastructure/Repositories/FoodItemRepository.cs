using Microsoft.EntityFrameworkCore;
using WhatTheHealth.Core.Exceptions;
using WhatTheHealth.Core.Services.FoodItems;
using WhatTheHealth.Domain.Entities;
using WhatTheHealth.Infrastructure.Data;

namespace WhatTheHealth.Infrastructure.Repositories;

public class FoodItemRepository : IFoodItemRepository
{
    private readonly AppDbContext _appDbContext;

    public FoodItemRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<FoodItem> Create(FoodItem foodItem)
    {
        _appDbContext.FoodItems.Add(foodItem);

        var result = await _appDbContext.SaveChangesAsync(CancellationToken.None);

        if (result == 0)
        {
            throw new DbCreateException("Unable to store FoodItem");
        }

        return foodItem;
    }

    public async Task Delete(FoodItem foodItem)
    {
        var result = await _appDbContext.FoodItems.Where(item => item.Id == foodItem.Id).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete FoodItem");
        }
    }

    public async Task DeleteById(Guid id)
    {
        var result = await _appDbContext.FoodItems.Where(foodItem => foodItem.Id == id).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete FoodItem");
        }
    }

    public IEnumerable<FoodItem> GetAll()
    {
        return  _appDbContext.FoodItems;
    }

    public async Task<FoodItem> GetById(Guid id)
    {
        var foodItem = await _appDbContext.FoodItems.FindAsync(id);

        if (foodItem == null)
        {
            throw new DbNotFoundException("Unable to find FoodItem");
        }

        return foodItem;
    }

    public async Task<FoodItem> Update(FoodItem foodItem)
    {
        _appDbContext.Update(foodItem);

        var result = await _appDbContext.SaveChangesAsync();

        if (result == 0)
        {
            throw new DbEditException("Unable to update FoodItem");
        }

        return foodItem;
    }
}
