# Airline system

This project is a simple airline system from flight search to payments composed by the following apis:

- Booking => Flight search and fligh select, it starts the flow
- Basket => It stores the state of anscillaries added by customer
- Seats => Provides the prices for seats
- Payments => Responsible for the booking creation after payment

This project uses MassTransit + RabbitMQ and aims to show how events can easily decouple services even in a scenario where synchronous communication is needed.

# Pre requisites

- RabbitMQ
    - create virtual host /resources

There is swagger available or you can use the postman collection found on this repository.