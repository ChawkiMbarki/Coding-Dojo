using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Products_and_Categories.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;

public class HomeController : Controller
{
  private readonly ILogger<HomeController> _logger;
  private readonly MyContext _context;

  public HomeController(ILogger<HomeController> logger, MyContext context)
  {
    _logger = logger;
    _context = context;
  }

  public IActionResult Index()
  {
    return View(_context.Products.Include(p => p.Associations).ThenInclude(a => a.Category).ToList());
  }

  [HttpPost]
  public IActionResult Create(Product newProduct)
  {
    if (ModelState.IsValid)
    {
      _context.Products.Add(newProduct);
      _context.SaveChanges();
    }
    return RedirectToAction("Index", "Home");
  }

  public IActionResult Privacy()
  {
    return View();
  }

  [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
  public IActionResult Error()
  {
    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
  }
}
