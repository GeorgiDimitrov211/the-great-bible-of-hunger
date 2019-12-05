using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace the_great_bible_of_hunger.Models {
    public class Recipe {
        public int RecipeID { get; set; }
        public decimal Price { get; set; }
        public int Time { get; set; }
        public string ImageURL { get; set; }
        public string Title { get; set; }
        public int CuisineID { get; set; }
        public Cuisine Cuisine { get; set; }
        public int DishTypeID { get; set; }
        public DishType DishType { get; set; }
        public int RatingID { get; set; }
        public Rating Rating { get; set; }
        [NotMapped]
        public ICollection<string> Description { get; set; }
        public virtual ICollection<RecipeDiet> RecipeDiets { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }

        public Recipe() { }
        public Recipe(decimal price, int time, string imageUrl, string title, int cuisineID, int dishtypeID, int ratingID) {
            Price = price;
            Time = time;
            ImageURL = imageUrl;
            Title = title;
            CuisineID = cuisineID;
            DishTypeID = dishtypeID;
            RatingID = ratingID;
        }
    }
}
