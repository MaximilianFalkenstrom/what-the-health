using Microsoft.Extensions.DependencyInjection;
using WhatTheHealth.Core.Services.Exercises;
using WhatTheHealth.Core.Services.FoodEntries;
using WhatTheHealth.Core.Services.FoodItems;
using WhatTheHealth.Core.Services.MealTypes;
using WhatTheHealth.Core.Services.UserDetails;
using WhatTheHealth.Core.Services.Workouts;

namespace WhatTheHealth.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddScoped<IExerciseService, ExerciseService>();
        services.AddScoped<IFoodEntryService, FoodEntryService>();
        services.AddScoped<IFoodItemService, FoodItemService>();
        services.AddScoped<IMealTypeService, MealTypeService>();
        services.AddScoped<IUserDetailsService, UserDetailsService>();
        services.AddScoped<IWorkoutService, WorkoutService>();


        return services;
    }
}
