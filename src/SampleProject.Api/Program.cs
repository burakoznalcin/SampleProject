using Microsoft.EntityFrameworkCore;
using SampleProject.Api.Middlewares;
using SampleProject.Business.DependencyContainer;
using SampleProject.Business.Utilities.AuthorizeHelpers;
using SampleProject.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<SampleProjectDbContext>(options => 
options.UseMySQL(
builder.Configuration.GetConnectionString("MySQL")!)
);
builder.Services.AddMvc();

builder.Services.AddContainerServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();

app.UseRouting();

app.UseCustomAuthMiddleware();

app.MapControllers();

app.Run();
