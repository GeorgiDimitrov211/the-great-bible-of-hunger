using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class UpdatingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuisine",
                columns: table => new
                {
                    CuisineId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisine", x => x.CuisineId);
                });

            migrationBuilder.CreateTable(
                name: "Diet",
                columns: table => new
                {
                    DietId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diet", x => x.DietId);
                });

            migrationBuilder.CreateTable(
                name: "DishType",
                columns: table => new
                {
                    DishTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishType", x => x.DishTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewsNumber = table.Column<int>(nullable: false),
                    Stars = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingId);
                });

            migrationBuilder.CreateTable(
                name: "RecipeStep",
                columns: table => new
                {
                    RecipeStepId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RecipeStepDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeStep", x => x.RecipeStepId);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    CuisineId = table.Column<int>(nullable: false),
                    DishTypeId = table.Column<int>(nullable: false),
                    RatingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipe_Cuisine_CuisineId",
                        column: x => x.CuisineId,
                        principalTable: "Cuisine",
                        principalColumn: "CuisineId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipe_DishType_DishTypeId",
                        column: x => x.DishTypeId,
                        principalTable: "DishType",
                        principalColumn: "DishTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipe_Rating_RatingId",
                        column: x => x.RatingId,
                        principalTable: "Rating",
                        principalColumn: "RatingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDiets",
                columns: table => new
                {
                    DietId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDiets", x => new { x.RecipeId, x.DietId });
                    table.ForeignKey(
                        name: "FK_RecipeDiets_Diet_DietId",
                        column: x => x.DietId,
                        principalTable: "Diet",
                        principalColumn: "DietId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeDiets_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.IngredientId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredient",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeRecipeSteps",
                columns: table => new
                {
                    RecipeStepId = table.Column<int>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeRecipeSteps", x => new { x.RecipeStepId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_RecipeRecipeSteps_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipe",
                        principalColumn: "RecipeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeRecipeSteps_RecipeStep_RecipeStepId",
                        column: x => x.RecipeStepId,
                        principalTable: "RecipeStep",
                        principalColumn: "RecipeStepId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cuisine",
                columns: new[] { "CuisineId", "Name" },
                values: new object[,]
                {
                    { 1, "Asian" },
                    { 2, "Italian" },
                    { 3, "Indian" },
                    { 4, "European" },
                    { 5, "French" }
                });

            migrationBuilder.InsertData(
                table: "Diet",
                columns: new[] { "DietId", "Name" },
                values: new object[,]
                {
                    { 1, "Vegan" },
                    { 2, "Vegetarian" },
                    { 3, "Gluten-free" },
                    { 4, "None" }
                });

            migrationBuilder.InsertData(
                table: "DishType",
                columns: new[] { "DishTypeId", "Name" },
                values: new object[,]
                {
                    { 4, "Dessert" },
                    { 3, "Lunch" },
                    { 5, "Salad" },
                    { 1, "Breakfast" },
                    { 2, "Dinner" }
                });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "IngredientId", "ImageURL", "Name", "Type" },
                values: new object[,]
                {
                    { 48, "url", "Coriander", "Spice" },
                    { 35, "url", "Ground Cloves", "Spice" },
                    { 36, "url", "Ground Nutmeg", "Spice" },
                    { 37, "url", "Ground Ginger", "Spice" },
                    { 38, "url", "Baking Soda", "Food additive" },
                    { 39, "url", "Butter", "Dairy" },
                    { 40, "url", "Milk", "Dairy" },
                    { 41, "url", "Cranberry", "Fruit" },
                    { 42, "url", "Vanilla", "Spice" },
                    { 43, "url", "Whipping Cream", "Topping" },
                    { 45, "url", "Jalapeno", "Spice" },
                    { 46, "url", "Red onion", "Vegetable" },
                    { 47, "url", "Carrot", "Vegetable" },
                    { 49, "url", "Bacon", "Meat" },
                    { 56, "url", "Bread", "Grain" },
                    { 51, "url", "Pork sausage", "Meat" },
                    { 52, "url", "Refrigerated Roll Dough", "Grain" },
                    { 53, "url", "Mozarrella", "Diary" },
                    { 54, "url", "Cheddar", "Diary" },
                    { 55, "url", "Oregano", "Spice" },
                    { 34, "url", "Ground Cinnamon", "Spice" },
                    { 57, "url", "Celery", "Vegetable" },
                    { 58, "url", "Paprika", "Grain" },
                    { 59, "url", "Hot pepper sauce", "Spice" },
                    { 60, "url", "Beef", "Spice" },
                    { 61, "url", "Thousand Island", "Topping" },
                    { 62, "url", "Sauerkraut", "Side dish" },
                    { 63, "url", "Condensed Cream of Chicken soup", "Side dish" },
                    { 64, "url", "Refrigerated Biscuit Dough", "Grain" },
                    { 50, "url", "Cheese", "Diary" },
                    { 33, "url", "Baking Powder", "Food additive" },
                    { 44, "url", "Cabbage", "Vegetable" },
                    { 31, "url", "Molasses", "Sweetener" },
                    { 32, "url", "Flour", "Grain" },
                    { 1, "url", "Tomato", "Vegetable" },
                    { 2, "url", "Cucumber", "Vegetable" },
                    { 3, "url", "Potato", "Vegetable" },
                    { 4, "url", "Onion", "Vegetable" },
                    { 5, "url", "Asparagus", "Vegetable" },
                    { 6, "url", "Chilli peppers", "Vegetable" },
                    { 7, "url", "Lettuce", "Vegetable" },
                    { 8, "url", "Leeks", "Vegetable" },
                    { 9, "url", "Eggplant", "Vegetable" },
                    { 10, "url", "Mushroom", "Fungi" },
                    { 11, "url", "Peas", "Vegetable" },
                    { 12, "url", "Pumpkin", "Vegetable" },
                    { 13, "url", "Pork", "Meat" },
                    { 15, "url", "Beans", "Grain" },
                    { 14, "url", "Chicken", "Meat" },
                    { 17, "url", "Spahetti", "Pasta" },
                    { 30, "url", "White sugar", "Sweetener" },
                    { 29, "url", "Vegetable oil", "Condiment" },
                    { 28, "url", "Garlic", "Vegetable" },
                    { 27, "url", "Lime", "Fruit" },
                    { 26, "url", "Black Pepper", "Spice" },
                    { 25, "url", "Salt", "Spice" },
                    { 16, "url", "Egg", "Egg" },
                    { 24, "url", "Rice Vinegar", "Condiment" },
                    { 22, "url", "Soy sauce", "Condiment" },
                    { 21, "url", "Maple syrup", "Condiment" },
                    { 20, "url", "Asian chile pepper sauce", "Condiment" },
                    { 19, "url", "Rigatoni", "Pasta" },
                    { 18, "url", "Macaroni", "Pasta" },
                    { 23, "url", "Mayonnaise", "Condiment" }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "RatingId", "ReviewsNumber", "Stars" },
                values: new object[,]
                {
                    { 10, 87, 4.2999999999999998 },
                    { 9, 10, 5.0 },
                    { 8, 174, 4.9000000000000004 },
                    { 7, 122, 3.7000000000000002 },
                    { 6, 32, 2.7999999999999998 },
                    { 3, 33, 4.2000000000000002 },
                    { 4, 20, 3.7999999999999998 },
                    { 2, 156, 4.2999999999999998 },
                    { 1, 232, 5.0 },
                    { 5, 56, 4.0999999999999996 }
                });

            migrationBuilder.InsertData(
                table: "RecipeStep",
                columns: new[] { "RecipeStepId", "RecipeStepDescription" },
                values: new object[,]
                {
                    { 15, "In a bowl, mix together the cabbage, jalapeno pepper, red onion, carrot, cilantro, and lime juice." },
                    { 16, "Place bacon in a large, deep skillet. Cook over medium high heat until evenly brown. Drain, crumble and set aside." },
                    { 17, "Preheat oven to 350 degrees F (175 degrees C). Lightly grease a 9 inch pie pan." },
                    { 18, "Line bottom of pie plate with cheese and crumbled bacon. Combine eggs, butter, onion, salt, flour and milk; whisk together until smooth; pour into pie pan." },
                    { 19, "Bake in preheated oven for 35 minutes, until set. Serve hot or cold." },
                    { 21, "Place eggs in a medium saucepan and cover with cold water. Bring water to a boil and immediately remove from heat. Cover and let eggs stand in hot water for 10 to 12 minutes. Remove from hot water, cool and peel." },
                    { 22, "Cut eggs in half. Remove yolks and place in a medium bowl. Mash together with celery, onion, mayonnaise, salt and hot pepper sauce." },
                    { 23, "Stuff the egg white halves with the egg yolk mixture. Sprinkle eggs with paprika. Chill covered in the refrigerator until serving." },
                    { 24, "Preheat a large skillet or griddle on medium heat." },
                    { 25, "Lightly butter one side of bread slices. Spread non-buttered sides with Thousand Island dressing. On 4 bread slices, layer 1 slice Swiss cheese, 2 slices corned beef, 1/4 cup sauerkraut and second slice of Swiss cheese. Top with remaining bread slices, buttered sides out." },
                    { 26, "Grill sandwiches until both sides are golden brown, about 5 minutes per side. Serve hot." },
                    { 20, "Heat a large skillet over low heat. Spread butter or margarine onto one side of two slices of bread. Place both pieces buttered side down in the skillet. Lay a slice of cheese on each one, and top with slices of tomato, onion and jalapeno. Butter one side of the remaining slices of bread, and place on top buttered side up. When the bottom of the sandwiches are toasted, flip and fry until brown on the other side." },
                    { 14, "For sauce, heat 1 cup sugar, 1/2 cup butter, heavy cream, and vanilla extract in a saucepan over medium-low heat; cook and stir cream sauce until sugar is dissolved, about 10 minutes. Pour hot sauce over hot cake. Allow cake to cool in the baking dish for 10 minutes before removing to cool completely on a wire rack." },
                    { 12, "Combine flour, baking soda, and salt in a bowl. Beat 1 cup sugar and 3 tablespoons melted butter with a whisk until well mixed. Add eggs and beat until smooth. Stir flour mixture and milk into egg mixture until batter is well blended. Fold cranberries into batter until just mixed and pour into prepared baking dish." },
                    { 11, "Preheat oven to 350 degrees F (175 degrees C). Grease a 9x13-inch baking dish." },
                    { 10, "When cool enough to touch, cut into 1/2 inch thick diagonal slices. Place sliced biscotti on cookie sheet, and bake an additional 5 to 7 minutes on each side, or until toasted and crispy." },
                    { 9, "Bake in preheated oven for 25 minutes. Remove from oven, and set aside to cool." },
                    { 8, "Divide dough in half, and shape each half into a roll the length of the cookie. Place rolls on cookie sheet, and pat down to flatten the dough to 1/2 inch thickness" },
                    { 7, "In a large bowl, mix together oil, sugar, eggs, and molasses. In another bowl, combine flours, baking powder, ginger, cinnamon, cloves, and nutmeg; mix into egg mixture to form a stiff dough." },
                    { 6, "Preheat the oven to 375 degrees F (190 degrees C). Grease a cookie sheet." },
                    { 5, "Transfer chicken to a platter, let rest for 5 minutes, and serve garnished with lime wedges." },
                    { 4, "Place chicken thighs onto the hot grill with smooth sides down. Cook until chicken shows grill marks, about 3 minutes. Turn chicken over and cook until other side shows grill marks, about 5 minutes. Continue to cook, moving them occasionally and turning over every 2 minutes, until meat is no longer pink inside and the thighs are golden brown, 10 to 12 minutes." },
                    { 3, "Preheat charcoal grill to high heat." },
                    { 2, "Transfer chicken thighs to a large flat container (such as a baking dish) and pour marinade over chicken; stir until chicken is coated. Cover dish with plastic wrap and refrigerate about 3 hours; if preferred, let stand about 30 minutes at room temperature. Unwrap dish and sprinkle with salt." },
                    { 1, "Mash garlic to a paste with a mortar and pestle. Mix chile pepper sauce, maple syrup, soy sauce, mayonnaise, and rice vinegar into garlic until marinade is thoroughly combined." },
                    { 27, "Place the chicken, butter, soup, and onion in a slow cooker, and fill with enough water to cover." },
                    { 13, "Bake in the preheated oven until a toothpick inserted into the center comes out clean, about 30 minutes." },
                    { 28, "Cover, and cook for 5 to 6 hours on High. About 30 minutes before serving, place the torn biscuit dough in the slow cooker. Cook until the dough is no longer raw in the center." }
                });

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "RecipeId", "CuisineId", "DishTypeId", "ImageURL", "Price", "RatingId", "Time", "Title" },
                values: new object[,]
                {
                    { 1, 1, 2, "./imagesandicons/food-plate.png", 90m, 1, 35, "Rusty Chicken Thighs" },
                    { 2, 2, 4, "./imagesandicons/food-plate.png", 80m, 2, 65, "Gingerbread Biscotti" },
                    { 3, 3, 4, "./imagesandicons/food-plate.png", 120m, 3, 120, "Fresh Cranberry Cake" },
                    { 4, 4, 5, "./imagesandicons/food-plate.png", 50m, 4, 20, "Taco Slaw" },
                    { 5, 3, 1, "./imagesandicons/food-plate.png", 75m, 5, 50, "Quick Quiche" },
                    { 6, 2, 1, "./imagesandicons/food-plate.png", 70m, 6, 50, "Egg and Sausage Casserole" },
                    { 7, 3, 3, "./imagesandicons/food-plate.png", 40m, 7, 5, "Spicy Grilled Cheese Sandwich" },
                    { 8, 5, 3, "./imagesandicons/food-plate.png", 110m, 8, 45, "Di's Delicious Deluxe Deviled Eggs" },
                    { 9, 1, 3, "./imagesandicons/food-plate.png", 60m, 9, 25, "Reuben Sandwich II" },
                    { 10, 2, 4, "./imagesandicons/food-plate.png", 95m, 10, 300, "Slow Cooker Chicken and Dumplings" }
                });

            migrationBuilder.InsertData(
                table: "RecipeDiets",
                columns: new[] { "RecipeId", "DietId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 7, 4 },
                    { 8, 4 },
                    { 3, 4 },
                    { 2, 4 },
                    { 9, 4 },
                    { 6, 4 },
                    { 4, 4 },
                    { 5, 4 },
                    { 10, 4 }
                });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId" },
                values: new object[,]
                {
                    { 39, 5 },
                    { 48, 4 },
                    { 55, 6 },
                    { 54, 6 },
                    { 53, 6 },
                    { 52, 6 },
                    { 51, 6 },
                    { 16, 6 },
                    { 16, 5 },
                    { 39, 7 },
                    { 40, 5 },
                    { 32, 5 },
                    { 25, 5 },
                    { 4, 5 },
                    { 50, 5 },
                    { 56, 7 },
                    { 4, 7 },
                    { 50, 7 },
                    { 64, 10 },
                    { 63, 10 },
                    { 4, 10 },
                    { 14, 10 },
                    { 39, 10 },
                    { 62, 9 },
                    { 61, 9 },
                    { 60, 9 },
                    { 50, 9 },
                    { 1, 7 },
                    { 56, 9 },
                    { 58, 8 },
                    { 59, 8 },
                    { 25, 8 },
                    { 23, 8 },
                    { 4, 8 },
                    { 57, 8 },
                    { 16, 8 },
                    { 45, 7 },
                    { 47, 4 },
                    { 39, 9 },
                    { 46, 4 },
                    { 49, 5 },
                    { 44, 4 },
                    { 45, 4 },
                    { 34, 2 },
                    { 33, 2 },
                    { 32, 2 },
                    { 31, 2 },
                    { 30, 2 },
                    { 29, 2 },
                    { 16, 2 },
                    { 28, 1 },
                    { 27, 1 },
                    { 26, 1 },
                    { 25, 1 },
                    { 24, 1 },
                    { 23, 1 },
                    { 22, 1 },
                    { 21, 1 },
                    { 20, 1 },
                    { 36, 2 },
                    { 37, 2 },
                    { 35, 2 },
                    { 25, 3 },
                    { 27, 4 },
                    { 42, 3 },
                    { 43, 3 },
                    { 41, 3 },
                    { 40, 3 },
                    { 32, 3 },
                    { 16, 3 },
                    { 38, 3 },
                    { 39, 3 },
                    { 30, 3 }
                });

            migrationBuilder.InsertData(
                table: "RecipeRecipeSteps",
                columns: new[] { "RecipeStepId", "RecipeId" },
                values: new object[,]
                {
                    { 11, 3 },
                    { 24, 9 },
                    { 18, 6 },
                    { 25, 9 },
                    { 26, 9 },
                    { 12, 3 },
                    { 13, 3 },
                    { 27, 10 },
                    { 14, 3 },
                    { 15, 4 },
                    { 1, 1 },
                    { 2, 1 },
                    { 22, 8 },
                    { 4, 1 },
                    { 23, 8 },
                    { 17, 6 },
                    { 21, 8 },
                    { 5, 1 },
                    { 20, 7 },
                    { 10, 2 },
                    { 16, 6 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 2 },
                    { 9, 2 },
                    { 19, 6 },
                    { 3, 1 },
                    { 28, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_CuisineId",
                table: "Recipe",
                column: "CuisineId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_DishTypeId",
                table: "Recipe",
                column: "DishTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_RatingId",
                table: "Recipe",
                column: "RatingId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDiets_DietId",
                table: "RecipeDiets",
                column: "DietId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeRecipeSteps_RecipeId",
                table: "RecipeRecipeSteps",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeDiets");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "RecipeRecipeSteps");

            migrationBuilder.DropTable(
                name: "Diet");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "RecipeStep");

            migrationBuilder.DropTable(
                name: "Cuisine");

            migrationBuilder.DropTable(
                name: "DishType");

            migrationBuilder.DropTable(
                name: "Rating");
        }
    }
}
