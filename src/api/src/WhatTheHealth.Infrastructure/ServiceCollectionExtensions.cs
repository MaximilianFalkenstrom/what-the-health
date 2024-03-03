using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhatTheHealth.Core.Services.Exercises;
using WhatTheHealth.Core.Services.FoodEntries;
using WhatTheHealth.Core.Services.FoodItems;
using WhatTheHealth.Core.Services.MealTypes;
using WhatTheHealth.Core.Services.UserDetails;
using WhatTheHealth.Core.Services.Workouts;
using WhatTheHealth.Infrastructure.Data;
using WhatTheHealth.Infrastructure.Repositories;

namespace WhatTheHealth.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // TODO: Could return null
        var connectionString = configuration.GetConnectionString("Postgres");

        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        services.AddScoped<IFoodEntryRepository, FoodEntryRepository>();
        services.AddScoped<IFoodItemRepository, FoodItemRepository>();
        services.AddScoped<IMealTypeRepository, MealTypeRepository>();
        services.AddScoped<IUserDetailsRepository, UserDetailsRepository>();
        services.AddScoped<IWorkoutRepository, WorkoutRepository>();

        return services;
    }
}
