using CategoriesApi.Data;
using CategoriesApi.DTOs;
using CategoriesApi.Helpers;
using CategoriesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CategoriesApi.Services;

public class CategoryService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CategoryService> _logger;

    public CategoryService(ApplicationDbContext dbContext, ILogger<CategoryService> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<List<CategoryDto>> GetCategoriesAsDtos()
    {
        var categories = await _dbContext.Categories.ToListAsync();
        return categories.Select(c => (CategoryDto)c).ToList();
    }

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
        category.Description = dto.Description;

        await _dbContext.SaveChangesAsync();

        return new CategoryAdminDto(category);
    }
}

