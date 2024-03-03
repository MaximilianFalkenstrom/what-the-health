using Microsoft.EntityFrameworkCore;
using WhatTheHealth.Core.Exceptions;
using WhatTheHealth.Core.Services.Exercises;
using WhatTheHealth.Domain.Entities;
using WhatTheHealth.Infrastructure.Data;

namespace WhatTheHealth.Infrastructure.Repositories;

public class ExerciseRepository(AppDbContext appDbContext) : IExerciseRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<Exercise> Create(Exercise exercise)
    {
        _appDbContext.Exercises.Add(exercise);

        var result = await _appDbContext.SaveChangesAsync(CancellationToken.None);

        if (result == 0)
        {
            throw new DbCreateException("Unable to store exercise");
        }

        return exercise;
    }

    public async Task Delete(Exercise exercise)
    {
        var result = await _appDbContext.Exercises.Where(item => item.Id == exercise.Id).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete exercise");
        }
    }

    public async Task DeleteById(Guid id)
    {
        var result = await _appDbContext.Exercises.Where(exercise => exercise.Id == id).ExecuteDeleteAsync();

        if (result == 0)
        {
            throw new DbDeleteException("Unable to delete exercise");
        }
    }

    public IEnumerable<Exercise> GetAll()
    {
        return _appDbContext.Exercises;
    }

    public async Task<Exercise> GetById(Guid id)
    {
        var exercise = await _appDbContext.Exercises.Where(exercise => exercise.Id == id).FirstOrDefaultAsync();

        if (exercise == null)
        {
            throw new DbNotFoundException("Unable to find exercise");
        }

        return exercise;
    }

    public async Task<Exercise> Update(Exercise exercise)
    {
        _appDbContext.Update(exercise);

        var result = await _appDbContext.SaveChangesAsync();

        if (result == 0)
        {
            throw new DbEditException("Unable to update exercise");
        }

        return exercise;
    }
}
