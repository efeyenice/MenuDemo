using Microsoft.EntityFrameworkCore;
using MenuDemo.Models;

namespace MenuDemo.Data;
public class MenuContext : DbContext
{
    public MenuContext(DbContextOptions<MenuContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DishIngredient>()
            .HasKey(di => new { di.DishId, di.IngredientId });

        modelBuilder.Entity<DishIngredient>()
            .HasOne(di => di.Dish)
            .WithMany(d => d.DishIngredients)
            .HasForeignKey(di => di.DishId);

        modelBuilder.Entity<DishIngredient>()
            .HasOne(di => di.Ingredient)
            .WithMany(i => i.DishIngredients)
            .HasForeignKey(di => di.IngredientId);


            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name = "Doner Durum", Price = 12.99, ImageUrl = "https://www.ustadonerci.com/media/products/durum-et-doner_b.png" },
                new Dish { Id = 2, Name = "Patlican Kebabi", Price = 9.99, ImageUrl = "https://i.nefisyemektarifleri.com/2022/05/29/orijinal-antep-usulu-patlican-kebabi-3.jpg" }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Lavas" },
                new Ingredient { Id = 2, Name = "Et" },
                new Ingredient { Id = 3, Name = "Domates" },
                new Ingredient { Id = 4, Name = "Biber" },
                new Ingredient { Id = 5, Name = "Patlican" },
                new Ingredient { Id = 6, Name = "Kiyma" }
            );

            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1, Dish = null! , Ingredient = null! },
                new DishIngredient { DishId = 1, IngredientId = 2, Dish = null! , Ingredient = null! },
                new DishIngredient { DishId = 1, IngredientId = 3, Dish = null! , Ingredient = null! },
                new DishIngredient { DishId = 1, IngredientId = 4, Dish = null! , Ingredient = null! },
                new DishIngredient { DishId = 2, IngredientId = 5, Dish = null! , Ingredient = null! },
                new DishIngredient { DishId = 2, IngredientId = 6, Dish = null! , Ingredient = null! },
                new DishIngredient { DishId = 2, IngredientId = 3, Dish = null! , Ingredient = null! },
                new DishIngredient { DishId = 2, IngredientId = 4, Dish = null! , Ingredient = null! }
            );
    }

    public DbSet<Dish> Dishes => Set<Dish>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<DishIngredient> DishIngredients => Set<DishIngredient>();



}

