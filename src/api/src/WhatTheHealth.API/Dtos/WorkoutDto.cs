using WhatTheHealth.Domain.Enums;

namespace WhatTheHealth.API.Dtos;

public class WorkoutDto
{
    public Guid Id { get; set; }

    public string UserId { get; set; } = "";

    public required string Name { get; set; }

    public ICollection<WorkoutExerciseDto> Exercises { get; set; } = [];
}
