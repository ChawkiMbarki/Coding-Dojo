using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Chefs_Dishes.Models;
using Microsoft.EntityFrameworkCore;

public class DishesController : Controller
{
  private readonly ILogger<DishesController> _logger;
  private readonly MyContext _context;

  public DishesController(ILogger<DishesController> logger, MyContext context)
  {
    _logger = logger;
    _context = context;
  }

  public IActionResult Index()
  {
    List<Dish> allDishes = _context.Dishes.Include(d => d.Chef).ToList();
    return View(allDishes);
  }

  public IActionResult New()
  {
    ViewBag.Chefs = _context.Chefs.Select(c => new SelectListItem
    {
      Value = c.ChefId.ToString(),
      Text = $"{c.FirstName} {c.LastName}"
    }).ToList();

    return View();
  }

  [HttpPost]
  public async Task<IActionResult> New(Dish dish)
  {
    if (ModelState.IsValid)
    {
      _context.Dishes.Add(dish);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index", "Dishes");
    }
    return View("New", dish);
  }
}
