using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace api.Models
{
  public class Rating
  {
    [JsonIgnore]
    public int RatingId { get; set; }
    public int ReviewsNumber { get; set; }
    public double Stars { get; set; }

    [JsonIgnore]
    public virtual ICollection<Recipe> Recipes { get; set; }

    public Rating() { }
    public Rating(int Id, int reviewsNumber, double stars)
    {
      RatingId = Id;
      ReviewsNumber = reviewsNumber;
      Stars = stars;
    }
  }
}
