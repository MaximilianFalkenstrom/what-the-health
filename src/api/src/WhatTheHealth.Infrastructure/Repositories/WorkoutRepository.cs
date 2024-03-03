using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using WhatTheHealth.Core.Exceptions;
using WhatTheHealth.Core.Services.Workouts;
using WhatTheHealth.Domain.Entities;
using WhatTheHealth.Infrastructure.Data;

namespace WhatTheHealth.Infrastructure.Repositories;

public class WorkoutRepository(AppDbContext appDbContext) : IWorkoutRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<Workout> Create(Workout workout)
    {
        _appDbContext.Workouts.Add(workout);

        var result = await _appDbContext.SaveChangesAsync(CancellationToken.None);

        if (result == 0)
        {
            throw new DbCreateException("Unable to store workout");
        }

        return workout;
    }

    public async Task Delete(Workout workout)
    {
        var result = await _appDbContext.Workouts.Where(item => item.Id == workout.Id).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete workout");
        }
    }

    public async Task DeleteById(Guid id)
    {
        var result = await _appDbContext.Workouts.Where(workout => workout.Id == id).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete workout");
        }
    }

    public IEnumerable<Workout> GetAll()
    {
        return _appDbContext.Workouts.Include(workout => workout.Exercises).ThenInclude(exercise => exercise.WorkoutSets);
    }

    public async Task<Workout> GetById(Guid id)
    {
        var workout = await _appDbContext.Workouts.Where(workout => workout.Id == id).Include(workout => workout.Exercises).ThenInclude(exercise => exercise.WorkoutSets).FirstOrDefaultAsync();

        if (workout == null)
        {
            throw new DbNotFoundException("Unable to find workout");
        }

        return workout;
    }

    public async Task<Workout> Update(Workout workout)
    {
        _appDbContext.Update(workout);

        var result = await _appDbContext.SaveChangesAsync();

        if (result == 0)
        {
            throw new DbEditException("Unable to update workout");
        }

        return workout;
    }
}
