using Newtonsoft.Json;

namespace api.Models
{
  public class RecipeDiet
  {
    [JsonIgnore]
    public int DietId { get; set; }

    public virtual Diet Diet { get; set; }
    [JsonIgnore]
    public int RecipeId { get; set; }
    public virtual Recipe Recipe { get; set; }

    public RecipeDiet() { }
    public RecipeDiet(int dietId, int recipeId)
    {
      DietId = dietId;
      RecipeId = recipeId;
    }
  }
}
