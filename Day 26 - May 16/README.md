# PizzaOrderingAPI

This is a sample ASP.NET Core Web API project for a pizza ordering system. It demonstrates the use of AutoMapper for object-object mapping, JWT-based authentication, and authorization.

## Configuration

1. **AutoMapper Configuration**

    AutoMapper is used for mapping between DTOs and entity models. The mapping configurations are defined in the `MappingProfile` class.

    ```csharp
    using AutoMapper;
    using PizzaOrderingAPI.Models;
    using PizzaOrderingAPI.Models.DTOs;

    namespace PizzaOrderingAPI.Mappings
    {
        public class MappingProfile : Profile
        {
            public MappingProfile()
            {
                CreateMap<UserRegisterDto, User>();
                CreateMap<User, UserDTO>();
                CreateMap<Order, OrderDto>().ReverseMap();
            }
        }
    }
    ```

    Ensure AutoMapper is registered in `Program.cs`:

    ```csharp
    builder.Services.AddAutoMapper(typeof(MappingProfile));
    ```

2. **JWT Authentication and Authorization**

    The project uses JWT for securing the API endpoints. Configure JWT in `Program.cs`:

    ```csharp
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenKey:JWT"])),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    ```

    Add the JWT configuration to `appsettings.json`:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "YourDatabaseConnectionString"
      },
      "TokenKey": {
        "JWT": "YourSuperSecretKey"
      }
    }
    ```


## Basic API Usage
### Authentication Endpoints

- Register
- Login

### Protected Endpoints
- Order Pizza
- Pizza Related Endpoints

## Project Structure
- Controllers: API endpoints
- Services: Business logic
- Models: Data structures
- DTOs: Data transfer objects
- Mappings: AutoMapper profiles


<br>

Extended From [Day 25 - PizzaOrderingAPI](../Day%2025%20-%20May%2015/)