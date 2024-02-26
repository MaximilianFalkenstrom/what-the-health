using WhatTheHealth.Core.Services.FoodItems;
using WhatTheHealth.Core.Services.MealTypes;
using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Core.Services.MealTypes;

public class MealTypeService : IMealTypeService
{
    private readonly IMealTypeRepository _mealTypeRepository;

    public MealTypeService(IMealTypeRepository mealTypeRepository)
    {
        _mealTypeRepository = mealTypeRepository;
    }

    public async Task<MealType> Create(MealType mealType)
    {
        return await _mealTypeRepository.Create(mealType);
    }
    
    public async Task<MealType> Edit(MealType mealType)
    {
        return await _mealTypeRepository.Update(mealType);
    }

    public async Task<MealType> GetById(string id)
    {
        var guid = Guid.Parse(id);

        return await _mealTypeRepository.GetById(guid);
    }

    public IEnumerable<MealType> GetAll()
    {
        return _mealTypeRepository.GetAll();
    }

    public async Task RemoveById(string id)
    {
        var guid = Guid.Parse(id);

        await _mealTypeRepository.DeleteById(guid);
    }
}
