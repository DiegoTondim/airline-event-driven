using Airline.Booking.Models;
using Airline.Domain.Events;
using Airline.Domain.Resources;
using Airline.Seats.Consumers;
using Airline.Seats.Models;
using Airline.Seats.Services;
using MassTransit;
using RabbitMQ.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ISeatsService, SeatsService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<FlightSelectedConsumer>();

    config.SetKebabCaseEndpointNameFormatter();

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(new Uri(builder.Configuration["Messaging:Default:Endpoint"]), "general", h =>
        {
            h.Username(builder.Configuration["Messaging:Default:UserName"]);
            h.Password(builder.Configuration["Messaging:Default:Password"]);
        });

        cfg.ReceiveEndpoint("seats-cache", c =>
        {
            c.ConfigureConsumer<FlightSelectedConsumer>(ctx);
        });
    });
});

builder.Services.AddResources(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

