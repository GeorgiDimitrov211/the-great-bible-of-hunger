namespace api.Models {
    public class RecipeDiet {
        public int DietId { get; set; }
        public Diet Diet { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public RecipeDiet() { }
        public RecipeDiet(int dietId, int recipeId) {
            DietId = dietId;
            RecipeId = recipeId;
        }
    }
}
