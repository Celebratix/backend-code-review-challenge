namespace CategoriesApi.DTOs;

public class UpdateCategoryRequest
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
}