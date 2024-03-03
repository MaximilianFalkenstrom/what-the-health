using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.Exercises;

public class ExerciseService(IExerciseRepository exerciseRepository) : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository = exerciseRepository;

    public async Task<Exercise> Create(Exercise exercise)
    {
        return await _exerciseRepository.Create(exercise);
    }

    public async Task<Exercise> Edit(Exercise exercise)
    {
        return await _exerciseRepository.Update(exercise);
    }

    public IEnumerable<Exercise> GetAll()
    {
        return _exerciseRepository.GetAll();
    }

    public async Task<Exercise> GetById(string id)
    {
        var guid = Guid.Parse(id);

        return await _exerciseRepository.GetById(guid);
    }

    public async Task RemoveById(string id)
    {
        var guid = Guid.Parse(id);

        await _exerciseRepository.DeleteById(guid);
    }
}
