using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Categories.Database;
using TaskManager.Api.Categories.Database.Entities;
using TaskManager.Api.Categories.Providers.Interfaces;

namespace TaskManager.Api.Categories.Providers;

public class CategoriesProvider : ICategoriesProvider
{
    private readonly CategoriesDbContext _dbContext;
    private readonly IMapper _mapper;

    public CategoriesProvider(CategoriesDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;

        SeedData();
    }

    private void SeedData()
    {
        if (!_dbContext.Categories.Any())
        {
            _dbContext.Categories.Add(new Category { Id = 1, Name = "Personal", Description = "Personal tasks made for personal interests." });
            _dbContext.Categories.Add(new Category { Id = 2, Name = "Work", Description = "Work tasks made for work time optimization purposes." });
            _dbContext.Categories.Add(new Category { Id = 3, Name = "Family", Description = "Family tasks made for family related stuff." });
            _dbContext.Categories.Add(new Category { Id = 4, Name = "Business", Description = "Business tasks made for business purposes." });
            _dbContext.SaveChanges();
        }
    }

    public async Task<(bool IsSuccess, IEnumerable<Models.Category>? Categories, string ErrorMessage)> GetCategoriesAsync()
    {
        try
        {
            var categories = await _dbContext.Categories.ToListAsync();
            if (categories != null && categories.Any())
            {
                var mappedCategories = _mapper.Map<IEnumerable<Category>, IEnumerable<Models.Category>>(categories);
                return (true, mappedCategories, "");
            }
            return (false, null, "Not found");
        }
        catch (Exception ex)
        {
            return (false, null, ex.Message);
        }
    }
}
