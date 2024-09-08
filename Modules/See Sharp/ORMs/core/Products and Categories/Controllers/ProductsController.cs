using Microsoft.AspNetCore.Mvc;
using Products_and_Categories.Models;
using Microsoft.EntityFrameworkCore;

namespace Products_and_Categories.Controllers;

public class ProductsController : Controller
{
  private readonly MyContext _context;

  public ProductsController(MyContext context)
  {
    _context = context;
  }

  public IActionResult Show(int id)
  {
    Product product = _context.Products.Include(p => p.Associations).ThenInclude(a => a.Category).FirstOrDefault(p => p.ProductId == id);
    var associatedCategoryIds = product.Associations.Select(a => a.CategoryId).ToList();
    ViewBag.Categories = _context.Categories.Where(c => !associatedCategoryIds.Contains(c.CategoryId)).ToList();
    return View(product);
  }

  [HttpPost]
  public IActionResult AddCategoryToProduct(int productId, int categoryId)
  {
    var category = _context.Categories.Find(categoryId);

    if (category == null)
    {
      return RedirectToAction("Index", "Home");
    }

    Association association = new Association { ProductId = productId, CategoryId = categoryId };
    _context.Associations.Add(association);
    _context.SaveChanges();

    return RedirectToAction("Show", new { id = productId });
  }
}
