using System.Net;
using CategoriesApi.Data;
using CategoriesApi.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CategoriesApi.Tests;

public sealed class CategoriesControllerTests : IClassFixture<WebApplicationFactory<Program>>, IDisposable
{
    private readonly HttpClient _httpClient;
    private readonly WebApplicationFactory<Program> _factory;
    private readonly IServiceScope _scope;
    private readonly ApplicationDbContext _db;

    public CategoriesControllerTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory.WithWebHostBuilder(builder =>
        {
            builder.ConfigureServices(services =>
            {
                // Remove the existing DbContext registration
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add a new in-memory database for testing
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase($"TestDb_{Guid.NewGuid()}");
                });
            });
        });

        _httpClient = _factory.CreateClient();
        _scope = _factory.Services.CreateScope();
        _db = _scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }

    [Fact]
    public async Task GetCategories_ReturnsOk()
    {
        // Arrange
        var category1 = new Category
        {
            Id = 1,
            Name = "Category 1",
            Description = "Description 1"
        };
        var category2 = new Category
        {
            Id = 2,
            Name = "Category 2",
            Description = "Description 2"
        };
        
        _db.Categories.Add(category1);
        _db.Categories.Add(category2);
        await _db.SaveChangesAsync();

        // Act
        var response = await _httpClient.GetAsync("/api/categories");

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    public void Dispose()
    {
        _scope?.Dispose();
        _httpClient?.Dispose();
    }
}
