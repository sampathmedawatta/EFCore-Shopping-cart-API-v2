# shopping-cart-api-core
This repository is for the back-end api of shopping cart client.
This code demonstrate
- Dedpendency Injection
- Unitofwork and Repository Pattern for individual domain models
- Serilogger for logging 
- Middleware to handle aplication errors
- JWT token authantivation and token refresh 
- DTOs to Domain models mapping using Automapper 

## This project is a sample test project to cover below,
- Understand and implement 3 Tier Architecture
- Implement web client using Angular
- Implement REST services using Web API (.ner Core 3.1)
- Secure Web API with Auth 2.0 (JWT)
- Understand and implement exception and error handling
- Understand and implement exception and error handling using logging frameworks
- Understand and implement dependancy injection
- Implement automated unit testing
- Run code analysis and fix defects

## Key Features
- Customer Login/Register
- View Categories/Products
- Create an Order
- View/Checkout Cart
- View Order History
- Send Order Confirmation email

## Assumptions
- Every User will have only one role assigned to them (Guest, User, Manager)
- Customer address will be use as a Shipping/Billing address
- Only allowed online payment methods (Credit/Debit Card, Pay on Delivery)
- Cart will manage locally from the client side until user checkout the cart
- Order details will be update once the checkout is completed
- Sensitive payment information will not be saved in Database(eg. Credit-Card number)

## Swagger Setup
- [Swagger configuration](https://www.youtube.com/watch?v=sdlt3-ptt9g)
- [Get started with Swashbuckle and ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio)

## AutoMapper
- [Use AutoMapper To Map One Object To Another In ASP.NET Core] (http://www.binaryintellect.net/articles/f1fdc9fd-91be-435c-8ace-b74e848db914.aspx)
- [Creating DTOs using AutoMapper](https://gunnarpeipman.com/creating-dtos-using-automapper/)
- [Getting Started with AutoMapper in ASP.NET Core](https://code-maze.com/automapper-net-core/)

## Referance Links
.net Core 3.1 API with Entity Framework code first
- https://www.youtube.com/watch?v=fmvcAzHpsk8 (.NET Core 3.1 MVC REST API - Full Course)
- https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-3.1 (Routing to controller actions in ASP.NET Core)

### multi layer .NET Core 3.0 API  
- https://medium.com/swlh/building-a-nice-multi-layer-net-core-3-api-c68a9ef16368 (Building a multi layer .NET Core 3.0 API from zero)
### Entity Framework 
- https://docs.microsoft.com/en-us/ef/core/ (Entity Framework Core)
- https://docs.microsoft.com/en-us/ef/core/querying/ (Querying Data)
- https://docs.microsoft.com/en-us/ef/ef6/querying/ (Querying and Finding Entities)
- https://docs.microsoft.com/en-us/ef/core/querying/related-data (Loading Related Data)

#### EF Code First 
- https://www.youtube.com/watch?v=qkJ9keBmQWo (Entity Framework Best Practices)
- https://www.youtube.com/watch?v=2nzEe50V4UE (Entity Framework Foreign Key Code First)
- https://www.youtube.com/watch?v=ZX7_12fwQLU (Entity Framework 6 DB first, Code first)

#### NuGet Packages
- Microsoft.EntiryFrameworkCore
- Microsoft.EntiryFrameworkCore.Design
- Microsoft.EntiryFrameworkCore.Tools
- Microsoft.EntiryFrameworkCore.SqlServer

#### powershell commands
- Enable Entitiy Framework : Enable-Migrations
- Add module changes: Add-Migration [description] or Add-Migration [description] -Context [DbContextName]
- Update Database: Update-Database or Update-Database -Context [DbContextName]
- Undo module changes before update database: Remove-Migration

#### Repository Pattern
- https://www.youtube.com/watch?v=rtXpYpZdOzM (Repository Pattern with C# and Entity Framework)
- https://medium.com/@chathuranga94/generic-repository-pattern-for-asp-net-core-9e3e230e20cb (Generic Repository Pattern for ASP.NET Core)
- https://codingblast.com/entity-framework-core-generic-repository/ (Entity Framework Core Generic Repository)
- https://code-maze.com/net-core-web-development-part4/ (ASP.NET Core Web API – Repository Pattern)
- https://code-maze.com/asp-net-core-web-api-with-ef-core-db-first-approach/ (ASP.NET Core Web API with EF Core DB-First Approach)
- https://www.thereformedprogrammer.net/is-the-repository-pattern-useful-with-entity-framework-core/ (Is the repository pattern useful with Entity Framework Core?)

#### Relationships
- https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cdata-annotations-simple-key%2Csimple-key (Relationships - A relationship defines how two entities relate to each other. In a relational database, this is represented by a foreign key constraint.)
- https://docs.microsoft.com/en-us/ef/core/querying/related-data (Loading Related Data)
- https://github.com/dotnet/efcore/issues/8470 (Foreign key-ed objects are not filled somehow)
- https://dotnetcoretutorials.com/2020/03/15/fixing-json-self-referencing-loop-exceptions/ (Fixing JSON Self Referencing Loop Exceptions)

### JWT Auth 
- https://www.youtube.com/watch?v=l56YLbAVAfo (JWT Authentication in ASP.NET Core 3.0 Web API)
- https://www.youtube.com/watch?v=3PyUjOmuFic&list=PL9wTjLtKQhXWApCtQmP-NWR8dEsMzU2n0&index=9&t=951s (Secure a .NET Core API with Bearer Authentication)
- https://www.youtube.com/watch?v=vWkPdurauaA&list=PL9wTjLtKQhXWApCtQmP-NWR8dEsMzU2n0&index=10&t=0s (ASP.NET Core Authentication with JWT (JSON Web Token))
- https://www.youtube.com/watch?v=7JP7V59X1sk&list=PL9wTjLtKQhXWApCtQmP-NWR8dEsMzU2n0&index=11&t=0s (JWT Refresh Token in ASP.Net Core (a deep dive))

### Add password Hash
- https://medium.com/@nishancw/net-core-3-0-preview-4-web-api-authentication-from-scratch-part-2-password-hashing-7e43b64cbe25

### Enable CROS Origin on ASP.net Core Web API
- https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-3.1

### Global Exception Handling 
- https://code-maze.com/global-error-handling-aspnetcore/
- https://docs.microsoft.com/en-us/aspnet/core/web-api/handle-errors?view=aspnetcore-3.1

### Controller Action Return Types
- https://docs.microsoft.com/en-us/aspnet/core/web-api/action-return-types?view=aspnetcore-3.1
- https://www.infoworld.com/article/3520770/how-to-return-data-from-aspnet-core-web-api.html

