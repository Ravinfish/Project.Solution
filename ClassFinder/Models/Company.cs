using System;
using System.Collections.Generic;

namespace ClassFinder.Models;

public class Company
{
  public int CompanyId { get; set; } 
  public string? Name { get; set; }
  public string? Description { get; set; }
  public Category? Category { get; set; }
  public int CategoryId { get; set; }

} 
