namespace WhatTheHealth.Domain.Entities;

public class WorkoutSet
{
    public Guid Id { get; set; }

    public int Sets { get; set; }

    public int Reps { get; set; }

    public double Weight { get; set; }
}
