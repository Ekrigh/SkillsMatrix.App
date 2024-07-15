
using Microsoft.EntityFrameworkCore;
using SkillsMatrix.Infrastructure.Repositories;
using SkillsMatrix.Infrastructure.Services.UserService;
using SkillsMatrix.Server;
using SkillsMatrix.Infrastructure;


Sqltest.Main();
var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
// Add services to the container.
services.AddControllers();
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
services.AddDbContext<SMContext>(options =>
{
    options.UseMySql(configuration.GetConnectionString("SkillsMatrixDb"), serverVersion);
});

services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
services.AddScoped<IUserService, UserService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
