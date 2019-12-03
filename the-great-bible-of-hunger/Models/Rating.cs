using System;
using System.Collections.Generic;

namespace the_great_bible_of_hunger.Models {
    public class Rating {
        public int RatingID { get; set; }
        public int ReviewsNumber { get; set; }
        public double Stars { get; set; }
        public ICollection<Recipe> Recipes { get; set; }

        public Rating() { }
        public Rating(int reviewsNumber, double stars) {
            ReviewsNumber = reviewsNumber;
            Stars = stars;
        }
    }
}
