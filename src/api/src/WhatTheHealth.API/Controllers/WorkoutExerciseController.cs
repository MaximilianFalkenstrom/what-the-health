using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WhatTheHealth.API.Dtos;
using WhatTheHealth.API.Dtos.Extensions;
using WhatTheHealth.Core.Services.WorkoutExercises;

namespace WhatTheHealth.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class WorkoutExerciseController : ControllerBase
{
    private readonly IWorkoutExerciseService _workoutExerciseService;

    public WorkoutExerciseController(IWorkoutExerciseService workoutExerciseService)
    {
        _workoutExerciseService = workoutExerciseService;
    }

    [HttpPost]
    public async Task<ActionResult<WorkoutExerciseDto>> CreateAsync(WorkoutExerciseDto workoutExerciseDto)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("Could not find user id"); // TODO: Actual validation

        var workoutExercise = workoutExerciseDto.ToWorkoutExercise(userId);

        var createdWorkoutExercise = await _workoutExerciseService.Create(workoutExercise);

        return createdWorkoutExercise.ToWorkoutExerciseDto();
    }

    [HttpGet]
    public IEnumerable<WorkoutExerciseDto> GetAll()
    {
        var workoutExercises = _workoutExerciseService.GetAll();

        return workoutExercises.Select(workoutExercise => workoutExercise.ToWorkoutExerciseDto());
    }

    // [Authorize(Policy = Policies.UserOwnsWorkoutExercise)] // Is Admin
    [HttpGet("{workoutexerciseId}")]
    public async Task<WorkoutExerciseDto> GetById([FromRoute] string workoutExerciseId)
    {
        var workoutExercise = await _workoutExerciseService.GetById(workoutExerciseId);

        return workoutExercise.ToWorkoutExerciseDto();
    }

    // [Authorize(Policy = Policies.UserOwnsWorkoutExercise)] // Is Admin
    [HttpPatch("{workoutExerciseId}")]
    public async Task<ActionResult<WorkoutExerciseDto>> Update([FromRoute] string workoutExerciseId, [FromBody] WorkoutExerciseDto workoutExerciseDto)
    {
        if (workoutExerciseId != workoutExerciseDto.Id.ToString())
        {
            return BadRequest();
        }

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? throw new InvalidOperationException("Could not find user id"); // TODO: Actual validation

        var workoutExercise = workoutExerciseDto.ToWorkoutExercise(userId);

        var updatedWorkoutExercise = await _workoutExerciseService.Edit(workoutExercise);

        return updatedWorkoutExercise.ToWorkoutExerciseDto();
    }

    // [Authorize(Policy = Policies.UserOwnsWorkoutExercise)] // Is Admin
    [HttpDelete("{workoutexerciseId}")]
    public async Task<ActionResult> DeleteById([FromRoute] string workoutExerciseId)
    {
        await _workoutExerciseService.RemoveById(workoutExerciseId);

        return Ok();
    }
}
