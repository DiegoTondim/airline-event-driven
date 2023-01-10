using Airline.Basket;
using Airline.Basket.Services;
using Airline.Domain.Resources;
using Airline.Payments.Consumers;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<OrdersConsumer>();

    config.SetKebabCaseEndpointNameFormatter();

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host(new Uri(builder.Configuration["Messaging:Default:Endpoint"]), "general", h =>
        {
            h.Username(builder.Configuration["Messaging:Default:UserName"]);
            h.Password(builder.Configuration["Messaging:Default:Password"]);
        });

        cfg.ReceiveEndpoint("orders", c =>
        {
            c.ConfigureConsumer<OrdersConsumer>(ctx);
        });
    });
});

builder.Services.AddResources(builder.Configuration);

builder.Services.AddScoped<IBasketService, BasketService>();

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
