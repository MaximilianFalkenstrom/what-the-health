using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WhatTheHealth.API.Dtos;
using WhatTheHealth.API.Dtos.Extensions;
using WhatTheHealth.Core.Services.Exercises;

namespace WhatTheHealth.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    [HttpPost]
    public async Task<ActionResult<ExerciseDto>> CreateAsync(ExerciseDto exerciseDto)
    {
        var exercise = exerciseDto.ToExercise();

        var createdExercise = await _exerciseService.Create(exercise);

        return createdExercise.ToExerciseDto();
    }

    [HttpGet]
    public IEnumerable<ExerciseDto> GetAll()
    {
        var exercises = _exerciseService.GetAll();

        return exercises.Select(exercise => exercise.ToExerciseDto());
    }

    // [Authorize(Policy = Policies.UserOwnsExercise)] // Is Admin
    [HttpGet("{exerciseId}")]
    public async Task<ExerciseDto> GetById([FromRoute] string exerciseId)
    {
        var exercise = await _exerciseService.GetById(exerciseId);

        return exercise.ToExerciseDto();
    }

    // [Authorize(Policy = Policies.UserOwnsExercise)] // Is Admin
    [HttpPatch("{exerciseId}")]
    public async Task<ActionResult<ExerciseDto>> Update([FromRoute] string exerciseId, [FromBody] ExerciseDto exerciseDto)
    {
        if (exerciseId != exerciseDto.Id.ToString())
        {
            return BadRequest();
        }

        var exercise = exerciseDto.ToExercise();

        var updatedExercise = await _exerciseService.Edit(exercise);

        return updatedExercise.ToExerciseDto();
    }

    // [Authorize(Policy = Policies.UserOwnsExercise)] // Is Admin
    [HttpDelete("{exerciseId}")]
    public async Task<ActionResult> DeleteById([FromRoute] string exerciseId)
    {
        await _exerciseService.RemoveById(exerciseId);

        return Ok();
    }
}
