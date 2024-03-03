using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.Workouts;

public class WorkoutService(IWorkoutRepository workoutRepository) : IWorkoutService
{
    private readonly IWorkoutRepository _workoutRepository = workoutRepository;

    public async Task<Workout> Create(Workout workout)
    {
        return await _workoutRepository.Create(workout);
    }

    public async Task<Workout> Edit(Workout workout)
    {
        return await _workoutRepository.Update(workout);
    }

    public IEnumerable<Workout> GetAll()
    {
        return _workoutRepository.GetAll();
    }

    public async Task<Workout> GetById(string id)
    {
        var guid = Guid.Parse(id);

        return await _workoutRepository.GetById(guid);
    }

    public async Task RemoveById(string id)
    {
        var guid = Guid.Parse(id);

        await _workoutRepository.DeleteById(guid);
    }
}
