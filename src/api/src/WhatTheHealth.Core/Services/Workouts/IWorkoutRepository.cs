using WhatTheHealth.Domain.Entities;
using WhatTheHealth.Core.Exceptions;

namespace WhatTheHealth.Core.Services.Workouts;

public interface IWorkoutRepository
{
    /// <summary>
    /// Creates the given <see cref="Workout"/>, returning the same item with the id field containing the id of the newly created item.
    /// </summary>
    /// <param name="workout"></param>
    /// <returns>The created <see cref="Workout"/></returns>
    Task<Workout> Create(Workout workout);

    /// <summary>
    /// Retrieves all stored instances of <see cref="Workout"/>.
    /// </summary>
    /// <returns>A list containing all <see cref="Workout"/>s</returns>
    IEnumerable<Workout> GetAll();

    /// <summary>
    /// Retrieves the <see cref="Workout"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbNotFoundException">Throws <see cref="DbNotFoundException"/> if no record could be found</exception>
    Task<Workout> GetById(Guid id);

    /// <summary>
    /// Updates the given <see cref="Workout"/>.
    /// </summary>
    /// <param name="workout"></param>
    /// <returns>The updated <see cref="Workout"/></returns>
    /// <exception cref="DbEditException">Throws <see cref="DbEditException"/> if the record could not be deleted</exception>
    Task<Workout> Update(Workout workout);

    /// <summary>
    /// Deletes the given <see cref="Workout"/>.
    /// </summary>
    /// <param name="workout"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>

    Task Delete(Workout workout);

    /// <summary>
    /// Deletes the <see cref="Workout"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>
    Task DeleteById(Guid id);
}
