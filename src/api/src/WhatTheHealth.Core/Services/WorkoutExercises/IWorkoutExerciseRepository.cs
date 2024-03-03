using WhatTheHealth.Domain.Entities;
using WhatTheHealth.Core.Exceptions;

namespace WhatTheHealth.Core.Services.WorkoutExercises;

public interface IWorkoutExerciseRepository
{
    /// <summary>
    /// Creates the given <see cref="WorkoutExercise"/>, returning the same item with the id field containing the id of the newly created item.
    /// </summary>
    /// <param name="workoutExercise"></param>
    /// <returns>The created <see cref="WorkoutExercise"/></returns>
    Task<WorkoutExercise> Create(WorkoutExercise workoutExercise);

    /// <summary>
    /// Retrieves all stored instances of <see cref="WorkoutExercise"/>.
    /// </summary>
    /// <returns>A list containing all <see cref="WorkoutExercise"/>s</returns>
    IEnumerable<WorkoutExercise> GetAll();

    /// <summary>
    /// Retrieves the <see cref="WorkoutExercise"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbNotFoundException">Throws <see cref="DbNotFoundException"/> if no record could be found</exception>
    Task<WorkoutExercise> GetById(Guid id);

    /// <summary>
    /// Updates the given <see cref="WorkoutExercise"/>.
    /// </summary>
    /// <param name="workoutExercise"></param>
    /// <returns>The updated <see cref="WorkoutExercise"/></returns>
    /// <exception cref="DbEditException">Throws <see cref="DbEditException"/> if the record could not be deleted</exception>
    Task<WorkoutExercise> Update(WorkoutExercise workoutExercise);

    /// <summary>
    /// Deletes the given <see cref="WorkoutExercise"/>.
    /// </summary>
    /// <param name="workoutExercise"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>

    Task Delete(WorkoutExercise workoutExercise);

    /// <summary>
    /// Deletes the <see cref="WorkoutExercise"/> with the given id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DbDeleteException">Throws <see cref="DbDeleteException"/> if no record could be deleted</exception>
    Task DeleteById(Guid id);
}
