using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api.Models;
using api.Data;


namespace api.Data
{
  public class GBOHContext : DbContext
  {
    public GBOHContext(DbContextOptions<GBOHContext> options) : base(options)
    {

    }
    public DbSet<Cuisine> Cuisines { get; set; }
    public DbSet<Diet> Diets { get; set; }
    public DbSet<DishType> DishTypes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<RecipeDiet> RecipeDiets { get; set; }
    public DbSet<RecipeRecipeStep> RecipeRecipeSteps { get; set; }
    public DbSet<RecipeIngredient> RecipeIngredients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Cuisine>().ToTable("Cuisine");
      modelBuilder.Entity<Diet>().ToTable("Diet");
      modelBuilder.Entity<DishType>().ToTable("DishType");
      modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
      modelBuilder.Entity<Rating>().ToTable("Rating");
      modelBuilder.Entity<Recipe>().ToTable("Recipe");

      modelBuilder.Entity<RecipeDiet>()
          .HasKey(rd => new { rd.RecipeId, rd.DietId });
      modelBuilder.Entity<RecipeDiet>()
          .HasOne(rd => rd.Recipe)
          .WithMany(r => r.RecipeDiets)
          .HasForeignKey(rd => rd.RecipeId);
      modelBuilder.Entity<RecipeDiet>()
          .HasOne(rd => rd.Diet)
          .WithMany(d => d.RecipeDiets)
          .HasForeignKey(rd => rd.DietId);

      modelBuilder.Entity<RecipeRecipeStep>()
          .HasKey(rrs => new { rrs.RecipeStepId, rrs.RecipeId });
      modelBuilder.Entity<RecipeRecipeStep>()
          .HasOne(rd => rd.Recipe)
          .WithMany(r => r.RecipeRecipeSteps)
          .HasForeignKey(rd => rd.RecipeId);
      modelBuilder.Entity<RecipeRecipeStep>()
          .HasOne(rd => rd.RecipeStep)
          .WithMany(d => d.RecipeRecipeSteps)
          .HasForeignKey(rd => rd.RecipeStepId);

      modelBuilder.Entity<RecipeIngredient>()
          .HasKey(ri => new { ri.IngredientId, ri.RecipeId });
      modelBuilder.Entity<RecipeIngredient>()
          .HasOne(rd => rd.Recipe)
          .WithMany(r => r.RecipeIngredients)
          .HasForeignKey(rd => rd.RecipeId);
      modelBuilder.Entity<RecipeIngredient>()
          .HasOne(rd => rd.Ingredient)
          .WithMany(d => d.RecipeIngredients)
          .HasForeignKey(rd => rd.IngredientId);

      modelBuilder.Entity<Diet>().HasData(
          new Diet(1, "Vegan"),
          new Diet(2, "Vegetarian"),
          new Diet(3, "Gluten-free")
      );

      modelBuilder.Entity<Rating>().HasData(
          new Rating(1, 232, 5),
          new Rating(2, 156, 4.3),
          new Rating(3, 20, 3.8)
      );

      modelBuilder.Entity<Cuisine>().HasData(
          new Cuisine(1, "Asian"),
          new Cuisine(2, "Italian"),
          new Cuisine(3, "Indian")
      );


      modelBuilder.Entity<DishType>().HasData(
          new DishType(1, "Breakfast"),
          new DishType(2, "Dinner"),
          new DishType(3, "Lunch"),
          new DishType(4, "Dessert")
      );

      modelBuilder.Entity<Ingredient>().HasData(
          new Ingredient(1, "Tomato", "url", "Vegetable"),
          new Ingredient(2, "Cucumber", "url", "Vegetable"),
          new Ingredient(3, "Pork", "url", "Meat"),
          new Ingredient(4, "Potato", "url", "Vegetable"),
          new Ingredient(5, "Onion", "url", "Vegetable"),
          new Ingredient(6, "Asparagus", "url", "Vegetable"),
          new Ingredient(7, "Chilli peppers", "url", "Vegetable"),
          new Ingredient(8, "Lettuce", "url", "Vegetable"),
          new Ingredient(9, "Leeks", "url", "Vegetable"),
          new Ingredient(10, "Eggplant", "url", "Vegetable"),
          new Ingredient(11, "Mushrooms", "url", "Vegetable"),
          new Ingredient(12, "Peas", "url", "Vegetable"),
          new Ingredient(13, "Pumpkin", "url", "Vegetable"),
          new Ingredient(14, "Beans", "url", "Grain"),
          new Ingredient(15, "Lasagne", "url", "Pasta"),
          new Ingredient(16, "Spahetti", "url", "Pasta"),
          new Ingredient(17, "Macaroni", "url", "Pasta"),
          new Ingredient(18, "Rigatoni", "url", "Pasta")
      );

      modelBuilder.Entity<Recipe>().HasData(
          new Recipe(1, 70, 20, "https://via.placeholder.com/150", "Placeholder Dish", 1, 1, 1),
          new Recipe(2, 80, 40, "https://via.placeholder.com/150", "Placeholder Dish", 2, 2, 3),
          new Recipe(3, 65, 60, "https://via.placeholder.com/150", "Placeholder Dish", 3, 3, 1),
          new Recipe(4, 95, 30, "https://via.placeholder.com/150", "Placeholder Dish", 2, 2, 1),
          new Recipe(5, 75, 50, "https://via.placeholder.com/150", "Placeholder Dish", 3, 2, 2)
      );

      modelBuilder.Entity<RecipeStep>().HasData(
          new RecipeStep(1, "step 1"),
          new RecipeStep(2, "step 2"),
          new RecipeStep(3, "step 3"),
          new RecipeStep(4, "step 4"),
          new RecipeStep(5, "step 5"),
          new RecipeStep(6, "step 6"),
          new RecipeStep(7, "step 7"),
          new RecipeStep(8, "step 8"),
          new RecipeStep(9, "step 9"),
          new RecipeStep(10, "step 10"),
          new RecipeStep(11, "step 11")
        );

      modelBuilder.Entity<RecipeDiet>().HasData(
          new RecipeDiet(1, 1),
          new RecipeDiet(2, 2),
          new RecipeDiet(3, 3),
          new RecipeDiet(3, 2)
      );

      modelBuilder.Entity<RecipeIngredient>().HasData(
        new RecipeIngredient(1, 1),
        new RecipeIngredient(10, 1),
        new RecipeIngredient(11, 1),
        new RecipeIngredient(8, 1),
        new RecipeIngredient(3, 1),
        new RecipeIngredient(9, 1),
        new RecipeIngredient(4, 1),
        new RecipeIngredient(15, 1),

        new RecipeIngredient(1, 2),
        new RecipeIngredient(17, 2),
        new RecipeIngredient(12, 2),
        new RecipeIngredient(5, 2),

        new RecipeIngredient(3, 3),
        new RecipeIngredient(2, 3),
        new RecipeIngredient(5, 3),
        new RecipeIngredient(8, 3),
        new RecipeIngredient(4, 3),
        new RecipeIngredient(10, 3),

        new RecipeIngredient(4, 4),
        new RecipeIngredient(7, 4),
        new RecipeIngredient(9, 4),
        new RecipeIngredient(8, 4),
        new RecipeIngredient(12, 4),

        new RecipeIngredient(3, 5),
        new RecipeIngredient(2, 5),
        new RecipeIngredient(6, 5),
        new RecipeIngredient(9, 5),
        new RecipeIngredient(12, 5),
        new RecipeIngredient(11, 5),
        new RecipeIngredient(17, 5)
    );

      modelBuilder.Entity<RecipeRecipeStep>().HasData(
        new RecipeRecipeStep(3, 1),
        new RecipeRecipeStep(5, 1),
        new RecipeRecipeStep(6, 1),
        new RecipeRecipeStep(10, 1),
        new RecipeRecipeStep(11, 1),

        new RecipeRecipeStep(1, 2),
        new RecipeRecipeStep(3, 2),
        new RecipeRecipeStep(2, 2),
        new RecipeRecipeStep(5, 2),
        new RecipeRecipeStep(7, 2),

        new RecipeRecipeStep(2, 3),
        new RecipeRecipeStep(4, 3),
        new RecipeRecipeStep(3, 3),
        new RecipeRecipeStep(9, 3),

        new RecipeRecipeStep(10, 4),
        new RecipeRecipeStep(7, 4),
        new RecipeRecipeStep(6, 4),

        new RecipeRecipeStep(1, 5),
        new RecipeRecipeStep(3, 5),
        new RecipeRecipeStep(6, 5),
        new RecipeRecipeStep(9, 5),
        new RecipeRecipeStep(10, 5),
        new RecipeRecipeStep(7, 5)

      );
    }
  }
}
