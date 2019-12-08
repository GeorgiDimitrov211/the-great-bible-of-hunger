namespace api.Models {
    public class RecipeIngredient {

        public int IngredientId { get; set; }
        public virtual Ingredient Ingredient { get; set; }

        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
