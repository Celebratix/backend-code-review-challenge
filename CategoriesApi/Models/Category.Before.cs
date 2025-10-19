using System.ComponentModel.DataAnnotations;

namespace CategoriesApi.Models;

// This is the BEFORE state (without PR changes)
public class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}

