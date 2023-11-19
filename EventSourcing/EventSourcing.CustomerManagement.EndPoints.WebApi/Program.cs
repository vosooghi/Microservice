using EventSourcing.CustomerManagement.ApplicationServices.Customers;
using EventSourcing.CustomerManagement.Domain.Customers.Repositories;
using EventSourcing.CustomerManagement.Infrastructure.Data.Commands.Customer;
using EventSourcing.EventStore.SqlServer;
using EventSourcing.Framework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<CustomerService>();

//when using sql server as an Event Store
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IEventStore, SqlEventStore>();

//When using EventStore
//var esConnection = EventStoreConnection.Create( Configuration["eventStore:connectionString"], ConnectionSettings.Create().KeepReconnecting(),"MyApplication");
//services.AddSingleton(esConnection);
//services.AddScoped<IEventStore, EsEventStore>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.Run();
