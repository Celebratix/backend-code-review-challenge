using CategoriesApi.DTOs;
using CategoriesApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CategoriesApi.Controllers;

// This is the BEFORE state (without PR changes)
// The PR added CreateCategory and UpdateCategory endpoints

/*
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
*/

