# Order Service

This service manages the car purchase transaction process.

## Tech Stack
- .NET 8 Web API
- PostgreSQL (or MySQL)
- RabbitMQ (for event communication)

## Features
- Create order when a user clicks "Buy Car"
- Verify car status with car-listing-service (TODO)
- Communicate with payment gateway (mock)
- Update order status: pending, paid, cancelled
- Emits events: `order-created`, `order-paid` (TODO)
- Communicates with notification-service

## Getting Started
1. Install .NET 8 SDK
2. Configure your database (PostgreSQL or MySQL) in `appsettings.json` (not yet implemented, currently in-memory)
3. Configure RabbitMQ connection in `appsettings.json` (TODO)
4. Run the service:
   ```bash
   dotnet run
   ```

## API Endpoints
- `GET /Order` - Get all orders
- `GET /Order/{id}` - Get order by id
- `POST /Order` - Create a new order
- `PUT /Order/{id}/status` - Update order status
- `DELETE /Order/{id}` - Delete an order

## API Documentation
Swagger UI available at `/swagger` when running locally. 