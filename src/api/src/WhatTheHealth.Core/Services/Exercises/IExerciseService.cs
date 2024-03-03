using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.Exercises;

public interface IExerciseService
{
    Task<Exercise> Create(Exercise exercise);

    Task<Exercise> Edit(Exercise exercise);

    IEnumerable<Exercise> GetAll();

    Task<Exercise> GetById(string id);

    Task RemoveById(string id);
}
