using System;

namespace api.Models {
    public class RecipeDiet {

        public int DietID { get; set; }
        public Diet Diet { get; set; }

        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }
}
