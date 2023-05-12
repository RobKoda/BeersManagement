using BeersManagement.Application;
using BeersManagement.Infrastructure;
using FluentValidation;
using Mapster;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterApplication();
builder.Services.RegisterInfrastructure(builder.Configuration);

var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
typeAdapterConfig.Scan(typeof(BeersManagement.Application.ServicesRegistration).Assembly);
typeAdapterConfig.Scan(typeof(BeersManagement.Infrastructure.ServicesRegistration).Assembly);

builder.Services.AddValidatorsFromAssembly(typeof(BeersManagement.Application.ServicesRegistration).Assembly);
ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
await EnsureDatabaseCreatedAsync(app);
app.Run();

async Task EnsureDatabaseCreatedAsync(IHost inWebApplication)
{
    var theContext = inWebApplication.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationContext>();
    await theContext.Database.MigrateAsync();
}