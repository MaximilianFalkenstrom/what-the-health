namespace WhatTheHealth.Domain.Entities;

public class Workout
{
    public Guid Id { get; set; }

    public required string UserId { get; set; }

    public required string Name { get; set; }

    public ICollection<WorkoutExercise> Exercises { get; set; } = [];
}
