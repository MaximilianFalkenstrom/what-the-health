namespace WhatTheHealth.Domain.Entities;

public class WorkoutExercise
{
    public Guid Id { get; set; }

    public required Guid ExerciseId { get; set; }

    public Exercise? Exercise { get; set; }

    public required ICollection<WorkoutSet> WorkoutSets { get; set; }
}
