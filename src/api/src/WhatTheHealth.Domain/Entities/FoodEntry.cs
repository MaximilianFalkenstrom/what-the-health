namespace WhatTheHealth.Domain.Entities;

public class FoodEntry
{
    public Guid Id { get; set; }

    public required string UserId { get; set; }

    public required Guid FoodItemId { get; set; }

    public FoodItem? FoodItem { get; set; }

    public required int Amount { get; set; }

    public required DateOnly Date { get; set; }
}
