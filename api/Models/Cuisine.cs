using System;
using System.Collections.Generic;

namespace api.Models {
    public class Cuisine {
        public int CuisineId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }

        public Cuisine() { }
        public Cuisine(int Id, string name) {
            CuisineId = Id;
            Name = name;
        }
    }
}
