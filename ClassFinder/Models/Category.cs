using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassFinder.Models;

public class Category
{
  public int CategoryId { get; set; }
  public string? Name { get; set; } 
  public List<Company> Companies { get; set; }

}