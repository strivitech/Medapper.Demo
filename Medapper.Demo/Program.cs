using System.Reflection;
using FluentMigrator.Runner;
using Medapper.Demo.Behaviours;
using Medapper.Demo.Factories;
using Medapper.Demo.Migrations;
using Medapper.Demo.Repositories;
using Medapper.Demo.Settings;
using MediatR;
using MediatR.Pipeline;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DbConnectionSettings>(builder.Configuration.GetSection(DbConnectionSettings.SectionName));

builder.Services
    .AddFluentMigratorCore()
    .ConfigureRunner(rb => rb
        .AddPostgres()
        .WithGlobalConnectionString(builder.Configuration.GetSection(DbConnectionSettings.SectionName).GetValue<string>("ConnectionString"))
        .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
    .AddLogging(lb => lb.AddFluentMigratorConsole());

builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssemblyContaining<Program>()
        .AddRequestPreProcessor(typeof(IRequestPreProcessor<>), typeof(LogRequestNamePreProcessor<>))
        .AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>))
        .AddBehavior(typeof(IPipelineBehavior<,>), typeof(ExceptionBehaviour<,>)));

builder.Services.AddScoped<IConnectionFactory, PostgresConnectionFactory>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

try
{
    using var services = app.Services.CreateScope();
    var runner = services.ServiceProvider.GetRequiredService<IMigrationRunner>();
    runner.MigrateUp();
}
catch (Exception ex)
{
    Console.WriteLine(ex);
    throw;
}

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