using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.WorkoutExercises;

public interface IWorkoutExerciseService
{
    Task<WorkoutExercise> Create(WorkoutExercise workoutExercise);

    Task<WorkoutExercise> Edit(WorkoutExercise workoutExercise);

    IEnumerable<WorkoutExercise> GetAll();

    Task<WorkoutExercise> GetById(string id);

    Task RemoveById(string id);
}
