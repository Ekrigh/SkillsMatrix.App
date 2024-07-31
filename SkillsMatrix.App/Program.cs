using Microsoft.EntityFrameworkCore;
using SkillsMatrix.App.Components;
using SkillsMatrix.Infrastructure;
using SkillsMatrix.Infrastructure.Repositories;
using SkillsMatrix.Infrastructure.Services.SkillService;
using SkillsMatrix.Infrastructure.Services.UserService;
using SkillsMatrix.Infrastructure.Services.UserSkillRatingService;
using SkillsMatrix.Infrastructure.Services.CategoryService;
using System.Configuration;
using MudBlazor.Services;
using SkillsMatrix.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
// Add services to the container.
services.AddMemoryCache();
services.AddRazorComponents()
    .AddInteractiveServerComponents();

services.AddMudServices(x =>
x.PopoverOptions.ThrowOnDuplicateProvider = false);
services.AddScoped<AppState>();
services.AddScoped<IUserService, UserService>();
services.AddScoped<ISkillService, SkillService>();
services.AddScoped<ICategoryService, CategoryService>();
services.AddScoped<IUserSkillRatingService, UserSkillRatingService>();
services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
services.AddScoped(typeof(ISkillRepository) , typeof(SkillRepository));
services.AddScoped(typeof(IUserSkillRatingRepository), typeof(UserSkillRatingRepository));
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
services.AddDbContext<SMContext>(options =>
{
    options.UseMySql(configuration.GetConnectionString("SkillsMatrixDb"), serverVersion);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
