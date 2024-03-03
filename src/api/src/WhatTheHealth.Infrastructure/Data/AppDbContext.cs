using Microsoft.EntityFrameworkCore;
using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Exercise> Exercises { get; set; }

    public DbSet<FoodItem> FoodItems { get; set; }

    public DbSet<FoodEntry> FoodEntries { get; set; }

    public DbSet<MealType> MealTypes { get; set; }

    public DbSet<UserDetails> UserDetails { get; set; }

    public DbSet<Workout> Workouts { get; set; }

    public DbSet<WorkoutExercise> WorkoutExercises { get; set; }

    public DbSet<WorkoutSet> WorkoutSets { get; set; }
}
