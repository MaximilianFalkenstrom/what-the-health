using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WhatTheHealth.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    [HttpGet("unauthorized")]
    public IActionResult Unauthorized()
    {
        return Ok("Unauthorized request finished successfully.");
    }

    [HttpGet("authorized")]
    [Authorize]
    public IActionResult Authorized()
    {
        return Ok("Authorized request finished successfully");
    }
}
