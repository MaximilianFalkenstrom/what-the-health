using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.API.Dtos.Extensions;

public static class ExerciseExtensions
{
    public static Exercise ToExercise(this ExerciseDto exerciseDto) => new()
    {
        Id = exerciseDto.Id,
        Name = exerciseDto.Name,
        ExerciseType = exerciseDto.ExerciseType,
    };

    public static ExerciseDto ToExerciseDto(this Exercise exercise) => new()
    {
        Id = exercise.Id,
        Name = exercise.Name,
        ExerciseType = exercise.ExerciseType,
    };
}
