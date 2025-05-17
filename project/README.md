# Project: User & Role Management with .NET Core 8 and Angular

**Note:** The solution for this project is available in a submodule under the `project/solution` directory. The Angular code is located in the `main` branch of the submodule, while the backend code is on the `master` branch.

## Project Overview
This project involves building a REST API using .NET Core 8 to manage users and roles, with PostgreSQL as the database service. Students will also develop the frontend using Angular and implement security measures for authentication and authorization.

## Development Environment
- **Code Editors**: Visual Studio Code or JetBrains Rider
- **Database**: PostgreSQL
- **API Framework**: .NET Core 8
- **Frontend Framework**: Angular

## Project Setup
### Task 1: Install .NET Core 8 (if not installed)
#### Steps:
1. **Download .NET 8 SDK** from [Download .NET](https://dotnet.microsoft.com/download/dotnet).
2. **Select .NET 8** and choose the appropriate installer for your system.
3. **Run the installer** and follow the setup instructions.
4. **Verify the installation** by running the following command in a terminal:
   ```bash
   dotnet --version
   ```
   This should output the installed .NET version, e.g., `8.0.x`.

### Task 2: Create a New .NET Web API Project
#### Steps:
1. Open a terminal and run:
   ```shell
   dotnet new webapi -n UserRoleManagementApi
   cd UserRoleManagementApi
   ```

## API Implementation
### Task 3: Define Entities
- **User** (fields: `username`, `email`, `password`, etc.)
- **Post** (One-to-Many: A user can have multiple posts)
- **Role** (Many-to-Many: A user can have multiple roles, and a role can belong to multiple users)

### Task 4: Update Database Context
#### Steps:
1. Define relationships using Fluent API.
2. Update `ApplicationDbContext` to include the new entities.

### Task 5: Implement Controllers & Services
#### Steps:
1. Implement `UsersController` to manage users.
2. Implement `PostsController` to manage posts.
3. Implement `RolesController` to manage roles.
4. Create corresponding service classes for each controller.

### Project Structure (3-Tier Architecture)
```shell
UserRoleManagementApi/
    ├── appsettings.Development.json
    ├── appsettings.json
    ├── Controllers/
    │   ├── UsersController.cs
    │   ├── PostsController.cs
    │   ├── RolesController.cs
    ├── Data/
    │   ├── ApplicationDbContext.cs
    ├── Migrations/  # Auto-generated
    ├── Models/
    │   ├── User.cs
    │   ├── Post.cs
    │   ├── Role.cs
    ├── Properties/
    │   ├── launchSettings.json
    ├── Services/
    │   ├── Interfaces/
    │   │   ├── IUserService.cs
    │   │   ├── IPostService.cs
    │   │   ├── IRoleService.cs
    │   ├── Implementations/
    │   │   ├── UserService.cs
    │   │   ├── PostService.cs
    │   │   ├── RoleService.cs
    ├── Program.cs
    ├── README.md
```

### Task 6: Develop API Endpoints
#### Endpoints to Implement:
1. **User Management**
   - Get all users with their roles.
   - Get a user with their roles.
   - Get all users with their posts.
   - Get a user with their posts.
   - Create a new user.
   - Update a user's details.
   - Delete a user.
2. **Role Management**
   - Assign a role to a user.
   - Create a new role.
   - Get a specific role.
   - Get all roles.
   - Update a role.
   - Delete a role.
   - Remove a role from a user.
3. **Documentation**
   - Apply Swagger documentation for all APIs.

**Note:** Use LINQ for queries where applicable.

## Optional Enhancements
### Task 7: Dockerization
#### Steps:
1. Create a `Dockerfile` and `docker-compose.yml` to containerize the API and database.

### Task 8: Authentication & Authorization
#### Steps:
1. Implement JWT authentication.
2. Configure role-based access control.

### Task 9: Unit & Integration Testing
#### Steps:
1. Use `xUnit` for testing API endpoints.
2. Implement Angular unit tests with `Jasmine` and `Karma`.

### Task 10: Frontend Development
#### Steps:
1. Implement the required pages using Angular.

### Task 11: CI/CD Pipeline
#### Steps:
1. Use GitHub Actions or Jenkins for continuous integration and deployment.

## Annex: Setup Commands
### Install Required Packages
```shell
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 6.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### Apply Database Migrations
```shell
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### Database Setup with Docker
#### Steps:
1. Run PostgreSQL in a Docker container:
   ```shell
   docker run -p 5432:5432 --env POSTGRES_PASSWORD=password --env POSTGRES_USER=postgres_user --env POSTGRES_DB=postgres_db --name userRoleDB -d postgres
   ```

