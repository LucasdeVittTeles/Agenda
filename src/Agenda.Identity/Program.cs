using Agenda.Application.Services.Password;
using Agenda.Identity;
using Agenda.Identity.Services;
using Agenda.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();

builder.Services.AddControllersWithViews();

builder.Services
    .AddIdentityServer()
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients);

var app = builder.Build();

app.UseStaticFiles();

app.UseIdentityServer();

app.MapDefaultControllerRoute();

app.Run();