using Microsoft.EntityFrameworkCore;
using TestSamples.ApplicationService.People.CommandHandlers;
using TestSamples.Core.Domain.People.Repositories;
using TestSamples.Infra.Data.Command.Sql;
using TestSamples.Infra.Data.Command.Sql.People;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<CreateNewPersonCommandHandler>();
builder.Services.AddScoped<IPersonCommandRepository, EfPersonCommandRepository>();
builder.Services.AddDbContextPool<TestSamplesDbContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("PersonDbConnStr")));

//swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//swagger
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
