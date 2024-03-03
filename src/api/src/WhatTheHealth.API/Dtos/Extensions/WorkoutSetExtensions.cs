using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.API.Dtos.Extensions;

public static class WorkoutSetExtensions
{
    public static WorkoutSet ToWorkoutSet(this WorkoutSetDto workoutsetDto) => new()
    {
        Id = workoutsetDto.Id,
        Sets = workoutsetDto.Sets,
        Reps = workoutsetDto.Reps,
        Weight = workoutsetDto.Weight
    };

    public static WorkoutSetDto ToWorkoutSetDto(this WorkoutSet workoutset) => new()
    {
        Id = workoutset.Id,
        Sets = workoutset.Sets,
        Reps = workoutset.Reps,
        Weight = workoutset.Weight
    };
}