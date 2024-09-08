using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Login_and_Registration.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Login_and_Registration.Controllers;

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
    int? userId = HttpContext.Session.GetInt32("UserId");
    if (userId != null)
    {
      return RedirectToAction("Success");
    }
    return View(new IndexViewModel
    {
      RegisterModel = new User(),
      LoginModel = new Login()
    });
  }

  [HttpPost]
  public async Task<IActionResult> Login(Login loginModel)
  {
    if (!ModelState.IsValid)
    {
      return View("Index", new IndexViewModel { LoginModel = loginModel });
    }

    var userInDb = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginModel.LoginEmail);
    if (userInDb == null || !VerifyPassword(userInDb.Password, loginModel.LoginPassword))
    {
      ModelState.AddModelError(string.Empty, "Invalid Email/Password");
      return View("Index", new IndexViewModel { LoginModel = loginModel });
    }

    HttpContext.Session.SetInt32("UserId", userInDb.UserId);
    return RedirectToAction("Success");
  }

  [HttpPost]
  public async Task<IActionResult> Register(User registerModel)
  {
    if (!ModelState.IsValid)
    {
      return View("Index", new IndexViewModel { RegisterModel = registerModel });
    }

    registerModel.Password = HashPassword(registerModel.Password);
    _context.Users.Add(registerModel);
    await _context.SaveChangesAsync();

    HttpContext.Session.SetInt32("UserId", registerModel.UserId);
    return RedirectToAction("Success");
  }

  [SessionCheck]
  public IActionResult Success()
  {
    return View();
  }


  public IActionResult LogOut()
  {
    HttpContext.Session.Clear();
    return RedirectToAction("Index");
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

  private string HashPassword(string password)
  {
    var hasher = new PasswordHasher<User>();
    return hasher.HashPassword(new User(), password);
  }

  private bool VerifyPassword(string hashedPassword, string password)
  {
    var hasher = new PasswordHasher<User>();
    return hasher.VerifyHashedPassword(new User(), hashedPassword, password) == PasswordVerificationResult.Success;
  }

  public class SessionCheckAttribute : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      if (context.HttpContext.Session.GetInt32("UserId") == null)
      {
        context.Result = new RedirectToActionResult("Index", "Home", null);
      }
    }
  }
}
