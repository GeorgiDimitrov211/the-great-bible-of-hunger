
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace api.Models
{
  public class DishType
  {
    [JsonIgnore]
    public int DishTypeId { get; set; }
    public string Name { get; set; }

    [JsonIgnore]
    public virtual ICollection<Recipe> Recipes { get; set; }

    public DishType() { }
    public DishType(int Id, string name)
    {
      DishTypeId = Id;
      Name = name;
    }
  }
}
