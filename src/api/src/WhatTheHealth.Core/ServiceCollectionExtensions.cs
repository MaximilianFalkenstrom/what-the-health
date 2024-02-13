using Microsoft.Extensions.DependencyInjection;
using WhatTheHealth.Core.Services.FoodEntries;
using WhatTheHealth.Core.Services.FoodItems;
using WhatTheHealth.Core.Services.UserSettings;

namespace WhatTheHealth.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IFoodEntryService, FoodEntryService>();
        services.AddScoped<IFoodItemService, FoodItemService>();
        services.AddScoped<IUserSettingService, UserSettingService>();

        return services;
    }
}
