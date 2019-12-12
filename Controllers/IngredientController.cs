using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using api.Models;
using Microsoft.EntityFrameworkCore;
using api.Data;
using System;

namespace api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class IngredientController : ControllerBase
  {
    private readonly GBOHContext _context;

    public IngredientController(GBOHContext context) => _context = context;

    // Get all ingredients from the database
    [HttpPost]
    public ActionResult<IEnumerable<Ingredient>> GetIngredientsByIds([FromBody] string savedIdsAsStrings)
    {
      var results = new List<Ingredient>();
      var allIngredients = _context.Ingredients.ToList();
      Array.ForEach(savedIdsAsStrings.Split(","), savedId => {
        results.Add(allIngredients.Find(ingredient => ingredient.IngredientId.ToString() == savedId));
      });
      return results;
    }

    // Get a specific ingredient by name
    [HttpGet("{name}")]
    public ActionResult<Ingredient> GetIngredientByName(string name)
    {
      var ingredient = _context.Ingredients.ToList().Find(ingredient => ingredient.Name.ToLower() == name.ToLower());
      if (ingredient == null)
      {
        return NotFound();
      }
      return ingredient;
    }

    // // Post a new command to the database
    // [HttpPost]
    // public ActionResult<Command> PostCommandItem(Command command)
    // {
    //   _context.CommandItems.Add(command);
    //   _context.SaveChanges();
    //   return CreatedAtAction("GetCommandItem", new Command{Id = command.Id}, command);
    // }

    // // Put an existing command
    // [HttpPut("{id}")]
    // public ActionResult PutCommandItem(int id, Command command)
    // {
    //   if (id != command.Id)
    //   {
    //     return BadRequest();
    //   }
    //   _context.Entry(command).State = EntityState.Modified;
    //   _context.SaveChanges();

    //   return NoContent();
    // }

    // // Delete a command from the database
    // [HttpDelete("{id}")]
    // public ActionResult<Command> DeleteCommandItem(int id)
    // {
    //   var commandItem = _context.CommandItems.Find(id);
    //   if (commandItem == null)
    //   {
    //     return NotFound();
    //   }
    //   _context.CommandItems.Remove(commandItem);
    //   _context.SaveChanges();
    //   return commandItem;
    // }
  }
}