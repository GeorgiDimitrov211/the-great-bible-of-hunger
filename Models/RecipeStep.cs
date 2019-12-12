using api.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace api.Models
{
  public class RecipeStep
  {
    public int RecipeStepId { get; set; }
    public string RecipeStepDescription { get; set; }
    [JsonIgnore]

    public virtual ICollection<RecipeRecipeStep> RecipeRecipeSteps { get; set; }

    public RecipeStep() { }

    public RecipeStep(int recipeStepId, string step)
    {
      RecipeStepId = recipeStepId;
      RecipeStepDescription = step;
    }
  }
}