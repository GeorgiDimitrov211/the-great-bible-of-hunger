
using System;
using System.Collections.Generic;

namespace api.Models {
    public class Ingredient {
        public int IngredientId { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Type { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }

        public Ingredient() { }
        public Ingredient(int ingredientId, string name, string imageUrl, string type ) {
            IngredientId = ingredientId;
            if (imageUrl.Length != 0) {
                ImageURL = imageUrl;
            }
            Name = name;
            Type = type;
        }
    }
}
