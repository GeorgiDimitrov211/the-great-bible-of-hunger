using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace api.Models
{
  public class Cuisine
  {
    [JsonIgnore]
    public int CuisineId { get; set; }
    public string Name { get; set; }
    [JsonIgnore]
    public virtual ICollection<Recipe> Recipes { get; set; }

    public Cuisine() { }
    public Cuisine(int Id, string name)
    {
      CuisineId = Id;
      Name = name;
    }
  }
}
