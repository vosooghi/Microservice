using HealthChecks.System;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Health Check
builder.Services.AddHealthChecks().AddDiskStorageHealthCheck(setup: delegate (DiskStorageOptions diskStorageOptions)
{
    diskStorageOptions.AddDrive(@"C:\", 6000);
}, name: "My Drive", HealthStatus.Degraded)
    .AddSqlServer("server=.;initial catalog=MyDB;integrated security=true");
builder.Services.AddHealthChecksUI(s => s.AddHealthCheckEndpoint("default", "/hc")).AddInMemoryStorage();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHealthChecks("/hc", new HealthCheckOptions
{
    Predicate= _ => true,
    ResponseWriter=UIResponseWriter.WriteHealthCheckUIResponse
});
app.UseHealthChecksUI();
app.MapHealthChecksUI(config => {
    config.UIPath = "/hcu";
});

app.MapControllers();

app.Run();
