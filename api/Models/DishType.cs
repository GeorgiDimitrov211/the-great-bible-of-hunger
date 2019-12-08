
using System;
using System.Collections.Generic;

namespace api.Models {
    public class DishType {
        public int DishTypeId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }

        public DishType() { }
        public DishType(int Id, string name) {
            DishTypeId = Id;
            Name = name;
        }
    }
}
