using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.API.Dtos.Extensions;

public static class WorkoutExtensions
{
    public static Workout ToWorkout(this WorkoutDto workoutDto, string userId) => new()
    {
        Id = workoutDto.Id,
        Name = workoutDto.Name,
        UserId = userId,
        Exercises = workoutDto.Exercises.Select(x => x.ToWorkoutExercise(userId)).ToList()
    };

    public static WorkoutDto ToWorkoutDto(this Workout workout) => new()
    {
        Id = workout.Id,
        Name = workout.Name,
        UserId = workout.UserId,
        Exercises = workout.Exercises.Select(x => x.ToWorkoutExerciseDto()).ToList()
    };
}
