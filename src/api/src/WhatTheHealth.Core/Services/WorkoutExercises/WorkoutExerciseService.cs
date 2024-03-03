using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.WorkoutExercises;

public class WorkoutExerciseService(IWorkoutExerciseRepository workoutExerciseRepository) : IWorkoutExerciseService
{
    private readonly IWorkoutExerciseRepository _workoutExerciseRepository = workoutExerciseRepository;

    public async Task<WorkoutExercise> Create(WorkoutExercise workoutExercise)
    {
        return await _workoutExerciseRepository.Create(workoutExercise);
    }

    public async Task<WorkoutExercise> Edit(WorkoutExercise workoutExercise)
    {
        return await _workoutExerciseRepository.Update(workoutExercise);
    }

    public IEnumerable<WorkoutExercise> GetAll()
    {
        return _workoutExerciseRepository.GetAll();
    }

    public async Task<WorkoutExercise> GetById(string id)
    {
        var guid = Guid.Parse(id);

        return await _workoutExerciseRepository.GetById(guid);
    }

    public async Task RemoveById(string id)
    {
        var guid = Guid.Parse(id);

        await _workoutExerciseRepository.DeleteById(guid);
    }
}
