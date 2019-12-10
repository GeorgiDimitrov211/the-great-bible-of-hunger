using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace api.Models {
    public class Diet {
        public int DietId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public virtual ICollection<RecipeDiet> RecipeDiets { get; set; } = new List<RecipeDiet>();

        public Diet() { }
        public Diet(int id, string name) {
            DietId = id;
            Name = name;
        }
    }
}
