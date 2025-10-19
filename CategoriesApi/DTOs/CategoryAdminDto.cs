using CategoriesApi.Models;

namespace CategoriesApi.DTOs;

public class CategoryAdminDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;

    public CategoryAdminDto()
    {
    }

    public CategoryAdminDto(Category category)
    {
        Id = category.Id;
        Name = category.Name;
        Description = category.Description;
    }
}