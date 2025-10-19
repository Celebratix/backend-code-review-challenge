# Pull Request Changes

## Branch: `feature/add-category-description` → `main` (staging)

This document outlines the changes that were made in the PR. This helps candidates understand what was added/modified.

## Overview

The PR from `feature/add-category-description` adds a `Description` field to categories and introduces new endpoints for creating and updating categories.

## Files Changed

### 1. **Category.cs** (Model)
**Changes:**
- ✅ Added `Description` property with `[MaxLength(200)]` attribute

**Before:**
```csharp
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
```

**After:**
```csharp
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    [MaxLength(200)]
    public string Description { get; set; } = null!;
}
```

---

### 2. **CategoryDto.cs** (Public DTO)
**Changes:**
- ❌ Changed `Name` property to `CategoryName` (BREAKING CHANGE)

**Before:**
```csharp
public sealed class CategoryDto
{
    public int Id { get; init; }
    public required string Name { get; init; }

    public static explicit operator CategoryDto(Category dbModel)
    {
        return new CategoryDto
        {
            Id = dbModel.Id,
            Name = dbModel.Name,
        };
    }
}
```

**After:**
```csharp
public sealed class CategoryDto
{
    public int Id { get; init; }
    public required string CategoryName { get; init; }

    public static explicit operator CategoryDto(Category dbModel)
    {
        return new CategoryDto
        {
            Id = dbModel.Id,
            CategoryName = dbModel.Name,  // Changed property name
        };
    }
}
```

---

### 3. **CategoryUpdateAdminDto.cs**
**Changes:**
- ✅ Added `Description` property

**Before:**
```csharp
public class CategoryUpdateAdminDto
{
    public string Name { get; set; } = null!;
}
```

**After:**
```csharp
public class CategoryUpdateAdminDto
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}
```

---

### 4. **CategoryService.cs**
**Changes:**
- ✅ Added `CreateCategory` method
- ✅ Modified `UpdateCategory` to handle description

**Before:**
```csharp
public async Task<CategoryAdminDto> UpdateCategory(int id, CategoryUpdateAdminDto dto)
{
    var category = await _dbContext.Categories.FirstOrThrowAsync(c => c.Id == id);
    
    category.Name = dto.Name;
    
    await _dbContext.SaveChangesAsync();
    
    return new CategoryAdminDto(category);
}
```

**After:**
```csharp
public async Task<Category> CreateCategory(Category entity)
{
    _dbContext.Add(entity);
    await _dbContext.SaveChangesAsync();
    _logger.LogInformation("Create new category, id: {CategoryId}", entity.Id);
    return entity;
}

public async Task<CategoryAdminDto> UpdateCategory(int id, CategoryUpdateAdminDto dto)
{
    var category = await _dbContext.Categories.FirstOrThrowAsync(c => c.Id == id);

    category.Name = dto.Name;
    category.Description = dto.Description;  // Added

    await _dbContext.SaveChangesAsync();

    return new CategoryAdminDto(category);
}
```

---

### 5. **CategoriesController.cs**
**Changes:**
- ✅ Added `CreateCategory` endpoint (POST)
- ✅ Added `UpdateCategory` endpoint (PUT)

**Before:**
```csharp
[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly CategoryService _service;
    private readonly ILogger<CategoriesController> _logger;

    public CategoriesController(CategoryService service, ILogger<CategoriesController> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Get all categories
    /// </summary>
    [HttpGet]
    public async Task<List<CategoryDto>> GetCategories()
    {
        return await _service.GetCategoriesAsDtos();
    }
}
```

**After:**
```csharp
[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly CategoryService _service;
    private readonly ILogger<CategoriesController> _logger;

    public CategoriesController(CategoryService service, ILogger<CategoriesController> logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Get all categories
    /// </summary>
    [HttpGet]
    public async Task<List<CategoryDto>> GetCategories()
    {
        return await _service.GetCategoriesAsDtos();
    }

    /// <summary>
    /// Create category. Only admin can perform this action.
    /// </summary>
    [HttpPost]
    [AuthorizeRoles(Role.SuperAdmin)]
    public async Task CreateCategory(Category entity)
    {
        try
        {
            await _service.CreateCategory(entity);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    /// <summary>
    /// Update category. Only admin can perform this action.
    /// </summary>
    [HttpPut("{id}")]
    [AllowAnonymous]
    public async Task<CategoryAdminDto> UpdateCategory(int id, UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        if (request.Description.Length > 100)
        {
            throw new ArgumentException("Description length must not exceed 100 characters.");
        }

        var dto = new CategoryUpdateAdminDto
        {
            Name = request.Name,
            Description = request.Description
        };

        return await _service.UpdateCategory(id, dto);
    }
}
```

---

### 6. **New Files Added**
- `DTOs/UpdateCategoryRequest.cs` - Request model for updating categories
- `CategoriesApi.Tests/CategoriesControllerTests.cs` - Integration tests

---

## Summary of Changes

### ✅ Additions (Good)
- Description field on Category model
- CreateCategory endpoint
- UpdateCategory endpoint  
- Basic integration tests

### ❌ Issues Introduced (For Review)
- Wrong authorization on UpdateCategory (`[AllowAnonymous]`)
- Inconsistent validation (100 vs 200 chars)
- Poor exception handling
- Missing return type on CreateCategory
- Breaking change in DTO naming
- Unused parameters
- Magic numbers
- Incomplete test coverage

## Using This Document

**For Candidates:**
This shows you what changed in the PR. Review the "After" code for issues.

**For Interviewers:**
Use this to explain the PR context to candidates.

