using Microsoft.AspNetCore.Mvc;
using MenuDemo.Models;
using MenuDemo.Data;
using Microsoft.EntityFrameworkCore;

namespace MenuDemo.Controllers;

public class MenuController : Controller
{
    private readonly MenuContext _context;

    public MenuController(MenuContext context)
    {
        _context = context;
    }


    public async Task<IActionResult> IndexAsync()
    {
        var menu = await _context.Dishes.ToListAsync();

        if (menu == null)
        {
            return NotFound();
        }

        return View(menu);
    }

    public async Task<IActionResult> DetailsAsync(int id)
    {
        var dish = await _context.Dishes
            .Include(d => d.DishIngredients!)
            .ThenInclude(di => di.Ingredient)
            .FirstOrDefaultAsync(d => d.Id == id);

        if (dish == null)
        {
            return NotFound();
        }

        return View(dish);
    }

    [HttpGet]
    public async Task<IActionResult> Search(string searchTerm)
    {
        ViewBag.SearchTerm = searchTerm;
        
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            // If no search term, return all dishes
            var allDishes = await _context.Dishes.ToListAsync();
            return View("Index", allDishes);
        }

        // Search dishes by name or ingredients
        var dishes = await _context.Dishes
            .Include(d => d.DishIngredients!)
            .ThenInclude(di => di.Ingredient)
            .Where(d => 
                EF.Functions.Like(d.Name, $"%{searchTerm}%") ||
                d.DishIngredients!.Any(di => 
                    EF.Functions.Like(di.Ingredient!.Name, $"%{searchTerm}%")))
            .ToListAsync();

        return View("Index", dishes);
    }

    [HttpGet]
    public async Task<IActionResult> AdvancedSearch(string? dishName, string? ingredient, decimal? minPrice, decimal? maxPrice)
    {
        ViewBag.DishName = dishName;
        ViewBag.Ingredient = ingredient;
        ViewBag.MinPrice = minPrice;
        ViewBag.MaxPrice = maxPrice;

        var query = _context.Dishes
            .Include(d => d.DishIngredients!)
            .ThenInclude(di => di.Ingredient)
            .AsQueryable();

        // Apply filters
        if (!string.IsNullOrWhiteSpace(dishName))
        {
            query = query.Where(d => EF.Functions.Like(d.Name, $"%{dishName}%"));
        }

        if (!string.IsNullOrWhiteSpace(ingredient))
        {
            query = query.Where(d => d.DishIngredients!.Any(di => 
                EF.Functions.Like(di.Ingredient!.Name, $"%{ingredient}%")));
        }

        if (minPrice.HasValue)
        {
            query = query.Where(d => d.Price >= (double)minPrice.Value);
        }

        if (maxPrice.HasValue)
        {
            query = query.Where(d => d.Price <= (double)maxPrice.Value);
        }

        var dishes = await query.ToListAsync();
        
        ViewBag.IsAdvancedSearch = true;
        return View("Index", dishes);
    }

    [HttpGet]
    public async Task<IActionResult> GetIngredients()
    {
        var ingredients = await _context.Ingredients
            .OrderBy(i => i.Name)
            .Select(i => i.Name)
            .ToListAsync();
        
        return Json(ingredients);
    }

}
