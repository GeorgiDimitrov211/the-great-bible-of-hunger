using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace api.Models
{
  public class Recipe
  {
    public int RecipeId { get; set; }
    public decimal Price { get; set; }
    public int Time { get; set; }
    public string ImageURL { get; set; }
    public string Title { get; set; }
    [JsonIgnore]
    public int CuisineId { get; set; }
    [JsonIgnore]
    public int DishTypeId { get; set; }
    [JsonIgnore]
    public int RatingId { get; set; }
    public Cuisine Cuisine { get; set; }
    public DishType DishType { get; set; }
    public Rating Rating { get; set; }

    public virtual ICollection<RecipeDiet> RecipeDiets { get; set; } = new List<RecipeDiet>();
    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
    public virtual ICollection<RecipeRecipeStep> RecipeRecipeSteps { get; set; } = new List<RecipeRecipeStep>();

    public Recipe() { }
    public Recipe(int Id, decimal price, int time, string imageUrl, string title, int cuisineId, int dishtypeId, int ratingId)
    {
      RecipeId = Id;
      Price = price;
      Time = time;
      ImageURL = imageUrl;
      Title = title;
      CuisineId = cuisineId;
      DishTypeId = dishtypeId;
      RatingId = ratingId;
    }
  }
}
