using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassFinder.Models;

public class Class
{
  public int ClassId { get; set; }
  public string Title { get; set; }
  public string Description { get; set; }
  public string Catagory { get; set; }
  public string DataAnnotations { get; set; }

}