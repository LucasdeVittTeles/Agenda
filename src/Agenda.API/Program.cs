using Agenda.Infrastructure.Context;
using Agenda.Application;
using Microsoft.EntityFrameworkCore;
using Agenda.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Agenda.Application.Interfaces.Services;
using Agenda.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:7230";
        options.TokenValidationParameters.ValidateAudience = false;
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

builder.Services.AddScoped<ICurrentUser, CurrentUserService>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("React");

app.UseAuthentication();

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

app.MapControllers();

app.Run();