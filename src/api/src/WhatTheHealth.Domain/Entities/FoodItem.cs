namespace WhatTheHealth.Domain.Entities;

public record FoodItem
{
    /// <summary>
    /// Id of the item
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Name of the food in question
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Calories per default measurement
    /// </summary>
    public required int Calories { get; set; }

    /// <summary>
    /// Carbohydrates per default measurement, stored in grams
    /// </summary>
    public double Carbohydrates { get; set; }

    /// <summary>
    /// Fat per default measurement, stored in grams
    /// </summary>
    public double Fat { get; set; }

    /// <summary>
    /// Proteins per default measurement, stored in grams
    /// </summary>
    public double Protein { get; set; }
}
