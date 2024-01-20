using WhatTheHealth.Domain.Entities;
using WhatTheHealth.Core.Exceptions;

namespace WhatTheHealth.Core.Services.FoodItems;

public interface IFoodItemRepository
{
    /// <summary>
    /// Creates the given <see cref="FoodItem"/>, returning the same item with the id field containing the id of the newly created item.
    /// </summary>
    /// <param name="foodItem"></param>
    /// <returns>The created <see cref="FoodItem"/></returns>
    Task<FoodItem> Create(FoodItem foodItem);
    
    /// <summary>
    /// Retrieves all stored instances of <see cref="FoodItem"/>.
    /// </summary>
    /// <returns>A list containing all <see cref="FoodItem"/>s</returns>
    IEnumerable<FoodItem> GetAll();

    /// <summary>
    /// Retrieves the <see cref="FoodItem"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbNotFoundException">Throws <see cref="DbNotFoundException"/> if no record could be found</exception>
    Task<FoodItem> GetById(Guid id);

    /// <summary>
    /// Updates the given <see cref="FoodItem"/>.
    /// </summary>
    /// <param name="foodItem"></param>
    /// <returns>The updated <see cref="FoodItem"/></returns>
    /// <exception cref="DbEditException">Throws <see cref="DbEditException"/> if the record could not be deleted</exception>
    Task<FoodItem> Update(FoodItem foodItem);

    /// <summary>
    /// Deletes the given <see cref="FoodItem"/>.
    /// </summary>
    /// <param name="foodItem"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>

    Task Delete(FoodItem foodItem);

    /// <summary>
    /// Deletes the <see cref="FoodItem"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>
    Task DeleteById(Guid id);
}
