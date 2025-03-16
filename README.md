# E-Commerce API

A robust e-commerce RESTful API built with .NET 9, following Clean Architecture principles for maintainable, testable, and scalable code.

## 📋 Project Overview

This e-commerce API provides a full set of endpoints for managing an online store, including:

- Product management
- Category organization
- Shopping cart functionality
- Order processing
- User authentication and role-based authorization

The solution is structured using Clean Architecture with clearly separated concerns:

- **Domain Layer**: Core business entities and repository interfaces
- **Application Layer**: Business logic, DTOs, and services
- **Infrastructure Layer**: Database context, repositories, and external services
- **API Layer**: Controllers and API endpoints

## 🛠️ Technologies Used

- **.NET 9**: The latest .NET framework with enhanced performance
- **Entity Framework Core**: ORM for database operations
- **ASP.NET Core Identity**: Authentication and authorization
- **AutoMapper**: Object-to-object mapping
- **Swagger/OpenAPI**: API documentation
- **SQL Server**: Database (configurable)

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- SQL Server (or change the connection string to use a different database provider)
- Visual Studio 2022, Visual Studio Code, or any preferred IDE with .NET support

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/ecommerce-api.git
   cd ecommerce-api
   ```

2. Update the connection string in `ECommerce.API/appsettings.json` with your database information:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=YOUR_SERVER;Database=ECommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

3. Apply database migrations:
   ```bash
   dotnet ef database update --project ECommerce.Infrastructure --startup-project ECommerce.API
   ```

4. Build and run the project:
   ```bash
   dotnet build
   dotnet run --project ECommerce.API
   ```

5. Access the Swagger documentation at: `https://localhost:5001/swagger`

## 🏗️ Project Structure

```
ECommerce.sln
├── ECommerce.Domain/
│   ├── Entities/
│   └── Repositories/
├── ECommerce.Application/
│   ├── DTOs/
│   ├── Mapping/
│   └── Services/
├── ECommerce.Infrastructure/
│   ├── Data/
│   ├── Identity/
│   └── Repositories/
└── ECommerce.API/
    ├── Controllers/
    └── Extensions/
```

### Domain Layer
Contains enterprise business rules and entities:
- Product, Category, Order, Cart entities
- Repository interfaces

### Application Layer
Contains business rules specific to the application:
- DTOs (Data Transfer Objects)
- Service interfaces and implementations
- Object mapping profiles

### Infrastructure Layer
Contains frameworks and implementation details:
- Database context and configurations
- Entity Framework repositories
- Identity implementation
- External service implementations

### API Layer
Contains controllers and API endpoints:
- RESTful API controllers
- Authorization policies
- Route configurations

## 🔒 Authentication and Authorization

The API uses ASP.NET Core Identity for authentication and role-based authorization:

- **Admin**: Full access to all features
- **Manager**: Manage products and orders
- **Customer**: Place orders and manage their own information

Authentication endpoints:
- POST `/api/auth/register`: Register a new customer
- POST `/api/auth/login`: Login with credentials
- POST `/api/auth/logout`: Logout current user

## 📃 API Endpoints

### Products
- GET `/api/products`: Get all products
- GET `/api/products/{id}`: Get product by ID
- GET `/api/products/category/{categoryId}`: Get products by category
- POST `/api/products`: Create a new product (Admin/Manager)
- PUT `/api/products/{id}`: Update a product (Admin/Manager)
- DELETE `/api/products/{id}`: Delete a product (Admin)

### Categories
- GET `/api/categories`: Get all categories
- GET `/api/categories/{id}`: Get category by ID
- POST `/api/categories`: Create a new category (Admin)
- PUT `/api/categories/{id}`: Update a category (Admin)
- DELETE `/api/categories/{id}`: Delete a category (Admin)

### Orders
- GET `/api/orders`: Get all orders (Admin/Manager)
- GET `/api/orders/{id}`: Get order by ID
- GET `/api/orders/my-orders`: Get current user's orders
- POST `/api/orders`: Create a new order
- PUT `/api/orders/{id}/status`: Update order status (Admin/Manager)

### Cart
- GET `/api/cart`: Get current user's cart
- POST `/api/cart/items`: Add item to cart
- PUT `/api/cart/items/{cartItemId}`: Update cart item quantity
- DELETE `/api/cart/items/{cartItemId}`: Remove item from cart
- DELETE `/api/cart`: Clear cart

### User Management
- GET `/api/user/profile`: Get current user profile
- PUT `/api/user/change-password`: Change password
- GET `/api/user/users`: Get all users (Admin)
- POST `/api/user/assign-role`: Assign role to user (Admin)
- POST `/api/user/remove-role`: Remove role from user (Admin)

## 🌱 Database Seeding

The application automatically seeds the database with initial data when running in Development mode:
- Admin user (admin@example.com / Admin123!)
- Manager user (manager@example.com / Manager123!)
- Sample categories (Electronics, Clothing, Books)
- Sample products

## 📝 License

[MIT License](LICENSE)

## 🤝 Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📞 Contact

Your Name - [@your_twitter](https://twitter.com/your_twitter) - email@example.com

Project Link: [https://github.com/yourusername/ecommerce-api](https://github.com/yourusername/ecommerce-api)
