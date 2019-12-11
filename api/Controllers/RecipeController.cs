using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;

namespace api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class RecipeController : ControllerBase
  {
    private readonly GBOHContext _context;

    public RecipeController(GBOHContext context) => _context = context;

    // Get all recipes from the database
    [HttpGet]
    public ActionResult<IEnumerable<Recipe>> GetRecipes()
    {

      return _context.Recipes
        .Include(x => x.RecipeDiets).ThenInclude(x => x.Diet)
        .Include(x => x.RecipeIngredients).ThenInclude(x => x.Ingredient)
        .Include(x => x.RecipeRecipeSteps).ThenInclude(x => x.RecipeStep)
        .Include(x => x.Cuisine)
        .Include(x => x.Rating)
        .Include(x => x.DishType)
        .ToList();
    }

    // Get a specific recipe by id
    [HttpGet("{id}")]
    public ActionResult<Recipe> GetRecipeById(int id)
    {
      var recipe = _context.Recipes
        .Include(x => x.RecipeDiets).ThenInclude(x => x.Diet)
        .Include(x => x.RecipeIngredients).ThenInclude(x => x.Ingredient)
        .Include(x => x.RecipeRecipeSteps).ThenInclude(x => x.RecipeStep)
        .Include(x => x.Cuisine)
        .Include(x => x.Rating)
        .Include(x => x.DishType)
        .SingleOrDefault(x => x.RecipeId == id);
      if (recipe == null)
      {
        return NotFound();
      }
      return recipe;
    }
  }
}