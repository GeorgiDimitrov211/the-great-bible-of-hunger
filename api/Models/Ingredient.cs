
using System;
using System.Collections.Generic;

namespace api.Models {
    public class Ingredient {
        public int IngredientID { get; set; }
        public string Name { get; set; }
        public string ImageURL { get; set; }
        public string Type { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }

        public Ingredient() { }
        public Ingredient(string name, string imageUrl, string type ) {
            if (imageUrl.Length != 0) {
                ImageURL = imageUrl;
            }
            Name = name;
            Type = type;
        }
    }
}
