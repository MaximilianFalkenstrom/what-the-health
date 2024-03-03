using WhatTheHealth.Domain.Enums;

namespace WhatTheHealth.Domain.Entities;

public class Exercise
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public ExerciseType ExerciseType { get; set; }
}
