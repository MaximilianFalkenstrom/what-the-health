using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WhatTheHealth.Core.Services.FoodEntries;
using WhatTheHealth.Core.Services.FoodItems;
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

        services.AddScoped<IFoodEntryRepository, FoodEntryRepository>();
        services.AddScoped<IFoodItemRepository, FoodItemRepository>();

        return services;
    }
}
