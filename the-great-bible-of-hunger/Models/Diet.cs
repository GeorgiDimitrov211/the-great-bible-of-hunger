using System;
using System.Collections.Generic;

namespace the_great_bible_of_hunger.Models {
    public class Diet {
        public int DietID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<RecipeDiet> RecipeDiets { get; set; }

        public Diet() { }
        public Diet(string name) {
            Name = name;
        }
    }
}
