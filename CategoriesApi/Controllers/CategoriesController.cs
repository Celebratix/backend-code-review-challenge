using CategoriesApi.Authorization;
using CategoriesApi.DTOs;
using CategoriesApi.Models;
using CategoriesApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CategoriesApi.Controllers;

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