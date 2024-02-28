namespace WhatTheHealth.Domain.Entities;

public record MealType
{
    /// <summary>
    /// Id of the meal
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Name of the meal in question
    /// </summary>
    public required string Name { get; set; }


}
