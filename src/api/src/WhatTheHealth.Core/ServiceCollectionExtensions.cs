using Microsoft.Extensions.DependencyInjection;
using WhatTheHealth.Core.Services.FoodItems;

namespace WhatTheHealth.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IFoodItemService, FoodItemService>();

        return services;
    }
}
