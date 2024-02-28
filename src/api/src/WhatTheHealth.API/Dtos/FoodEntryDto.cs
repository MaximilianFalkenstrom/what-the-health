using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.API.Dtos;

public class FoodEntryDto
{
    public Guid Id { get; set; }

    public required Guid FoodItemId { get; set; }

    public required Guid MealTypeId { get; set; }

    public FoodItem? FoodItem { get; set; }

    public MealType? MealType { get; set; }

    public required int Amount { get; set; }

    public required DateOnly Date { get; set; }
}
