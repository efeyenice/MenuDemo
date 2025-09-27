# MenuDemo - ASP.NET MVC Learning Project

A beginner-friendly ASP.NET Core MVC web application that demonstrates a Turkish restaurant menu system with search functionality. This project is designed to help developers learn the fundamentals of ASP.NET MVC, Entity Framework Core, and PostgreSQL database integration.

## 🍽️ Project Overview

MenuDemo is a web application that displays a menu of Turkish dishes with their ingredients, prices, and images. Users can browse the menu, search for specific dishes or ingredients, and view detailed information about each dish.

### Key Features

- **Menu Display**: Browse a collection of Turkish dishes with images and prices
- **Search Functionality**: Search dishes by name or ingredients
- **Advanced Search**: Filter dishes by name, ingredients, and price range
- **Dish Details**: View detailed information about each dish including all ingredients
- **Responsive Design**: Bootstrap-based UI that works on desktop and mobile
- **Database Integration**: PostgreSQL database with Entity Framework Core
- **Docker Support**: Containerized application for easy deployment

## 🏗️ Architecture

This project follows the **Model-View-Controller (MVC)** pattern:

- **Models**: `Dish`, `Ingredient`, `DishIngredient` (many-to-many relationship)
- **Views**: Razor views for displaying menu items and search results
- **Controllers**: `MenuController` handling menu operations and search functionality
- **Data Layer**: Entity Framework Core with PostgreSQL

## 🛠️ Technologies Used

- **.NET 9.0** - Latest .NET framework
- **ASP.NET Core MVC** - Web framework
- **Entity Framework Core 9.0** - ORM for database operations
- **PostgreSQL** - Database
- **Bootstrap 5** - Frontend styling
- **Docker** - Containerization
- **Razor Views** - Server-side rendering

## 📋 Prerequisites

Before running this project, ensure you have:

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) (for containerized setup)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/) (recommended)

## 🚀 Getting Started

### Option 1: Docker Setup (Recommended)

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd MenuDemo
   ```

2. **Start the application with Docker Compose**
   ```bash
   docker-compose up --build
   ```

3. **Access the application**
   - Open your browser and navigate to `http://localhost:5001`
   - The database will be automatically created and seeded with sample data

### Option 2: Local Development Setup

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd MenuDemo
   ```

2. **Set up PostgreSQL database**
   - Install PostgreSQL locally
   - Create a database named `MenuDemo`
   - Update the connection string in `appsettings.json` if needed

3. **Restore dependencies**
   ```bash
   cd MenuDemo
   dotnet restore
   ```

4. **Run database migrations**
   ```bash
   dotnet ef database update
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

6. **Access the application**
   - Open your browser and navigate to `https://localhost:5001` or `http://localhost:5000`

## 📊 Database Schema

The application uses three main entities:

### Dish
- `Id` (Primary Key)
- `Name` (Required)
- `ImageUrl` (Required)
- `Price` (Double)

### Ingredient
- `Id` (Primary Key)
- `Name` (Required)

### DishIngredient (Junction Table)
- `DishId` (Foreign Key)
- `IngredientId` (Foreign Key)

## 🔍 Features Explained

### 1. Menu Display
- Shows all dishes in a responsive card layout
- Each card displays the dish image, name, and price
- "View Details" button navigates to the detailed view

### 2. Search Functionality
- **Simple Search**: Search by dish name or ingredient name
- **Advanced Search**: Filter by multiple criteria:
  - Dish name (partial match)
  - Specific ingredient
  - Price range (minimum and maximum)

### 3. Dish Details
- Shows complete information about a dish
- Lists all ingredients used in the dish
- Displays the dish image and price

## 📁 Project Structure

```
MenuDemo/
├── Controllers/
│   ├── HomeController.cs          # Home page controller
│   └── Menu.cs                    # Menu operations controller
├── Data/
│   └── MenuContext.cs             # Entity Framework DbContext
├── Models/
│   ├── Dish.cs                    # Dish entity model
│   ├── Ingredient.cs              # Ingredient entity model
│   ├── DishIngredient.cs          # Junction table model
│   └── ErrorViewModel.cs          # Error handling model
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml           # Home page
│   │   └── Privacy.cshtml         # Privacy page
│   ├── Menu/
│   │   ├── Index.cshtml           # Menu listing page
│   │   └── Details.cshtml         # Dish details page
│   └── Shared/
│       ├── _Layout.cshtml         # Main layout template
│       └── _ValidationScriptsPartial.cshtml
├── wwwroot/                       # Static files (CSS, JS, images)
├── Migrations/                    # Entity Framework migrations
├── Program.cs                     # Application entry point
└── appsettings.json              # Configuration settings
```

## 🎯 Learning Objectives

This project demonstrates:

1. **MVC Pattern**: Clear separation of concerns between Models, Views, and Controllers
2. **Entity Framework Core**: Database operations, migrations, and relationships
3. **Razor Views**: Server-side rendering with C# code in HTML
4. **Dependency Injection**: Constructor injection for database context
5. **LINQ Queries**: Complex database queries with Entity Framework
6. **Bootstrap Integration**: Responsive web design
7. **Docker Containerization**: Modern deployment practices

## 🔧 Customization Ideas

To extend this project, consider adding:

- **User Authentication**: Login/registration system
- **Shopping Cart**: Add dishes to cart functionality
- **Admin Panel**: CRUD operations for dishes and ingredients
- **Reviews System**: User reviews and ratings
- **Categories**: Organize dishes by categories (appetizers, mains, desserts)
- **API Endpoints**: RESTful API for mobile app integration
- **Image Upload**: Allow admins to upload dish images
- **Localization**: Multi-language support