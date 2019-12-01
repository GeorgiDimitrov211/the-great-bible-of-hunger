
using System;
using System.Collections.Generic;

namespace the_great_bible_of_hunger.Models {
    public class Ingredient {
        public int IngredientID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public string ImageURL { get; set; }
        public string Type { get; set; }
    }
}
