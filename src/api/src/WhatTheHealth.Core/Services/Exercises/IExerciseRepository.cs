using WhatTheHealth.Domain.Entities;
using WhatTheHealth.Core.Exceptions;

namespace WhatTheHealth.Core.Services.Exercises;

public interface IExerciseRepository
{
    /// <summary>
    /// Creates the given <see cref="Exercise"/>, returning the same item with the id field containing the id of the newly created item.
    /// </summary>
    /// <param name="exercise"></param>
    /// <returns>The created <see cref="Exercise"/></returns>
    Task<Exercise> Create(Exercise exercise);

    /// <summary>
    /// Retrieves all stored instances of <see cref="Exercise"/>.
    /// </summary>
    /// <returns>A list containing all <see cref="Exercise"/>s</returns>
    IEnumerable<Exercise> GetAll();

    /// <summary>
    /// Retrieves the <see cref="Exercise"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbNotFoundException">Throws <see cref="DbNotFoundException"/> if no record could be found</exception>
    Task<Exercise> GetById(Guid id);

    /// <summary>
    /// Updates the given <see cref="Exercise"/>.
    /// </summary>
    /// <param name="exercise"></param>
    /// <returns>The updated <see cref="Exercise"/></returns>
    /// <exception cref="DbEditException">Throws <see cref="DbEditException"/> if the record could not be deleted</exception>
    Task<Exercise> Update(Exercise exercise);

    /// <summary>
    /// Deletes the given <see cref="Exercise"/>.
    /// </summary>
    /// <param name="exercise"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>

    Task Delete(Exercise exercise);

    /// <summary>
    /// Deletes the <see cref="Exercise"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>
    Task DeleteById(Guid id);
}
