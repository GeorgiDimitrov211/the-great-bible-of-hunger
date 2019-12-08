using System;
using System.Collections.Generic;

namespace api.Models {
    public class Diet {
        public int DietId { get; set; }
        public string Name { get; set; }
        public List<RecipeDiet> RecipeDiets { get; set; }
        //IList ?

        public Diet() { }
        public Diet(int id, string name) {
            DietId = id;
            Name = name;
        }
    }
}
