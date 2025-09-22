namespace MenuDemo.Models;

public class DishIngredient
{
    public int DishId { get; set; }
    public required Dish Dish { get; set; }

    public int IngredientId { get; set; }
    public required Ingredient Ingredient { get; set; }

}
