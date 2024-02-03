using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.FoodItems;

public class FoodItemDto
{
    public Guid Id { get; set; }

    public required string Name { get; set; }

    public required int Calories { get; set; }

    public double Carbohydrates { get; set; }

    public double Fat { get; set; }

    public double Protein { get; set; }
}
