using System;
using System.Collections.Generic;

namespace the_great_bible_of_hunger.Models {
    public class Recipe {
        public int RecipeID { get; set; }
        public Rating Rating { get; set; }
        public decimal Price { get; set; }
        public int Time { get; set; }
        public Cuisine Cuisine { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public ICollection<string> Description { get; set; }
        public ICollection<Diet> Diets { get; set; }
        public ICollection<DishType> DishType { get; set; }
        public ICollection<Ingredient> Ingredients  { get; set; }
    }
}
