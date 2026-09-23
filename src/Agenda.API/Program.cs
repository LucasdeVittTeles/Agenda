using Agenda.API.Services;
using Agenda.Application;
using Npgsql;
using Agenda.Application.Interfaces.Services;
using Agenda.Infrastructure;
using Agenda.Infrastructure.Context;
using Agenda.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

var connectionString =
    builder.Configuration.GetConnectionString("DefaultConnection");

var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);

dataSourceBuilder.EnableDynamicJson();

var dataSource = dataSourceBuilder.Build();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(dataSource));

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:7230";
        options.TokenValidationParameters.ValidateAudience = false;

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("========== JWT ERROR ==========");
                Console.WriteLine(context.Exception.Message);
                Console.WriteLine(context.Exception);
                Console.WriteLine("===============================");

                return Task.CompletedTask;
            }
        };

    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("React", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OwnerOnly", policy =>
    {
        policy.RequireRole("Owner");
    });

    options.AddPolicy("StaffOnly", policy =>
    {
        policy.RequireRole("Staff");
    });

    options.AddPolicy("OwnerOrStaff", policy =>
    {
        policy.RequireRole("Owner", "Staff");
    });
});

builder.Services.AddScoped<ICurrentUser, CurrentUserService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var initializer = scope.ServiceProvider
        .GetRequiredService<DbInitializer>();

    await initializer.SeedAsync();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("React");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();