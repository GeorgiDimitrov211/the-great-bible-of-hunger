using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class CreateRecipeSteps : Migration
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
                    { 3, "Indian" }
                });

            migrationBuilder.InsertData(
                table: "Diet",
                columns: new[] { "DietId", "Name" },
                values: new object[,]
                {
                    { 1, "Vegan" },
                    { 2, "Vegetarian" },
                    { 3, "Gluten-free" }
                });

            migrationBuilder.InsertData(
                table: "DishType",
                columns: new[] { "DishTypeId", "Name" },
                values: new object[,]
                {
                    { 3, "Lunch" },
                    { 4, "Dessert" },
                    { 1, "Breakfast" },
                    { 2, "Dinner" }
                });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "IngredientId", "ImageURL", "Name", "Type" },
                values: new object[,]
                {
                    { 11, "url", "Mushrooms", "Vegetable" },
                    { 18, "url", "Rigatoni", "Pasta" },
                    { 17, "url", "Macaroni", "Pasta" },
                    { 16, "url", "Spahetti", "Pasta" },
                    { 15, "url", "Lasagne", "Pasta" },
                    { 14, "url", "Beans", "Grain" },
                    { 13, "url", "Pumpkin", "Vegetable" },
                    { 12, "url", "Peas", "Vegetable" },
                    { 10, "url", "Eggplant", "Vegetable" },
                    { 6, "url", "Asparagus", "Vegetable" },
                    { 8, "url", "Lettuce", "Vegetable" },
                    { 7, "url", "Chilli peppers", "Vegetable" },
                    { 5, "url", "Onion", "Vegetable" },
                    { 4, "url", "Potato", "Vegetable" },
                    { 3, "url", "Pork", "Meat" },
                    { 2, "url", "Cucumber", "Vegetable" },
                    { 1, "url", "Tomato", "Vegetable" },
                    { 9, "url", "Leeks", "Vegetable" }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "RatingId", "ReviewsNumber", "Stars" },
                values: new object[,]
                {
                    { 2, 156, 4.2999999999999998 },
                    { 1, 232, 5.0 },
                    { 3, 20, 3.7999999999999998 }
                });

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "RecipeId", "CuisineId", "DishTypeId", "ImageURL", "Price", "RatingId", "Time", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "https://via.placeholder.com/150", 70m, 1, 20, "Placeholder Dish" },
                    { 3, 3, 3, "https://via.placeholder.com/150", 65m, 1, 60, "Placeholder Dish" },
                    { 4, 2, 2, "https://via.placeholder.com/150", 95m, 1, 30, "Placeholder Dish" },
                    { 5, 3, 2, "https://via.placeholder.com/150", 75m, 2, 50, "Placeholder Dish" },
                    { 2, 2, 2, "https://via.placeholder.com/150", 80m, 3, 40, "Placeholder Dish" }
                });

            migrationBuilder.InsertData(
                table: "RecipeDiets",
                columns: new[] { "RecipeId", "DietId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 3 },
                    { 2, 2 },
                    { 2, 3 }
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
