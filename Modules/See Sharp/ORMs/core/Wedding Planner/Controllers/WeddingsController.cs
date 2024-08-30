using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Wedding_Planner.Models;
using Microsoft.EntityFrameworkCore;

[SessionCheck]
public class WeddingsController : Controller
{
    private readonly MyContext _context;

    public WeddingsController(MyContext context)
    {
        _context = context;
    }

    [HttpGet("/weddings")]
    public IActionResult Dashboard()
    {
        List<Wedding> weddings = _context.Weddings.Include(w => w.RSVPs).ThenInclude(r => r.User).ToList();
        return View(weddings);
    }

    [HttpGet("/weddings/new")]
    public IActionResult Plan()
    {
        return View();
    }

    [HttpPost("/weddings/create")]
    public IActionResult Create(Wedding wedding)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        if (!ModelState.IsValid)
        {
            return View("Plan");
        }

        wedding.PlannerId = (int)userId;
        _context.Weddings.Add(wedding);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpGet("/weddings/{weddingId}")]
    public IActionResult Details(int weddingId)
    {
        var wedding = _context.Weddings
            .Include(w => w.RSVPs)
            .ThenInclude(r => r.User)
            .FirstOrDefault(w => w.Id == weddingId);

        if (wedding == null)
        {
            return RedirectToAction("Dashboard");
        }

        return View(wedding);
    }

    [HttpPost("/weddings/{weddingId}/rsvp")]
    public IActionResult RSVP(int weddingId)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        var rsvp = new RSVP
        {
            UserId = (int)userId,
            WeddingId = weddingId
        };
        _context.RSVPs.Add(rsvp);
        _context.SaveChanges();
        return RedirectToAction("Dashboard");
    }

    [HttpPost("/weddings/{weddingId}/unrsvp")]
    public IActionResult UnRSVP(int weddingId)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        var rsvp = _context.RSVPs.FirstOrDefault(r => r.WeddingId == weddingId && r.UserId == userId);
        if (rsvp != null)
        {
            _context.RSVPs.Remove(rsvp);
            _context.SaveChanges();
        }

        return RedirectToAction("Dashboard");
    }

    [HttpPost("/weddings/{weddingId}/delete")]
    public IActionResult Delete(int weddingId)
    {
        var wedding = _context.Weddings.FirstOrDefault(w => w.Id == weddingId);
        if (wedding != null)
        {
            _context.Weddings.Remove(wedding);
            _context.SaveChanges();
        }

        return RedirectToAction("Dashboard");
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
