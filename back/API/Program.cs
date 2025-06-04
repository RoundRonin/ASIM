using API;
using API.Middleware;
using Application.Interfaces;
using Application.MappingProfiles;
using Application.Services;
using Domain.Interfaces;
using Domain.Services;
using Infrastructure.Data;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.ComponentModel.Design;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextJS", policy =>
    {
        policy.WithOrigins("http://localhost:3000") // Your frontend URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


//For user?
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserDomainService, UserDomainService>();
builder.Services.AddScoped<IUserService, UserService>();




// Database configuration
var connectionString = DbContextConfigurationHelper.BuildConnectionString();
builder.Services.AddDbContext<AppDbContext>(options =>
    DbContextConfigurationHelper.Configure((DbContextOptionsBuilder<AppDbContext>)options, connectionString),
    ServiceLifetime.Scoped);

// Optional: DbContext Factory and Scope Factory registrations
builder.Services.AddScoped<DbContextFactory>();
builder.Services.AddSingleton<IServiceScopeFactory>(provider =>
    provider.GetRequiredService<IServiceProvider>()
           .CreateScope()
           .ServiceProvider
           .GetRequiredService<IServiceScopeFactory>());

// Repositories
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IRepairRepository, RepairRepository>();

// Domain Services (Business logic layer)
builder.Services.AddScoped<IInventoryDomainService, InventoryDomainService>();
builder.Services.AddScoped<IRepairDomainService, RepairDomainService>();

// Application Services (Orchestration & mapping)
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IRepairService, RepairService>();

// AutoMapper Profiles
builder.Services.AddAutoMapper(typeof(InventoryProfile));
builder.Services.AddAutoMapper(typeof(RepairProfile));

// Controllers, Endpoints and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

var app = builder.Build();

// HTTP Pipeline
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
});
app.UseMiddleware<ExceptionHandler>();

app.UseRouting();
app.UseCors("AllowNextJS");
app.UseAuthorization();
app.MapControllers();

app.Run();
