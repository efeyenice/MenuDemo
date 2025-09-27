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

}
