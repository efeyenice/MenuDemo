# 🗃️ Entity Framework Migrations Cheat Sheet

## 📋 Essential Commands

### Creating Migrations
```bash
# Create a new migration
dotnet ef migrations add [MigrationName]

# Examples with good naming:
dotnet ef migrations add AddUserTable
dotnet ef migrations add UpdateDishPriceColumn
dotnet ef migrations add AddCategorySeedData
dotnet ef migrations add RemoveObsoleteFields
dotnet ef migrations add AddIndexToUserEmail
```

### Applying Migrations
```bash
# Update database to latest migration
dotnet ef database update

# Update to specific migration
dotnet ef database update [MigrationName]
dotnet ef database update InitialCreate

# Update to specific migration by timestamp
dotnet ef database update 20250925130538_InitialCreate
```

### Managing Migrations
```bash
# Remove the last migration (ONLY if not applied to database yet)
dotnet ef migrations remove

# List all migrations and their status
dotnet ef migrations list

# Generate SQL script for all migrations
dotnet ef migrations script

# Generate SQL script from specific migration to another
dotnet ef migrations script FromMigration ToMigration

# Generate SQL script for specific migration only
dotnet ef migrations script --idempotent
```

### Database Operations
```bash
# Drop the entire database (⚠️ DESTRUCTIVE!)
dotnet ef database drop

# Force drop without confirmation
dotnet ef database drop --force

# Get database connection info
dotnet ef dbcontext info

# List all DbContext classes
dotnet ef dbcontext list
```

## 🔄 Development Workflow

### Standard Development Cycle
1. **Make model changes** in your C# classes (`Models/` folder)
2. **Build project**: `dotnet build` (fix any compilation errors)
3. **Create migration**: `dotnet ef migrations add [DescriptiveName]`
4. **Apply migration**: 
   - Automatic: Restart your Docker containers
   - Manual: `dotnet ef database update`
5. **Test your changes**

### Your Project's Auto-Migration Setup
Since your `Program.cs` has:
```csharp
context.Database.Migrate();
```
**Migrations apply automatically when you restart your app!**

## 🎯 Migration Naming Best Practices

### ✅ Good Names
- `AddUserTable` - Clear action and target
- `UpdateDishPriceToDecimal` - Specific change
- `AddCategoryForeignKeyToDish` - Detailed relationship change
- `RemoveObsoleteUserFields` - Clear cleanup action
- `AddIndexToEmailColumn` - Performance improvement
- `SeedInitialCategories` - Data seeding

### ❌ Bad Names
- `Update1` - Too generic
- `Fix` - What are you fixing?
- `Changes` - What changes?
- `NewStuff` - Not descriptive
- `Migration2` - Meaningless numbering

## 🛠️ Common Development Scenarios

### Scenario 1: Adding a New Property
```csharp
// 1. Update your model
public class Dish
{
    // existing properties...
    public string? Description { get; set; } // NEW
}

// 2. Create migration
// dotnet ef migrations add AddDescriptionToDish

// 3. Restart containers or run update
```

### Scenario 2: Adding a New Table
```csharp
// 1. Create new model
public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
}

// 2. Add to MenuContext
public DbSet<Category> Categories => Set<Category>();

// 3. Create migration
// dotnet ef migrations add AddCategoryTable
```

### Scenario 3: Adding Relationships
```csharp
// 1. Update models
public class Dish
{
    // existing properties...
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public List<Dish>? Dishes { get; set; } = new();
}

// 2. Configure in MenuContext
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Dish>()
        .HasOne(d => d.Category)
        .WithMany(c => c.Dishes)
        .HasForeignKey(d => d.CategoryId);
}

// 3. Create migration
// dotnet ef migrations add AddCategoryToDishRelationship
```

### Scenario 4: Adding Seed Data
```csharp
// 1. Update MenuContext.cs
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    // existing configuration...
    
    modelBuilder.Entity<Category>().HasData(
        new Category { Id = 1, Name = "Main Dishes" },
        new Category { Id = 2, Name = "Appetizers" }
    );
}

// 2. Create migration
// dotnet ef migrations add AddCategorySeedData
```

## 🚨 Docker-Specific Commands

### Database Inspection (Your Project)
```bash
# Connect to PostgreSQL in container
docker-compose exec postgres psql -U postgres -d MenuDemo

# List all tables
docker-compose exec postgres psql -U postgres -d MenuDemo -c "\dt"

# Check migration history
docker-compose exec postgres psql -U postgres -d MenuDemo -c "SELECT * FROM \"__EFMigrationsHistory\" ORDER BY \"MigrationId\";"

# View table structure
docker-compose exec postgres psql -U postgres -d MenuDemo -c "\d \"Dishes\""

# Check seed data
docker-compose exec postgres psql -U postgres -d MenuDemo -c "SELECT * FROM \"Dishes\";"
```

### Container Restart Workflow
```bash
# Stop containers and remove volumes (fresh start)
docker-compose down --volumes

# Build and start (applies migrations automatically)
docker-compose up --build

# Or just restart without rebuild
docker-compose restart web
```

## ⚠️ Troubleshooting

### Common Issues & Solutions

#### "Build failed" when creating migration
```bash
# Fix compilation errors first
dotnet build
# Then create migration
dotnet ef migrations add YourMigrationName
```

#### "Pending model changes" error
```bash
# You have model changes not captured in migrations
dotnet ef migrations add CaptureModelChanges
```

#### "Migration already applied" 
```bash
# Check migration status
dotnet ef migrations list
# Remove last migration if not needed
dotnet ef migrations remove
```

#### Connection string issues
```bash
# Check your connection string in appsettings.json or docker-compose.yml
# Verify database is running
docker-compose ps
```

### Reset Everything (⚠️ Development Only!)
```bash
# DANGER: This deletes ALL data!
docker-compose down --volumes
cd MenuDemo
dotnet ef database drop --force
rm -rf Migrations/
dotnet ef migrations add InitialCreate
cd ..
docker-compose up --build
```

## 📊 Useful Queries for Your Project

### Check Your Current Setup
```bash
# See all your tables
docker-compose exec postgres psql -U postgres -d MenuDemo -c "SELECT tablename FROM pg_tables WHERE schemaname = 'public';"

# Count records in each table
docker-compose exec postgres psql -U postgres -d MenuDemo -c "
SELECT 
    'Dishes' as table_name, COUNT(*) as count FROM \"Dishes\"
UNION ALL
SELECT 
    'Ingredients' as table_name, COUNT(*) as count FROM \"Ingredients\"
UNION ALL
SELECT 
    'DishIngredients' as table_name, COUNT(*) as count FROM \"DishIngredients\";
"

# See dish-ingredient relationships
docker-compose exec postgres psql -U postgres -d MenuDemo -c "
SELECT 
    d.\"Name\" as dish_name, 
    i.\"Name\" as ingredient_name
FROM \"DishIngredients\" di
JOIN \"Dishes\" d ON di.\"DishId\" = d.\"Id\"
JOIN \"Ingredients\" i ON di.\"IngredientId\" = i.\"Id\"
ORDER BY d.\"Name\", i.\"Name\";
"
```

## 🎯 Pro Tips

1. **Always build before creating migrations**: `dotnet build`
2. **Use descriptive names**: Future you will thank you
3. **One logical change per migration**: Don't bundle unrelated changes
4. **Test migrations on sample data**: Especially with data transformations
5. **Keep migrations small**: Easier to debug and rollback
6. **Never edit applied migrations**: Create new ones instead
7. **Backup before production migrations**: Always!

## 📚 Quick Reference

| Task | Command |
|------|---------|
| Create migration | `dotnet ef migrations add [Name]` |
| Apply migrations | `dotnet ef database update` |
| Remove last migration | `dotnet ef migrations remove` |
| List migrations | `dotnet ef migrations list` |
| Generate SQL | `dotnet ef migrations script` |
| Drop database | `dotnet ef database drop` |
| Reset containers | `docker-compose down --volumes && docker-compose up --build` |

---
*Keep this cheat sheet handy for your MenuDemo project development! 🚀*
