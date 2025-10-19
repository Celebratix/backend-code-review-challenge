using Microsoft.EntityFrameworkCore;

namespace CategoriesApi.Helpers;

public static class EntityExtensions
{
    public static async Task<T> FirstOrThrowAsync<T>(
        this IQueryable<T> query,
        System.Linq.Expressions.Expression<Func<T, bool>> predicate)
    {
        var entity = await query.FirstOrDefaultAsync(predicate);
        if (entity == null)
        {
            throw new InvalidOperationException($"Entity of type {typeof(T).Name} not found");
        }
        return entity;
    }
}

