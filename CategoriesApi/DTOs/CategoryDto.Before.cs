using CategoriesApi.Models;

namespace CategoriesApi.DTOs;

// This is the BEFORE state (without PR changes)
public sealed class CategoryDto_Before
{
    public int Id { get; init; }

    public required string Name { get; init; }  // Was "Name", changed to "CategoryName" in PR

    public static explicit operator CategoryDto_Before(Category dbModel)
    {
        return new CategoryDto_Before
        {
            Id = dbModel.Id,
            Name = dbModel.Name,
        };
    }
}

