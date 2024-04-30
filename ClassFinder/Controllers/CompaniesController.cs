using System.Collections.Generic;
using System.Linq;
using ClassFinder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassFinder.Controllers
{
  public class CompaniesController :  Controller
  {
    private readonly ClassFinderContext _db;
    public CompaniesController(ClassFinderContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Company> model = _db.Companies.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }
    [HttpPost]
    public ActionResult Create(Company company)
    {
      if (ModelState.IsValid)
      {
        _db.Companies.Add(company);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      return View(company);
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
        var company = _db.Companies.FirstOrDefault(c => c.CompanyId == id);

      if (company == null)
      {
        return NotFound();
      }

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