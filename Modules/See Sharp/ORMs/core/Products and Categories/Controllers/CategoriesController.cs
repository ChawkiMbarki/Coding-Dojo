using Microsoft.AspNetCore.Mvc;
using Products_and_Categories.Models;
using Microsoft.EntityFrameworkCore;

namespace Products_and_Categories.Controllers;

public class CategoriesController : Controller
{
  private readonly MyContext _context;

  public CategoriesController(MyContext context)
  {
    _context = context;
  }

  public IActionResult Index()
  {
    return View(_context.Categories.Include(c => c.Associations).ThenInclude(a => a.Product).ToList());
  }

  [HttpPost]
  public IActionResult Create(Category newCategory)
  {
    if (ModelState.IsValid)
    {
      _context.Categories.Add(newCategory);
      _context.SaveChanges();
    }
    return RedirectToAction("Index");
  }

  public IActionResult Show(int id)
  {
    Category category = _context.Categories.Include(p => p.Associations).ThenInclude(a => a.Product).FirstOrDefault(p => p.CategoryId == id);
    var associatedProductIds = category.Associations.Select(a => a.ProductId).ToList();
    ViewBag.Products = _context.Products.Where(c => !associatedProductIds.Contains(c.ProductId)).ToList();
    return View(category);
  }

  [HttpPost]
  public IActionResult AddProductToCategory(int categoryId, int productId)
  {

    var product = _context.Products.Find(productId);

    if (product == null)
    {
      return RedirectToAction("Index", "Categories");
    }

    Association association = new Association { CategoryId = categoryId, ProductId = productId };
    _context.Associations.Add(association);
    _context.SaveChanges();
    return RedirectToAction("Show", new { id = categoryId });
  }
}
