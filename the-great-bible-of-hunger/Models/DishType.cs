
using System;
using System.Collections.Generic;

namespace the_great_bible_of_hunger.Models {
    public class DishType {
        public int DishTypeID { get; set; }
        public string Name { get; set; }
        public ICollection<Recipe> Recipes { get; set; }

        public DishType() { }
        public DishType(string name) {
            Name = name;
        }
    }
}
