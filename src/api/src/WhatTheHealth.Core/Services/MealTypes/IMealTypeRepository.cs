using WhatTheHealth.Domain.Entities;
using WhatTheHealth.Core.Exceptions;

namespace WhatTheHealth.Core.Services.MealTypes;

public interface IMealTypeRepository
{
    /// <summary>
    /// Creates the given <see cref="MealType"/>, returning the same item with the id field containing the id of the newly created item.
    /// </summary>
    /// <param name="MealType"></param>
    /// <returns>The created <see cref="MealType"/></returns>
    Task<MealType> Create(MealType MealType);

    /// <summary>
    /// Retrieves the <see cref="MealType"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbNotFoundException">Throws <see cref="DbNotFoundException"/> if no record could be found</exception>
    Task<MealType> GetById(Guid id);

    /// <summary>
    /// Retrieves all stored instances of <see cref="MealType"/>.
    /// </summary>
    /// <returns>A list containing all <see cref="MealType"/>s</returns>
    IEnumerable<MealType> GetAll();

    /// <summary>
    /// Updates the given <see cref="MealType"/>.
    /// </summary>
    /// <param name="MealType"></param>
    /// <returns>The updated <see cref="MealType"/></returns>
    /// <exception cref="DbEditException">Throws <see cref="DbEditException"/> if the record could not be deleted</exception>
    Task<MealType> Update(MealType MealType);

    /// <summary>
    /// Deletes the given <see cref="MealType"/>.
    /// </summary>
    /// <param name="MealType"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>

    Task Delete(MealType MealType);

    /// <summary>
    /// Deletes the <see cref="MealType"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>
    Task DeleteById(Guid id);
}
