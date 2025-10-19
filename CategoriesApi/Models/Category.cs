using System.ComponentModel.DataAnnotations;

namespace CategoriesApi.Models;

public class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    [MaxLength(200)]
    public string Description { get; set; } = null!;
}