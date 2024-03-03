using WhatTheHealth.Domain.Enums;

namespace WhatTheHealth.API.Dtos;

public class WorkoutExerciseDto
{
    public Guid Id { get; set; }

    public required Guid ExerciseId { get; set; }

    public ExerciseDto? Exercise { get; set; }

    public required ICollection<WorkoutSetDto> WorkoutSets { get; set; }
}
