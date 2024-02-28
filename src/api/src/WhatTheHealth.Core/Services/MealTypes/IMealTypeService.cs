using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.MealTypes;

public interface IMealTypeService
{
    Task<MealType> Create(MealType mealType);

    Task<MealType> GetById(string id);

    IEnumerable<MealType> GetAll();

    Task<MealType> Edit(MealType mealType);

    Task RemoveById(string id);
}
