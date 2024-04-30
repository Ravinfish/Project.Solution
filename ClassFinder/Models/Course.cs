using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClassFinder.Models;

public class Course
{
  public int CourseId { get; set; }
  public string? Title { get; set; }
  public string? Description { get; set; }
  public string? Category { get; set; }
  public string? Schedule { get; set; }

}