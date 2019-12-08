using System;

namespace api.Models {
    public class RecipeRecipeStep {

        public int RecipeStepId { get; set; }
        public virtual RecipeStep RecipeStep { get; set; }

        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
