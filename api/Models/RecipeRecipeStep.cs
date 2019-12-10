using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace api.Models
{
  public class RecipeRecipeStep
  {
    [JsonIgnore]
    public int RecipeStepId { get; set; }
    public virtual RecipeStep RecipeStep { get; set; }
    [JsonIgnore]
    public int RecipeId { get; set; }
    [JsonIgnore]
    public virtual Recipe Recipe { get; set; }
    public RecipeRecipeStep() { }
    public RecipeRecipeStep(int recipeStepId, int recipeId)
    {
      RecipeStepId = recipeStepId;
      RecipeId = recipeId;
    }
  }
}
