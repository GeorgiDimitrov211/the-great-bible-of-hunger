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
          new Diet(3, "Gluten-free"),
          new Diet(4, "None")
      );

      modelBuilder.Entity<Rating>().HasData(
          new Rating(1, 232, 5),
          new Rating(2, 156, 4.3),
          new Rating(4, 20, 3.8),
          new Rating(5, 56, 4.1),
          new Rating(6, 32, 2.8),
          new Rating(7, 122, 3.7),
          new Rating(8, 174, 4.9),
          new Rating(9, 10, 5),
          new Rating(10, 87, 4.3)
      );

      modelBuilder.Entity<Cuisine>().HasData(
          new Cuisine(1, "Asian"),
          new Cuisine(2, "Italian"),
          new Cuisine(3, "Indian"),
          new Cuisine(4, "European"),
          new Cuisine(5, "French")
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
          new Ingredient(3, "Potato", "url", "Vegetable"),
          new Ingredient(4, "Onion", "url", "Vegetable"),
          new Ingredient(5, "Asparagus", "url", "Vegetable"),
          new Ingredient(6, "Chilli peppers", "url", "Vegetable"),
          new Ingredient(7, "Lettuce", "url", "Vegetable"),
          new Ingredient(8, "Leeks", "url", "Vegetable"),
          new Ingredient(9, "Eggplant", "url", "Vegetable"),
          new Ingredient(10, "Mushroom", "url", "Fungi"),
          new Ingredient(11, "Peas", "url", "Vegetable"),
          new Ingredient(12, "Pumpkin", "url", "Vegetable"),
          new Ingredient(13, "Pork", "url", "Meat"),
          new Ingredient(14, "Chicken", "url", "Meat"),
          new Ingredient(15, "Beans", "url", "Grain"),
          new Ingredient(16, "Egg", "url", "Egg"),
          new Ingredient(17, "Spahetti", "url", "Pasta"),
          new Ingredient(18, "Macaroni", "url", "Pasta"),
          new Ingredient(19, "Rigatoni", "url", "Pasta"),
          new Ingredient(20, "Asian chile pepper sauce", "url", "Condiment"),
          new Ingredient(21, "Maple syrup", "url", "Condiment"),
          new Ingredient(22, "Soy sauce", "url", "Condiment"),
          new Ingredient(23, "Mayonnaise", "url", "Condiment"),
          new Ingredient(24, "Rice Vinegar", "url", "Condiment"),
          new Ingredient(25, "Salt", "url", "Spice"),
          new Ingredient(26, "Black Pepper", "url", "Spice"),
          new Ingredient(27, "Lime", "url", "Fruit"),
          new Ingredient(28, "Garlic", "url", "Vegetable"),
          new Ingredient(29, "Vegetable oil", "url", "Condiment"),
          new Ingredient(30, "White sugar", "url", "Sweetener"),
          new Ingredient(31, "Molasses", "url", "Sweetener"),
          new Ingredient(32, "Flour", "url", "Grain")
      );

      modelBuilder.Entity<Recipe>().HasData(
          new Recipe(1, 90, 35, "./imagesandicons/food-plate.png", "Rusty Chicken Thighs", 1, 1, 1),
          new Recipe(2, 80, 40, "./imagesandicons/food-plate.png", "Placeholder Dish", 2, 2, 2),
          new Recipe(3, 65, 60, "./imagesandicons/food-plate.png", "Placeholder Dish", 3, 3, 3),
          new Recipe(4, 95, 30, "./imagesandicons/food-plate.png", "Placeholder Dish", 2, 2, 4),
          new Recipe(5, 75, 50, "./imagesandicons/food-plate.png", "Placeholder Dish", 3, 2, 5),
          new Recipe(6, 75, 50, "./imagesandicons/food-plate.png", "Placeholder Dish", 3, 2, 6),
          new Recipe(7, 75, 50, "./imagesandicons/food-plate.png", "Placeholder Dish", 3, 2, 7),
          new Recipe(8, 75, 50, "./imagesandicons/food-plate.png", "Placeholder Dish", 3, 2, 8),
          new Recipe(9, 75, 50, "./imagesandicons/food-plate.png", "Placeholder Dish", 3, 2, 9),
          new Recipe(10, 75, 50, "./imagesandicons/food-plate.png", "Placeholder Dish", 3, 2, 10)
      );

      modelBuilder.Entity<RecipeStep>().HasData(
          new RecipeStep(1, "Mash garlic to a paste with a mortar and pestle. Mix chile pepper sauce, maple syrup, soy sauce, mayonnaise, and rice vinegar into garlic until marinade is thoroughly combined."),
          new RecipeStep(2, "Transfer chicken thighs to a large flat container (such as a baking dish) and pour marinade over chicken; stir until chicken is coated. Cover dish with plastic wrap and refrigerate about 3 hours; if preferred, let stand about 30 minutes at room temperature. Unwrap dish and sprinkle with salt."),
          new RecipeStep(3, "Preheat charcoal grill to high heat."),
          new RecipeStep(4, "Place chicken thighs onto the hot grill with smooth sides down. Cook until chicken shows grill marks, about 3 minutes. Turn chicken over and cook until other side shows grill marks, about 5 minutes. Continue to cook, moving them occasionally and turning over every 2 minutes, until meat is no longer pink inside and the thighs are golden brown, 10 to 12 minutes."),
          new RecipeStep(5, "Transfer chicken to a platter, let rest for 5 minutes, and serve garnished with lime wedges."),
          new RecipeStep(6, "step 6"),
          new RecipeStep(7, "step 7"),
          new RecipeStep(8, "step 8"),
          new RecipeStep(9, "step 9"),
          new RecipeStep(10, "step 10"),
          new RecipeStep(11, "step 11")
        );

      modelBuilder.Entity<RecipeDiet>().HasData(
          new RecipeDiet(4, 1),
          new RecipeDiet(2, 2),
          new RecipeDiet(3, 3),
          new RecipeDiet(3, 4),
          new RecipeDiet(1, 5),
          new RecipeDiet(2, 6),
          new RecipeDiet(3, 7),
          new RecipeDiet(3, 8),
          new RecipeDiet(3, 9),
          new RecipeDiet(3, 10)
      );

      modelBuilder.Entity<RecipeIngredient>().HasData(
        new RecipeIngredient(20, 1),
        new RecipeIngredient(21, 1),
        new RecipeIngredient(22, 1),
        new RecipeIngredient(23, 1),
        new RecipeIngredient(24, 1),
        new RecipeIngredient(25, 1),
        new RecipeIngredient(26, 1),
        new RecipeIngredient(27, 1),
        new RecipeIngredient(28, 1),

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
        new RecipeRecipeStep(1, 1),
        new RecipeRecipeStep(2, 1),
        new RecipeRecipeStep(3, 1),
        new RecipeRecipeStep(4, 1),
        new RecipeRecipeStep(5, 1),

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
