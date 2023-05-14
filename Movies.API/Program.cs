using Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Movies.API.Middleware;
using Movies.Application;
using Movies.Domain.Repositories;
using Movies.Infrastructure.DbContext;
using Movies.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;

var assembly = Assembly.GetExecutingAssembly();

builder.Services.AddControllers().AddApplicationPart(assembly);

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(c =>
{
    string presentationDocumentationFile = $"{assembly.GetName().Name}.xml";

    string presentationDocumentationFilePath = Path.Combine(AppContext.BaseDirectory, presentationDocumentationFile);

    c.IncludeXmlComments(presentationDocumentationFilePath);

    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web", Version = "v1" });
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

var applicationAssembly = typeof(AssemblyReference).Assembly;

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(applicationAssembly));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

builder.Services.AddValidatorsFromAssembly(applicationAssembly);

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

builder.Services.AddDbContextPool<MoviesDbContext>(builder =>
{
    builder.UseSqlServer(config.GetConnectionString("Database"));
});

builder.Services.AddScoped<IMoviesRepository, MoviesRepository>();

builder.Services.AddScoped<IWatchListRepository, WatchListRepository>();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.UseSwagger();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.Run();
