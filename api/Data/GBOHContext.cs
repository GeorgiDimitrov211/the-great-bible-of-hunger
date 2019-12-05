using System;
using Microsoft.EntityFrameworkCore;
using tboh_api.Models;
using tboh_api.Data;


namespace tboh_api.Data {
    public class GBOHContext : DbContext {
        public GBOHContext(DbContextOptions<GBOHContext> options) : base(options) {

        }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<DishType> DishTypes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Recipe> Recipes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Cuisine>().ToTable("Cuisine");
            modelBuilder.Entity<Diet>().ToTable("Diet");
            modelBuilder.Entity<DishType>().ToTable("DishType");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
            modelBuilder.Entity<Rating>().ToTable("Rating");
            modelBuilder.Entity<Recipe>().ToTable("Recipe");

            modelBuilder.Entity<Diet>().HasData(
                new Diet { DietID = 1, Name = "Vegan" },
                new Diet { DietID = 2, Name = "Vegetarian" },
                new Diet { DietID = 3, Name = "Gluten-free" }
            );

            modelBuilder.Entity<Rating>().HasData(
                new Rating { RatingID = 1, ReviewsNumber = 1, Stars = 5 },
                new Rating { RatingID = 2, ReviewsNumber = 156, Stars = 4.3 },
                new Rating { RatingID = 3, ReviewsNumber = 20, Stars = 3.8 }
            );

            modelBuilder.Entity<Rating>().HasMany(r => r.Recipes).WithOne(r => r.Rating);

            modelBuilder.Entity<Cuisine>().HasData(

                new Cuisine { CuisineID = 1, Name = "Asian" },
                new Cuisine { CuisineID = 2, Name = "Italian" },
                new Cuisine { CuisineID = 3, Name = "Indian" }
            );

            modelBuilder.Entity<Cuisine>().HasMany(c => c.Recipes).WithOne(c => c.Cuisine);


            modelBuilder.Entity<DishType>().HasData(
                new DishType { DishTypeID = 1, Name = "Breakfast" },
                new DishType { DishTypeID = 2, Name = "Dinner" },
                new DishType { DishTypeID = 3, Name = "Lunch" },
                new DishType { DishTypeID = 4, Name = "Dessert" }
            );
            modelBuilder.Entity<DishType>().HasMany(d => d.Recipes).WithOne(d => d.DishType);


            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { IngredientID = 1, Name = "Tomato", ImageURL = "", Type = "Vegetable" },
                new Ingredient { IngredientID = 2, Name = "Cucumber", ImageURL = "", Type = "Vegetable" },
                new Ingredient { IngredientID = 3, Name = "Pork", ImageURL = "", Type = "Meat" },
                new Ingredient { IngredientID = 4, Name = "Spaghetti", ImageURL = "", Type = "Pasta" },
                new Ingredient { IngredientID = 5, Name = "Rise", ImageURL = "", Type = "Grain" }
            );

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe { RecipeID = 1, ImageURL = "https://via.placeholder.com/150", Price = 70, Time = 20, Title = "Placeholder dish", CuisineID = 1, RatingID = 1, DishTypeID = 1 },
                new Recipe { RecipeID = 2, ImageURL = "https://via.placeholder.com/150", Price = 80, Time = 40, Title = "Placeholder dish", CuisineID = 2, RatingID = 2, DishTypeID = 3 },
                new Recipe { RecipeID = 3, ImageURL = "https://via.placeholder.com/150", Price = 65, Time = 60, Title = "Placeholder dish", CuisineID = 3, RatingID = 3, DishTypeID = 4 }
            );

            modelBuilder.Entity<RecipeDiet>()
                .HasKey(rd => new { rd.DietID, rd.RecipeID });

            modelBuilder.Entity<RecipeDiet>()
                .HasOne(diet => diet.Diet)
                .WithMany(recipe => recipe.RecipeDiets)
                .HasForeignKey(rd => rd.DietID);
            modelBuilder.Entity<RecipeDiet>()
                .HasOne(recipe => recipe.Recipe)
                .WithMany(diet => diet.RecipeDiets)
                .HasForeignKey(rd => rd.RecipeID);

            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.IngredientID, ri.RecipeID });

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ingredient => ingredient.Ingredient)
                .WithMany(recipe => recipe.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientID);
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(recipe => recipe.Recipe)
                .WithMany(ing => ing.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeID);
        }
    }
}
