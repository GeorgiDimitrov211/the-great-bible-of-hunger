using Microsoft.EntityFrameworkCore.Migrations;

namespace the_great_bible_of_hunger.Migrations
{
    public partial class settingUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cuisine",
                columns: table => new
                {
                    CuisineID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuisine", x => x.CuisineID);
                });

            migrationBuilder.CreateTable(
                name: "Diet",
                columns: table => new
                {
                    DietID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diet", x => x.DietID);
                });

            migrationBuilder.CreateTable(
                name: "DishType",
                columns: table => new
                {
                    DishTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishType", x => x.DishTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                columns: table => new
                {
                    IngredientID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ImageURL = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.IngredientID);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    RatingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewsNumber = table.Column<int>(nullable: false),
                    Stars = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.RatingID);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                columns: table => new
                {
                    RecipeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(nullable: false),
                    Time = table.Column<int>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    CuisineID = table.Column<int>(nullable: false),
                    DishTypeID = table.Column<int>(nullable: false),
                    RatingID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.RecipeID);
                    table.ForeignKey(
                        name: "FK_Recipe_Cuisine_CuisineID",
                        column: x => x.CuisineID,
                        principalTable: "Cuisine",
                        principalColumn: "CuisineID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipe_DishType_DishTypeID",
                        column: x => x.DishTypeID,
                        principalTable: "DishType",
                        principalColumn: "DishTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recipe_Rating_RatingID",
                        column: x => x.RatingID,
                        principalTable: "Rating",
                        principalColumn: "RatingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeDiet",
                columns: table => new
                {
                    DietID = table.Column<int>(nullable: false),
                    RecipeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeDiet", x => new { x.DietID, x.RecipeID });
                    table.ForeignKey(
                        name: "FK_RecipeDiet_Diet_DietID",
                        column: x => x.DietID,
                        principalTable: "Diet",
                        principalColumn: "DietID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeDiet_Recipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipe",
                        principalColumn: "RecipeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                columns: table => new
                {
                    IngredientID = table.Column<int>(nullable: false),
                    RecipeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => new { x.IngredientID, x.RecipeID });
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Ingredient_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredient",
                        principalColumn: "IngredientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipe_RecipeID",
                        column: x => x.RecipeID,
                        principalTable: "Recipe",
                        principalColumn: "RecipeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cuisine",
                columns: new[] { "CuisineID", "Name" },
                values: new object[,]
                {
                    { 1, "Asian" },
                    { 2, "Italian" },
                    { 3, "Indian" }
                });

            migrationBuilder.InsertData(
                table: "Diet",
                columns: new[] { "DietID", "Name" },
                values: new object[,]
                {
                    { 1, "Vegan" },
                    { 2, "Vegetarian" },
                    { 3, "Gluten-free" }
                });

            migrationBuilder.InsertData(
                table: "DishType",
                columns: new[] { "DishTypeID", "Name" },
                values: new object[,]
                {
                    { 4, "Dessert" },
                    { 3, "Lunch" },
                    { 1, "Breakfast" },
                    { 2, "Dinner" }
                });

            migrationBuilder.InsertData(
                table: "Ingredient",
                columns: new[] { "IngredientID", "ImageURL", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "", "Tomato", "Vegetable" },
                    { 2, "", "Cucumber", "Vegetable" },
                    { 3, "", "Pork", "Meat" },
                    { 4, "", "Spaghetti", "Pasta" },
                    { 5, "", "Rise", "Grain" }
                });

            migrationBuilder.InsertData(
                table: "Rating",
                columns: new[] { "RatingID", "ReviewsNumber", "Stars" },
                values: new object[,]
                {
                    { 2, 156, 4.2999999999999998 },
                    { 1, 1, 5.0 },
                    { 3, 20, 3.7999999999999998 }
                });

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "RecipeID", "CuisineID", "DishTypeID", "ImageURL", "Price", "RatingID", "Time", "Title" },
                values: new object[] { 1, 1, 1, "https://via.placeholder.com/150", 70m, 1, 20, "Placeholder dish" });

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "RecipeID", "CuisineID", "DishTypeID", "ImageURL", "Price", "RatingID", "Time", "Title" },
                values: new object[] { 2, 2, 3, "https://via.placeholder.com/150", 80m, 2, 40, "Placeholder dish" });

            migrationBuilder.InsertData(
                table: "Recipe",
                columns: new[] { "RecipeID", "CuisineID", "DishTypeID", "ImageURL", "Price", "RatingID", "Time", "Title" },
                values: new object[] { 3, 3, 4, "https://via.placeholder.com/150", 65m, 3, 60, "Placeholder dish" });

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_CuisineID",
                table: "Recipe",
                column: "CuisineID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_DishTypeID",
                table: "Recipe",
                column: "DishTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_RatingID",
                table: "Recipe",
                column: "RatingID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeDiet_RecipeID",
                table: "RecipeDiet",
                column: "RecipeID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipeID",
                table: "RecipeIngredient",
                column: "RecipeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeDiet");

            migrationBuilder.DropTable(
                name: "RecipeIngredient");

            migrationBuilder.DropTable(
                name: "Diet");

            migrationBuilder.DropTable(
                name: "Ingredient");

            migrationBuilder.DropTable(
                name: "Recipe");

            migrationBuilder.DropTable(
                name: "Cuisine");

            migrationBuilder.DropTable(
                name: "DishType");

            migrationBuilder.DropTable(
                name: "Rating");
        }
    }
}
