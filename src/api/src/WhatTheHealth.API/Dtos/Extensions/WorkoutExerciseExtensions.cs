using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.API.Dtos.Extensions;

public static class WorkoutExerciseExtensions
{
    public static WorkoutExercise ToWorkoutExercise(this WorkoutExerciseDto workoutExerciseDto, string userId) => new()
    {
        Id = workoutExerciseDto.Id,
        ExerciseId = workoutExerciseDto.ExerciseId,
        Exercise = workoutExerciseDto.Exercise?.ToExercise(),
        WorkoutSets = workoutExerciseDto.WorkoutSets.Select(x => x.ToWorkoutSet()).ToList()
    };

    public static WorkoutExerciseDto ToWorkoutExerciseDto(this WorkoutExercise workoutExercise) => new()
    {
        Id = workoutExercise.Id,
        ExerciseId = workoutExercise.ExerciseId,
        Exercise = workoutExercise.Exercise?.ToExerciseDto(),
        WorkoutSets = workoutExercise.WorkoutSets.Select(x => x.ToWorkoutSetDto()).ToList()
    };
}