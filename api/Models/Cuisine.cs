using System;
using System.Collections.Generic;

namespace api.Models {
    public class Cuisine {
        public int CuisineID { get; set; }
        public string Name { get; set; }
        public ICollection<Recipe> Recipes { get; set; }

        public Cuisine() { }
        public Cuisine(string name) {
            Name = name;
        }
    }
}
