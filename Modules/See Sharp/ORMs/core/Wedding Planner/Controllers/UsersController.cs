using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Wedding_Planner.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Wedding_Planner.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<UsersController> _logger;
    private readonly MyContext _context;

    public UsersController(ILogger<UsersController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (userId != null)
        {
            return RedirectToAction("Dashboard", "Weddings");
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
        return RedirectToAction("Dashboard", "Weddings");
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
        return RedirectToAction("Dashboard", "Weddings");
    }


    public IActionResult LogOut()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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
            int? userId = context.HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                context.Result = new RedirectToActionResult("Index", "Users", null);
            }
            base.OnActionExecuting(context);
        }
    }
}