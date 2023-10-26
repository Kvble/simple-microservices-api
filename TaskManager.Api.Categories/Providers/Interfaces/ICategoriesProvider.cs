using TaskManager.Api.Categories.Database.Entities;

namespace TaskManager.Api.Categories.Providers.Interfaces;

public interface ICategoriesProvider
{
    Task<(bool IsSuccess, IEnumerable<Models.Category>? Categories, string ErrorMessage)> GetCategoriesAsync();
}
