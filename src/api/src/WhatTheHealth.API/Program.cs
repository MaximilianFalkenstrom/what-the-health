using WhatTheHealth.Core;
using WhatTheHealth.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using WhatTheHealth.API.Authorization.AuthorizationHandlers;
using WhatTheHealth.API.Authorization.Constants;
using WhatTheHealth.API.Authorization.Requirements;

namespace WhatTheHealth;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddCoreServices();
        builder.Services.AddInfrastructureServices(builder.Configuration);


        var MyAllowSpecificOrigins = "AllowedOrigins";

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: MyAllowSpecificOrigins,
                                policy =>
                                {
                                    policy.AllowCredentials();
                                    policy.AllowAnyHeader();
                                    policy.AllowAnyOrigin();
                                });
        });

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.Authority = builder.Configuration.GetValue<string>("Authentication:Authority");
            options.Audience = builder.Configuration.GetValue<string>("Authentication:Audience");
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IAuthorizationHandler, UserOwnsFoodEntryAuthorizationHandler>();

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy(Policies.UserOwnsFoodEntry, policy =>
                policy.AddRequirements(new UserOwnsFoodEntryRequirement()));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors(MyAllowSpecificOrigins);

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
