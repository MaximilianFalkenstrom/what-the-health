using System.ComponentModel.DataAnnotations;

namespace WhatTheHealth.Domain.Entities;

public record UserDetails
{

    /// <summary>
    /// Id of the user
    /// </summary>
    [Key]
    public required string UserId { get; set; }

    /// <summary>
    /// Name of the user in question
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Calories per day for the user
    /// </summary>
    public required int Calories { get; set; }

    /// <summary>
    /// Carbs per day of the user in question
    /// </summary>
    public double Carbs { get; set; }

    /// <summary>
    /// Protein per day of the user in question
    /// </summary>
    public double Protein { get; set; }

    /// <summary>
    /// Fat per day of the user in question
    /// </summary>
    public double Fat { get; set; }

    /// <summary>
    /// Height of the user in question
    /// </summary>
    public double Height { get; set; }

    /// <summary>
    /// Weight of the user in question
    /// </summary>
    public double Weight { get; set; }

    /// <summary>
    /// Birthday of the user in question
    /// </summary>
    public DateOnly Birthday { get; set; }
}
