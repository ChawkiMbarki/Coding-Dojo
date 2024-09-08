using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Chefs_Dishes.Models;
using Microsoft.EntityFrameworkCore;

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
    List<Chef> AllChefs = _context.Chefs.Include(c => c.AllDishes).ToList();
    return View(AllChefs);
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
