using Microsoft.AspNetCore.Mvc;
using Chefs_Dishes.Models;

public class ChefsController : Controller
{
  private readonly ILogger<ChefsController> _logger;
  private readonly MyContext _context;

  public ChefsController(ILogger<ChefsController> logger, MyContext context)
  {
    _logger = logger;
    _context = context;
  }

  public IActionResult New()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> New(Chef chef)
  {
    if (ModelState.IsValid)
    {
      _context.Chefs.Add(chef);
      await _context.SaveChangesAsync();
      return RedirectToAction("Index", "Home");
    }
    return View("New", chef);
  }

}
