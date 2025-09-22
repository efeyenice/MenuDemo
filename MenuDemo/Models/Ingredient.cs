namespace MenuDemo.Models;

public class Ingredient
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<DishIngredient>? DishIngredients { get; set; } = new();

}
