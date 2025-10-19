# Categories API - Code Review Exercise

This is a simplified ASP.NET Core Web API project designed as a code review exercise for backend engineering candidates.

## Scenario

You are reviewing a pull request that adds new features to a Categories API. The PR includes:
- Adding a `Description` field to the `Category` model
- Adding a new `CreateCategory` endpoint
- Modifying the `UpdateCategory` endpoint
- Changing the `Name` property to `CategoryName` in the CategoryDto
- Adding basic integration tests

## Your Task

Review the code changes and identify any issues, bugs, security concerns, code quality problems, or inconsistencies. Consider:

1. **Security**: Are there any security vulnerabilities?
2. **Code Quality**: Are there any code smells or bad practices?
3. **Consistency**: Is the code consistent with best practices?
4. **Validation**: Is data properly validated?
5. **Error Handling**: Are errors handled appropriately?
6. **Testing**: Are the tests adequate?
7. **API Design**: Is the API well-designed?

## Project Structure

```
CategoriesApi/
├── Controllers/
│   └── CategoriesController.cs      # API endpoints
├── Services/
│   └── CategoryService.cs           # Business logic
├── Models/
│   └── Category.cs                  # Entity model
├── DTOs/
│   ├── CategoryDto.cs               # Public DTO
│   ├── CategoryAdminDto.cs          # Admin DTO
│   ├── CategoryUpdateAdminDto.cs    # Update DTO
│   └── UpdateCategoryRequest.cs     # Request model
├── Data/
│   └── ApplicationDbContext.cs      # EF Core DbContext
├── Authorization/
│   ├── Role.cs                      # Role constants
│   └── AuthorizeRolesAttribute.cs   # Custom authorization
└── Helpers/
    └── EntityExtensions.cs          # Helper extensions

CategoriesApi.Tests/
└── CategoriesControllerTests.cs     # Integration tests
```

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later
- Your favorite IDE (Visual Studio, VS Code, Rider)

### Running the Application

```bash
# Restore dependencies
dotnet restore

# Run the API
cd CategoriesApi
dotnet run

# The API will be available at https://localhost:5001 (or http://localhost:5000)
# Swagger UI will be available at https://localhost:5001/ (root)
```

### Exploring the API

Once the application is running, open your browser and navigate to:
- **Swagger UI**: `https://localhost:5001/` - Interactive API documentation
- **Swagger JSON**: `https://localhost:5001/swagger/v1/swagger.json` - OpenAPI specification

Swagger UI allows you to:
- See all available endpoints
- Test the API directly from the browser
- View request/response models
- Understand the API structure

### Running Tests

```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --logger "console;verbosity=detailed"
```

### API Endpoints

- `GET /api/categories` - Get all categories
- `POST /api/categories` - Create a new category (requires SuperAdmin role)
- `PUT /api/categories/{id}` - Update a category

## Key Files to Review

The following files contain the changes that were made in the PR:

1. **CategoriesController.cs** - Added CreateCategory and UpdateCategory endpoints
2. **CategoryService.cs** - Added CreateCategory method
3. **Category.cs** - Added Description field
4. **CategoryDto.cs** - Changed Name to CategoryName
5. **CategoryUpdateAdminDto.cs** - Added Description field
6. **CategoriesControllerTests.cs** - New test file

## What to Look For

Here are some hints about areas to investigate (without giving away the answers):

- Authorization and authentication
- Data validation
- Exception handling
- Consistency between validation rules
- Property naming conventions
- HTTP response types
- Test coverage

## Submission

Prepare a code review document that includes:

1. List of issues found (categorized by severity: critical, major, minor)
2. Explanation of each issue
3. Suggested fixes or improvements
4. Any positive observations about the code

## Notes

- This project uses an in-memory database for simplicity
- Authentication/authorization is not fully implemented (focus on the intent)
- The code intentionally contains issues for you to find

## Technology Stack

- ASP.NET Core 9.0
- Entity Framework Core (In-Memory)
- xUnit for testing
- FluentAssertions for test assertions

