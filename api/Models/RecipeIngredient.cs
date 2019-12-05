using System;
namespace the_great_bible_of_hunger.Models {
    public class RecipeIngredient {

        public int IngredientID { get; set; }
        public Ingredient Ingredient { get; set; }

        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }
}
