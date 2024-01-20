using Microsoft.EntityFrameworkCore;
using WhatTheHealth.Domain.Entities;

namespace WhatTheHealth.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<FoodItem> FoodItems { get; set; }
}
