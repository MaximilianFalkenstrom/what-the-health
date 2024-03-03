using WhatTheHealth.Domain.Enums;

namespace WhatTheHealth.API.Dtos;

public class WorkoutSetDto
{
    public Guid Id { get; set; }

    public int Sets { get; set; }

    public int Reps { get; set; }

    public double Weight { get; set; }
}
