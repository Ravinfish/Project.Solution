using System.Collections.Generic;
using System.Linq;
using ClassFinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Http.Headers;

namespace ClassFinder.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ClassFinderContext _db;

    public CategoriesController(ClassFinderContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Category> model = _db.Categories.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Category category)
    {
      // if (ModelState.IsValid)
      // {
        _db.Categories.Add(category);
        _db.SaveChanges();
        return RedirectToAction("Index");
      // }
      // return View(category); // Return to the create view with validation errors
    }

    public ActionResult Details(int id)
    {
      var thisCategory = _db.Categories
          .Include(c => c.Companies)
          .FirstOrDefault(c => c.CategoryId == id);

      if (thisCategory == null)
      {
        return NotFound();
      }

      return View(thisCategory);
    }

    public ActionResult Edit(int id)
    {
      var category = _db.Categories.FirstOrDefault(c => c.CategoryId == id);

      if (category == null)
      {
        return NotFound();
      }

      return View(category);
    }

    [HttpPost]
    public ActionResult Edit(Category category)
    {
      if (ModelState.IsValid)
      {
        _db.Categories.Update(category);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(category); // Return to the edit view with validation errors
    }

    public ActionResult Delete(int id)
    {
      var category = _db.Categories.FirstOrDefault(c => c.CategoryId == id);

      if (category == null)
      {
        return NotFound();
      }

      return View(category);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var category = _db.Categories.FirstOrDefault(c => c.CategoryId == id);

      if (category == null)
      {
        return NotFound();
      }

      _db.Categories.Remove(category);
      _db.SaveChanges();

      return RedirectToAction("Index");
    }
  }
}



