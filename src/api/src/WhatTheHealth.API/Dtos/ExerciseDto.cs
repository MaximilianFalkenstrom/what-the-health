using WhatTheHealth.Domain.Enums;

namespace WhatTheHealth.API.Dtos;

public class ExerciseDto
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public ExerciseType ExerciseType { get; set; }
}
