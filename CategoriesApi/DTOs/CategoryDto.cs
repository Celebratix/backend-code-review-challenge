using CategoriesApi.Models;

namespace CategoriesApi.DTOs;

public sealed class CategoryDto
{
    public int Id { get; init; }

    public required string CategoryName { get; init; }

    public static explicit operator CategoryDto(Category dbModel)
    {
        return new CategoryDto
        {
            Id = dbModel.Id,
            CategoryName = dbModel.Name,
        };
    }
}

