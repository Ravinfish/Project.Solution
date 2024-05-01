using System.Collections.Generic;
using System.Linq;
using ClassFinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClassFinder.Controllers
{
  public class CompaniesController : Controller
  {
    private readonly ClassFinderContext _db;
    public CompaniesController(ClassFinderContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Company> companies = _db.Companies.Include(c => c.Category).ToList();
      return View(companies);
    }

    public ActionResult Create()
    {
      // Get categories from the database
      var categories = _db.Categories.ToList();

      // Create a SelectList for the categories
      ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "Name");

      return View();
    }
    [HttpPost]
    public ActionResult Create(Company company)
    {

      _db.Companies.Add(company);
      _db.SaveChanges();
      return RedirectToAction("Index");

    }

    public ActionResult Details(int id)
    {
      var company = _db.Companies
      .Include(c => c.Category)
      .FirstOrDefault(c => c.CompanyId == id);

      if (company == null)
      {
        return NotFound();
      }

      return View(company);

    }

    public ActionResult Edit(int id)
    {
      // Retrieve the company from the database
      var company = _db.Companies.Find(id);
      if (company == null)
      {
        return NotFound();
      }

      // Get categories from the database
      var categories = _db.Categories.ToList();

      // Create a SelectList for the categories
      ViewData["CategoryId"] = new SelectList(categories, "CategoryId", "Name", company.CategoryId);

      return View(company);
    }

    [HttpPost]
    public ActionResult Edit(Company company)
    {
      if (ModelState.IsValid)
      {
        _db.Companies.Update(company);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }

      return View(company); // Return to the edit view with validation errors
    }

    public ActionResult Delete(int id)
    {
      var company = _db.Companies.FirstOrDefault(c => c.CompanyId == id);

      if (company == null)
      {
        return NotFound();
      }

      return View(company);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var company = _db.Companies.FirstOrDefault(c => c.CompanyId == id);

      if (company == null)
      {
        return NotFound();
      }

      _db.Companies.Remove(company);
      _db.SaveChanges();

      return RedirectToAction("Index");

    }

  }
}