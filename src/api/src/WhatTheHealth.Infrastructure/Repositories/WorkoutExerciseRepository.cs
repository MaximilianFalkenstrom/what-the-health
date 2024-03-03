using Microsoft.EntityFrameworkCore;
using WhatTheHealth.Core.Exceptions;
using WhatTheHealth.Core.Services.WorkoutExercises;
using WhatTheHealth.Domain.Entities;
using WhatTheHealth.Infrastructure.Data;

namespace WhatTheHealth.Infrastructure.Repositories;

public class WorkoutExerciseRepository(AppDbContext appDbContext) : IWorkoutExerciseRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<WorkoutExercise> Create(WorkoutExercise workoutExercise)
    {
        _appDbContext.WorkoutExercises.Add(workoutExercise);

        var result = await _appDbContext.SaveChangesAsync(CancellationToken.None);

        if (result == 0)
        {
            throw new DbCreateException("Unable to store workout exercise");
        }

        return workoutExercise;
    }

    public async Task Delete(WorkoutExercise workoutExercise)
    {
        var result = await _appDbContext.WorkoutExercises.Where(item => item.Id == workoutExercise.Id).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete workout exercise");
        }
    }

    public async Task DeleteById(Guid id)
    {
        var result = await _appDbContext.WorkoutExercises.Where(workoutExercise => workoutExercise.Id == id).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete workout exercise");
        }
    }

    public IEnumerable<WorkoutExercise> GetAll()
    {
        return _appDbContext.WorkoutExercises;
    }

    public async Task<WorkoutExercise> GetById(Guid id)
    {
        var workoutExercise = await _appDbContext.WorkoutExercises.Where(workoutExercise => workoutExercise.Id == id).FirstOrDefaultAsync();

        if (workoutExercise == null)
        {
            throw new DbNotFoundException("Unable to find workout exercise");
        }

        return workoutExercise;
    }

    public async Task<WorkoutExercise> Update(WorkoutExercise workoutExercise)
    {
        _appDbContext.Update(workoutExercise);

        var result = await _appDbContext.SaveChangesAsync();

        if (result == 0)
        {
            throw new DbEditException("Unable to update workout exercise");
        }

        return workoutExercise;
    }
}
