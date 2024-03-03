using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.Workouts;

public interface IWorkoutService
{
    Task<Workout> Create(Workout workout);

    Task<Workout> Edit(Workout workout);

    IEnumerable<Workout> GetAll();

    Task<Workout> GetById(string id);

    Task RemoveById(string id);
}
