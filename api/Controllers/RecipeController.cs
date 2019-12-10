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

    // Get all commands from the database
    [HttpGet]
    public ActionResult<IEnumerable<Recipe>> GetRecipes()
    {
      return _context.Recipes.Include(x => x.RecipeDiets).ThenInclude(x => x.Diet).ToList();
    }

    // // Get a specific command by number
    // [HttpGet("{id}")]
    // public ActionResult<Command> GetCommandItem(int id)
    // {
    //   var commandItem = _context.CommandItems.Find(id);
    //   if (commandItem == null)
    //   {
    //     return NotFound();
    //   }
    //   return commandItem;
    // }

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