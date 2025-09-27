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
                new Dish { Id = 2, Name = "Patlican Kebabi", Price = 9.99, ImageUrl = "https://i.nefisyemektarifleri.com/2022/05/29/orijinal-antep-usulu-patlican-kebabi-3.jpg" },
                new Dish { Id = 3, Name = "Adana Kebap", Price = 15.99, ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/5/55/Adana_kebab.jpg" },
                new Dish { Id = 4, Name = "Urfa Kebap", Price = 15.99, ImageUrl = "https://www.diyetkolik.com/site_media/media/foodrecipe_images/ufra-kabap.png" },
                new Dish { Id = 5, Name = "Lahmacun", Price = 8.99, ImageUrl = "https://cevatusta.com.tr/wp-content/uploads/2020/11/Urfa-Lahmacun.jpg" },
                new Dish { Id = 6, Name = "Pide", Price = 11.99, ImageUrl = "https://turkishfoodie.com/wp-content/uploads/2019/01/Pide.jpg" },
                new Dish { Id = 7, Name = "Manti", Price = 13.99, ImageUrl = "https://i.lezzet.com.tr/images-xxlarge-secondary/manti-nasil-pisirilir-9853d099-517c-4e89-be1c-960b703dcb8e.jpg" },
                new Dish { Id = 8, Name = "Kofte", Price = 10.99, ImageUrl = "https://www.unileverfoodsolutions.com.tr/dam/global-ufs/mcos/TURKEY/calcmenu/recipes/TR-recipes/general/k%C3%B6fte-izgara/main-header.jpg" }
            );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Lavas" },
                new Ingredient { Id = 2, Name = "Et" },
                new Ingredient { Id = 3, Name = "Domates" },
                new Ingredient { Id = 4, Name = "Biber" },
                new Ingredient { Id = 5, Name = "Patlican" },
                new Ingredient { Id = 6, Name = "Kiyma" },
                new Ingredient { Id = 7, Name = "Soğan" },
                new Ingredient { Id = 8, Name = "Sarimsak" },
                new Ingredient { Id = 9, Name = "Hamur" },
                new Ingredient { Id = 10, Name = "Peynir" },
                new Ingredient { Id = 11, Name = "Yumurta" },
                new Ingredient { Id = 12, Name = "Un" },
                new Ingredient { Id = 13, Name = "Yoğurt" },
                new Ingredient { Id = 14, Name = "Tereyaği" },
                new Ingredient { Id = 15, Name = "Baharat" }
            );

            modelBuilder.Entity<DishIngredient>().HasData(
                // Doner Durum
                new DishIngredient { DishId = 1, IngredientId = 1 },
                new DishIngredient { DishId = 1, IngredientId = 2 },
                new DishIngredient { DishId = 1, IngredientId = 3 },
                new DishIngredient { DishId = 1, IngredientId = 4 },
                // Patlican Kebabi
                new DishIngredient { DishId = 2, IngredientId = 5 },
                new DishIngredient { DishId = 2, IngredientId = 6 },
                new DishIngredient { DishId = 2, IngredientId = 3 },
                new DishIngredient { DishId = 2, IngredientId = 4 },
                // Adana Kebap
                new DishIngredient { DishId = 3, IngredientId = 2 },
                new DishIngredient { DishId = 3, IngredientId = 7 },
                new DishIngredient { DishId = 3, IngredientId = 8 },
                new DishIngredient { DishId = 3, IngredientId = 15 },
                // Urfa Kebap
                new DishIngredient { DishId = 4, IngredientId = 2 },
                new DishIngredient { DishId = 4, IngredientId = 7 },
                new DishIngredient { DishId = 4, IngredientId = 8 },
                new DishIngredient { DishId = 4, IngredientId = 15 },
                // Lahmacun
                new DishIngredient { DishId = 5, IngredientId = 9 },
                new DishIngredient { DishId = 5, IngredientId = 6 },
                new DishIngredient { DishId = 5, IngredientId = 3 },
                new DishIngredient { DishId = 5, IngredientId = 7 },
                new DishIngredient { DishId = 5, IngredientId = 8 },
                new DishIngredient { DishId = 5, IngredientId = 15 },
                // Pide
                new DishIngredient { DishId = 6, IngredientId = 9 },
                new DishIngredient { DishId = 6, IngredientId = 10 },
                new DishIngredient { DishId = 6, IngredientId = 11 },
                new DishIngredient { DishId = 6, IngredientId = 2 },
                // Manti
                new DishIngredient { DishId = 7, IngredientId = 12 },
                new DishIngredient { DishId = 7, IngredientId = 6 },
                new DishIngredient { DishId = 7, IngredientId = 7 },
                new DishIngredient { DishId = 7, IngredientId = 8 },
                new DishIngredient { DishId = 7, IngredientId = 13 },
                new DishIngredient { DishId = 7, IngredientId = 14 },
                // Kofte
                new DishIngredient { DishId = 8, IngredientId = 6 },
                new DishIngredient { DishId = 8, IngredientId = 7 },
                new DishIngredient { DishId = 8, IngredientId = 8 },
                new DishIngredient { DishId = 8, IngredientId = 15 }
            );
    }

    public DbSet<Dish> Dishes => Set<Dish>();
    public DbSet<Ingredient> Ingredients => Set<Ingredient>();
    public DbSet<DishIngredient> DishIngredients => Set<DishIngredient>();



}

