using System.Collections.Generic;
using System.Linq;
using ClassFinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

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

    public ActionResult Create ()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Category Category)
    {
      _db.Categories.Add(Category);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Category thisCategory = _db.Categories
      .Include(Category => Category.Companies)
      .FirstOrDefault(Category => Category.CategoryId == id);
      return View(thisCategory);
    }

    public ActionResult Edit(int id)
    {
      
    }
  }
}

  
