using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
  public class RecipeIngredient
  {
    [JsonIgnore]

    public int IngredientId { get; set; }

    public virtual Ingredient Ingredient { get; set; }
    [JsonIgnore]

    public int RecipeId { get; set; }
    [JsonIgnore]
    public virtual Recipe Recipe { get; set; }

    public RecipeIngredient() { }
    public RecipeIngredient(int ingredientId, int recipeId)
    {
      IngredientId = ingredientId;
      RecipeId = recipeId;
    }
  }
}
