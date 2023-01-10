using Airline.Booking.Models;
using MassTransit;

namespace Airline.Domain.Resources
{
    public class ResourcesPublisherService
    {
        private readonly IResourcesBus _publisher;

        public ResourcesPublisherService(IResourcesBus bus)
        {
            _publisher = bus;
        }

        public async Task PublishAsync() {
            await _publisher.Publish(new ResourcesUpdated());
        }
    }
}
