using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Airline.Domain.Resources
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddResources(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddMassTransit<IResourcesBus>(x =>
            {
                x.AddConsumer<ResourcesConsumer>();
                x.SetKebabCaseEndpointNameFormatter();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(new Uri(configuration["Messaging:Resources:Endpoint"]), "resources", h =>
                    {
                        h.Username(configuration["Messaging:Resources:UserName"]);
                        h.Password(configuration["Messaging:Resources:Password"]);
                    });

                    cfg.ReceiveEndpoint(new TemporaryEndpointDefinition(), c =>
                    {
                        c.ConfigureConsumer<ResourcesConsumer>(context);
                    });
                });
            }).AddScoped<ResourcesPublisherService>();
        }
    }
}
