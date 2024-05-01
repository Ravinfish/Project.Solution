using System.Collections.Generic;
using System.Linq;
using ClassFinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassFinder.Controllers
{
  public class CoursesController : Controller
  {
    private readonly ClassFinderContext _db;

    public CoursesController(ClassFinderContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Course> model = _db.Courses.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Course course)
    {
      if (ModelState.IsValid)
      {
        _db.Courses.Add(course);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(course); // Return to the create view with validation errors
    }

    public ActionResult Details(int id)
    {
      var course = _db.Courses
        .Include(c => c.Category) // Include the Category navigation property
        .FirstOrDefault(c => c.CourseId == id);

      if (course == null)
      {
        return NotFound();
      }

      return View(course);
    }

    public ActionResult Edit(int id)
    {
      var course = _db.Courses.FirstOrDefault(c => c.CourseId == id);

      if (course == null)
      {
        return NotFound();
      }

      return View(course);
    }

    [HttpPost]
    public ActionResult Edit(Course course)
    {
      if (ModelState.IsValid)
      {
        _db.Courses.Update(course);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(course); // Return to the edit view with validation errors
    }

    public ActionResult Delete(int id)
    {
      var course = _db.Courses.FirstOrDefault(c => c.CourseId == id);

      if (course == null)
      {
        return NotFound();
      }

      return View(course);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var course = _db.Courses.FirstOrDefault(c => c.CourseId == id);

      if (course == null)
      {
        return NotFound();
      }

      _db.Courses.Remove(course);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}