using WhatTheHealth.Core;
using WhatTheHealth.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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

        var origins = builder.Configuration.GetValue<string>("Authentication:Origins");
        if (origins != null)
        {
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins(origins);
                                      policy.AllowCredentials();
                                      policy.AllowAnyHeader();
                                  });
            });
        }

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
