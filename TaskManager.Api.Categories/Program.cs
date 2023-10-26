using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Categories.Database;
using TaskManager.Api.Categories.Profiles;
using TaskManager.Api.Categories.Providers;
using TaskManager.Api.Categories.Providers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ICategoriesProvider, CategoriesProvider>();
builder.Services.AddAutoMapper(config => config.AddProfile(typeof(CategoryProfile)));
builder.Services.AddDbContext<CategoriesDbContext>(options =>
{
    options.UseInMemoryDatabase("Category");
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
