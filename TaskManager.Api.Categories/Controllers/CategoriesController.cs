using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Categories.Providers.Interfaces;

namespace TaskManager.Api.Categories.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : Controller
{
    private readonly ICategoriesProvider _provider;

    public CategoriesController(ICategoriesProvider provider)
    {
        _provider = provider;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        var result = await _provider.GetCategoriesAsync();
        if (result.IsSuccess)
        {
            return Ok(result.Categories);
        }
        return NotFound();
    }
}
