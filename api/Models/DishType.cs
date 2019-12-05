
using System;
using System.Collections.Generic;

namespace api.Models {
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
