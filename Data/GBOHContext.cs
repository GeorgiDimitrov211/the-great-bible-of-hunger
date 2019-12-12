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
          new Rating(3, 33, 4.2),
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
          new DishType(4, "Dessert"),
          new DishType(5, "Salad")
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
          new Ingredient(32, "Flour", "url", "Grain"),
          new Ingredient(33, "Baking Powder", "url", "Food additive"),
          new Ingredient(34, "Ground Cinnamon", "url", "Spice"),
          new Ingredient(35, "Ground Cloves", "url", "Spice"),
          new Ingredient(36, "Ground Nutmeg", "url", "Spice"),
          new Ingredient(37, "Ground Ginger", "url", "Spice"),
          new Ingredient(38, "Baking Soda", "url", "Food additive"),
          new Ingredient(39, "Butter", "url", "Dairy"),
          new Ingredient(40, "Milk", "url", "Dairy"),
          new Ingredient(41, "Cranberry", "url", "Fruit"),
          new Ingredient(42, "Vanilla", "url", "Spice"),
          new Ingredient(43, "Whipping Cream", "url", "Topping"),
          new Ingredient(44, "Cabbage", "url", "Vegetable"),
          new Ingredient(45, "Jalapeno", "url", "Spice"),
          new Ingredient(46, "Red onion", "url", "Vegetable"),
          new Ingredient(47, "Carrot", "url", "Vegetable"),
          new Ingredient(48, "Coriander", "url", "Spice"),
          new Ingredient(49, "Bacon", "url", "Meat"),
          new Ingredient(50, "Cheese", "url", "Diary"),
          new Ingredient(51, "Pork sausage", "url", "Meat"),
          new Ingredient(52, "Refrigerated Roll Dough", "url", "Grain"),
          new Ingredient(53, "Mozarrella", "url", "Diary"),
          new Ingredient(54, "Cheddar", "url", "Diary"),
          new Ingredient(55, "Oregano", "url", "Spice"),
          new Ingredient(56, "Bread", "url", "Grain"),
          new Ingredient(57, "Celery", "url", "Vegetable"),
          new Ingredient(58, "Paprika", "url", "Grain"),
          new Ingredient(59, "Hot pepper sauce", "url", "Spice"),
          new Ingredient(60, "Beef", "url", "Spice"),
          new Ingredient(61, "Thousand Island", "url", "Topping"),
          new Ingredient(62, "Sauerkraut", "url", "Side dish"),
          new Ingredient(63, "Condensed Cream of Chicken soup", "url", "Side dish"),
          new Ingredient(64, "Refrigerated Biscuit Dough", "url", "Grain")
      );

      modelBuilder.Entity<Recipe>().HasData(
          new Recipe(1, 90, 35, "./imagesandicons/food-plate.png", "Rusty Chicken Thighs", 1, 2, 1),
          new Recipe(2, 80, 65, "./imagesandicons/food-plate.png", "Gingerbread Biscotti", 2, 4, 2),
          new Recipe(3, 120, 120, "./imagesandicons/food-plate.png", "Fresh Cranberry Cake", 3, 4, 3),
          new Recipe(4, 50, 20, "./imagesandicons/food-plate.png", "Taco Slaw", 4, 5, 4),
          new Recipe(5, 75, 50, "./imagesandicons/food-plate.png", "Quick Quiche", 3, 1, 5),
          new Recipe(6, 70, 50, "./imagesandicons/food-plate.png", "Egg and Sausage Casserole", 2, 1, 6),
          new Recipe(7, 40, 5, "./imagesandicons/food-plate.png", "Spicy Grilled Cheese Sandwich", 3, 3, 7),
          new Recipe(8, 110, 45, "./imagesandicons/food-plate.png", "Di's Delicious Deluxe Deviled Eggs", 5, 3, 8),
          new Recipe(9, 60, 25, "./imagesandicons/food-plate.png", "Reuben Sandwich II", 1, 3, 9),
          new Recipe(10, 95, 300, "./imagesandicons/food-plate.png", "Slow Cooker Chicken and Dumplings", 2, 4, 10)
      );

      modelBuilder.Entity<RecipeStep>().HasData(
          new RecipeStep(1, "Mash garlic to a paste with a mortar and pestle. Mix chile pepper sauce, maple syrup, soy sauce, mayonnaise, and rice vinegar into garlic until marinade is thoroughly combined."),
          new RecipeStep(2, "Transfer chicken thighs to a large flat container (such as a baking dish) and pour marinade over chicken; stir until chicken is coated. Cover dish with plastic wrap and refrigerate about 3 hours; if preferred, let stand about 30 minutes at room temperature. Unwrap dish and sprinkle with salt."),
          new RecipeStep(3, "Preheat charcoal grill to high heat."),
          new RecipeStep(4, "Place chicken thighs onto the hot grill with smooth sides down. Cook until chicken shows grill marks, about 3 minutes. Turn chicken over and cook until other side shows grill marks, about 5 minutes. Continue to cook, moving them occasionally and turning over every 2 minutes, until meat is no longer pink inside and the thighs are golden brown, 10 to 12 minutes."),
          new RecipeStep(5, "Transfer chicken to a platter, let rest for 5 minutes, and serve garnished with lime wedges."),

          new RecipeStep(6, "Preheat the oven to 375 degrees F (190 degrees C). Grease a cookie sheet."),
          new RecipeStep(7, "In a large bowl, mix together oil, sugar, eggs, and molasses. In another bowl, combine flours, baking powder, ginger, cinnamon, cloves, and nutmeg; mix into egg mixture to form a stiff dough."),
          new RecipeStep(8, "Divide dough in half, and shape each half into a roll the length of the cookie. Place rolls on cookie sheet, and pat down to flatten the dough to 1/2 inch thickness"),
          new RecipeStep(9, "Bake in preheated oven for 25 minutes. Remove from oven, and set aside to cool."),
          new RecipeStep(10, "When cool enough to touch, cut into 1/2 inch thick diagonal slices. Place sliced biscotti on cookie sheet, and bake an additional 5 to 7 minutes on each side, or until toasted and crispy."),

          new RecipeStep(11, "Preheat oven to 350 degrees F (175 degrees C). Grease a 9x13-inch baking dish."),
          new RecipeStep(12, "Combine flour, baking soda, and salt in a bowl. Beat 1 cup sugar and 3 tablespoons melted butter with a whisk until well mixed. Add eggs and beat until smooth. Stir flour mixture and milk into egg mixture until batter is well blended. Fold cranberries into batter until just mixed and pour into prepared baking dish."),
          new RecipeStep(13, "Bake in the preheated oven until a toothpick inserted into the center comes out clean, about 30 minutes."),
          new RecipeStep(14, "For sauce, heat 1 cup sugar, 1/2 cup butter, heavy cream, and vanilla extract in a saucepan over medium-low heat; cook and stir cream sauce until sugar is dissolved, about 10 minutes. Pour hot sauce over hot cake. Allow cake to cool in the baking dish for 10 minutes before removing to cool completely on a wire rack."),

          new RecipeStep(15, "In a bowl, mix together the cabbage, jalapeno pepper, red onion, carrot, cilantro, and lime juice."),

          new RecipeStep(16, "Place bacon in a large, deep skillet. Cook over medium high heat until evenly brown. Drain, crumble and set aside."),
          new RecipeStep(17, "Preheat oven to 350 degrees F (175 degrees C). Lightly grease a 9 inch pie pan."),
          new RecipeStep(18, "Line bottom of pie plate with cheese and crumbled bacon. Combine eggs, butter, onion, salt, flour and milk; whisk together until smooth; pour into pie pan."),
          new RecipeStep(19, "Bake in preheated oven for 35 minutes, until set. Serve hot or cold."),

          new RecipeStep(20, "Heat a large skillet over low heat. Spread butter or margarine onto one side of two slices of bread. Place both pieces buttered side down in the skillet. Lay a slice of cheese on each one, and top with slices of tomato, onion and jalapeno. Butter one side of the remaining slices of bread, and place on top buttered side up. When the bottom of the sandwiches are toasted, flip and fry until brown on the other side."),

          new RecipeStep(21, "Place eggs in a medium saucepan and cover with cold water. Bring water to a boil and immediately remove from heat. Cover and let eggs stand in hot water for 10 to 12 minutes. Remove from hot water, cool and peel."),
          new RecipeStep(22, "Cut eggs in half. Remove yolks and place in a medium bowl. Mash together with celery, onion, mayonnaise, salt and hot pepper sauce."),
          new RecipeStep(23, "Stuff the egg white halves with the egg yolk mixture. Sprinkle eggs with paprika. Chill covered in the refrigerator until serving."),

          new RecipeStep(24, "Preheat a large skillet or griddle on medium heat."),
          new RecipeStep(25, "Lightly butter one side of bread slices. Spread non-buttered sides with Thousand Island dressing. On 4 bread slices, layer 1 slice Swiss cheese, 2 slices corned beef, 1/4 cup sauerkraut and second slice of Swiss cheese. Top with remaining bread slices, buttered sides out."),
          new RecipeStep(26, "Grill sandwiches until both sides are golden brown, about 5 minutes per side. Serve hot."),

          new RecipeStep(27, "Place the chicken, butter, soup, and onion in a slow cooker, and fill with enough water to cover."),
          new RecipeStep(28, "Cover, and cook for 5 to 6 hours on High. About 30 minutes before serving, place the torn biscuit dough in the slow cooker. Cook until the dough is no longer raw in the center.")
        );

      modelBuilder.Entity<RecipeDiet>().HasData(
          new RecipeDiet(4, 1),
          new RecipeDiet(4, 2),
          new RecipeDiet(4, 3),
          new RecipeDiet(4, 4),
          new RecipeDiet(4, 5),
          new RecipeDiet(4, 6),
          new RecipeDiet(4, 7),
          new RecipeDiet(4, 8),
          new RecipeDiet(4, 9),
          new RecipeDiet(4, 10)
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

        new RecipeIngredient(16, 2),
        new RecipeIngredient(29, 2),
        new RecipeIngredient(30, 2),
        new RecipeIngredient(31, 2),
        new RecipeIngredient(32, 2),
        new RecipeIngredient(33, 2),
        new RecipeIngredient(34, 2),
        new RecipeIngredient(35, 2),
        new RecipeIngredient(36, 2),
        new RecipeIngredient(37, 2),

        new RecipeIngredient(32, 3),
        new RecipeIngredient(38, 3),
        new RecipeIngredient(25, 3),
        new RecipeIngredient(30, 3),
        new RecipeIngredient(39, 3),
        new RecipeIngredient(16, 3),
        new RecipeIngredient(40, 3),
        new RecipeIngredient(41, 3),
        new RecipeIngredient(42, 3),
        new RecipeIngredient(43, 3),

        new RecipeIngredient(27, 4),
        new RecipeIngredient(44, 4),
        new RecipeIngredient(45, 4),
        new RecipeIngredient(46, 4),
        new RecipeIngredient(47, 4),
        new RecipeIngredient(48, 4),

        new RecipeIngredient(49, 5),
        new RecipeIngredient(50, 5),
        new RecipeIngredient(16, 5),
        new RecipeIngredient(39, 5),
        new RecipeIngredient(4, 5),
        new RecipeIngredient(25, 5),
        new RecipeIngredient(32, 5),
        new RecipeIngredient(40, 5),

        new RecipeIngredient(16, 6),
        new RecipeIngredient(51, 6),
        new RecipeIngredient(52, 6),
        new RecipeIngredient(53, 6),
        new RecipeIngredient(54, 6),
        new RecipeIngredient(55, 6),

        new RecipeIngredient(39, 7),
        new RecipeIngredient(56, 7),
        new RecipeIngredient(1, 7),
        new RecipeIngredient(50, 7),
        new RecipeIngredient(4, 7),
        new RecipeIngredient(45, 7),

        new RecipeIngredient(16, 8),
        new RecipeIngredient(57, 8),
        new RecipeIngredient(4, 8),
        new RecipeIngredient(23, 8),
        new RecipeIngredient(25, 8),
        new RecipeIngredient(59, 8),
        new RecipeIngredient(58, 8),

        new RecipeIngredient(39, 9),
        new RecipeIngredient(56, 9),
        new RecipeIngredient(50, 9),
        new RecipeIngredient(60, 9),
        new RecipeIngredient(61, 9),
        new RecipeIngredient(62, 9),

        new RecipeIngredient(39, 10),
        new RecipeIngredient(14, 10),
        new RecipeIngredient(4, 10),
        new RecipeIngredient(63, 10),
        new RecipeIngredient(64, 10)
    );

      modelBuilder.Entity<RecipeRecipeStep>().HasData(
        new RecipeRecipeStep(1, 1),
        new RecipeRecipeStep(2, 1),
        new RecipeRecipeStep(3, 1),
        new RecipeRecipeStep(4, 1),
        new RecipeRecipeStep(5, 1),

        new RecipeRecipeStep(6, 2),
        new RecipeRecipeStep(7, 2),
        new RecipeRecipeStep(8, 2),
        new RecipeRecipeStep(9, 2),
        new RecipeRecipeStep(10, 2),

        new RecipeRecipeStep(11, 3),
        new RecipeRecipeStep(12, 3),
        new RecipeRecipeStep(13, 3),
        new RecipeRecipeStep(14, 3),

        new RecipeRecipeStep(15, 4),

        new RecipeRecipeStep(16, 6),
        new RecipeRecipeStep(17, 6),
        new RecipeRecipeStep(18, 6),
        new RecipeRecipeStep(19, 6),

        new RecipeRecipeStep(20, 7),

        new RecipeRecipeStep(21, 8),
        new RecipeRecipeStep(22, 8),
        new RecipeRecipeStep(23, 8),

        new RecipeRecipeStep(24, 9),
        new RecipeRecipeStep(25, 9),
        new RecipeRecipeStep(26, 9),

        new RecipeRecipeStep(27, 10),
        new RecipeRecipeStep(28, 10)
      );
    }
  }
}
