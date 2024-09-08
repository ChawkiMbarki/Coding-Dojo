using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Belt_Exam.Models;
using Microsoft.EntityFrameworkCore;

[SessionCheck]
public class RecipiesController : Controller
{
    private readonly MyContext _context;

    public RecipiesController(MyContext context)
    {
        _context = context;
    }

    public IActionResult Index(bool isVegetarian = false, bool isGlutenFree = false)
    {
        List<Recipy> recipies = _context.Recipies.Include(r => r.Ratings).Include(r => r.Creator).ToList();
        if (isVegetarian)
        {
            recipies = recipies.Where(r => r.Vegitarian).ToList();
        }
        if (isGlutenFree)
        {
            recipies = recipies.Where(r => r.Gluten).ToList();
        }

        ViewBag.UserId = HttpContext.Session.GetInt32("UserId");
        var model = new FilterViewModel
        {
            Recipies = recipies,
            IsVegetarian = isVegetarian,
            IsGlutenFree = isGlutenFree
        };
        return View(model);
    }

    public IActionResult New() => View();

    [HttpPost]
    public IActionResult New(Recipy recipy)
    {
        if (!ModelState.IsValid)
        {
            return View(recipy);
        }
        recipy.CreatorId = HttpContext.Session.GetInt32("UserId") ?? 0;
        _context.Recipies.Add(recipy);
        _context.SaveChanges();
        return RedirectToAction("Details", new { id = recipy.Id });
    }

    public IActionResult Details(int id)
    {
        var recipy = _context.Recipies.Include(r => r.Ratings).Include(r => r.Creator).FirstOrDefault(r => r.Id == id);

        if (recipy == null) return RedirectToAction("Index");

        var userId = HttpContext.Session.GetInt32("UserId");
        ViewBag.UserId = userId;
        ViewBag.HasRated = recipy.Ratings.Any(r => r.UserId == userId);
        ViewBag.AverageRating = recipy.Ratings.Any()
            ? $"{recipy.Ratings.Average(r => r.Value):0.0} out of 5"
            : "No ratings yet";
        ViewBag.Votes = recipy.Ratings.Count;

        return View("Details", recipy);
    }

    [HttpPost]
    public IActionResult Rate(int recipyId, int value)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        var rating = _context.Ratings.FirstOrDefault(r => r.RecipyId == recipyId && r.UserId == userId);

        if (rating != null)
        {
            rating.Value = value;
        }
        else
        {
            rating = new Rating { UserId = (int)userId, RecipyId = recipyId, Value = value };
            _context.Ratings.Add(rating);
        }

        _context.SaveChanges();
        return RedirectToAction("Details", new { id = recipyId });
    }

    [HttpPost]
    public IActionResult UnRate(int recipyId)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        var rating = _context.Ratings.FirstOrDefault(r => r.RecipyId == recipyId && r.UserId == userId);

        if (rating != null)
        {
            _context.Ratings.Remove(rating);
            _context.SaveChanges();
        }

        return RedirectToAction("Details", new { id = recipyId });
    }
    [HttpPost]
    public IActionResult UnRatee(int recipyId)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        var rating = _context.Ratings.FirstOrDefault(r => r.RecipyId == recipyId && r.UserId == userId);

        if (rating != null)
        {
            _context.Ratings.Remove(rating);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var recipy = _context.Recipies.Find(id);

        if (recipy == null)
            return RedirectToAction("Index");

        return View(recipy);
    }

    [HttpPost]
    public IActionResult Edit(int id, Recipy updatedRecipy)
    {
        if (!ModelState.IsValid)
            return View(updatedRecipy);

        var recipy = _context.Recipies.Find(id);

        if (recipy == null)
            return RedirectToAction("Index");

        recipy.Title = updatedRecipy.Title;
        recipy.Ingredient1 = updatedRecipy.Ingredient1;
        recipy.Ingredient2 = updatedRecipy.Ingredient2;
        recipy.Ingredient3 = updatedRecipy.Ingredient3;
        recipy.Ingredient4 = updatedRecipy.Ingredient4;
        recipy.Ingredient5 = updatedRecipy.Ingredient5;
        recipy.Instructions = updatedRecipy.Instructions;
        recipy.Vegitarian = updatedRecipy.Vegitarian;
        recipy.Gluten = updatedRecipy.Gluten;

        _context.Recipies.Update(recipy);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int recipyId)
    {
        var recipy = _context.Recipies.Find(recipyId);

        if (recipy != null)
        {
            _context.Recipies.Remove(recipy);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
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
