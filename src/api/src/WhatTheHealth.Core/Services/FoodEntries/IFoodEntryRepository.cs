using WhatTheHealth.Domain.Entities;
using WhatTheHealth.Core.Exceptions;

namespace WhatTheHealth.Core.Services.FoodEntries;

public interface IFoodEntryRepository
{
    /// <summary>
    /// Creates the given <see cref="FoodEntry"/>, returning the same item with the id field containing the id of the newly created item.
    /// </summary>
    /// <param name="foodEntry"></param>
    /// <returns>The created <see cref="FoodEntry"/></returns>
    Task<FoodEntry> Create(FoodEntry foodEntry);
    
    /// <summary>
    /// Retrieves all stored instances of <see cref="FoodEntry"/>.
    /// </summary>
    /// <returns>A list containing all <see cref="FoodEntry"/>s</returns>
    IEnumerable<FoodEntry> GetAll();

    /// <summary>
    /// Retrieves the <see cref="FoodEntry"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbNotFoundException">Throws <see cref="DbNotFoundException"/> if no record could be found</exception>
    Task<FoodEntry> GetById(Guid id);

    /// <summary>
    /// Updates the given <see cref="FoodEntry"/>.
    /// </summary>
    /// <param name="foodEntry"></param>
    /// <returns>The updated <see cref="FoodEntry"/></returns>
    /// <exception cref="DbEditException">Throws <see cref="DbEditException"/> if the record could not be deleted</exception>
    Task<FoodEntry> Update(FoodEntry foodEntry);

    /// <summary>
    /// Deletes the given <see cref="FoodEntry"/>.
    /// </summary>
    /// <param name="foodEntry"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>

    Task Delete(FoodEntry foodEntry);

    /// <summary>
    /// Deletes the <see cref="FoodEntry"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>
    Task DeleteById(Guid id);
}
