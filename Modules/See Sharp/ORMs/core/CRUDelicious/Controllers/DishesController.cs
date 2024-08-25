using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class DishesController : Controller
    {
        private readonly ILogger<DishesController> _logger;
        private readonly MyContext _context;

        public DishesController(ILogger<DishesController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("/Dishes/{dishId}")]
        public IActionResult Index(int dishId)
        {
            Dish? dish = _context.Dishes.FirstOrDefault(i => i.DishId == dishId);
            if (dish == null) return RedirectToAction("Index", "Home");
            return View(dish);
        }


        [HttpGet(("/Dishes/New"))]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost(("/Dishes/New"))]
        public IActionResult New(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("New", newDish);
            }
        }

        [HttpGet(("/Dishes/Edit/{dishId}"))]
        public IActionResult Edit(int dishId)
        {
            Dish? dish = _context.Dishes.FirstOrDefault(i => i.DishId == dishId);
            if (dish == null) return RedirectToAction("Index", "Home");
            return View(dish);
        }


        [HttpPost("/Dishes/Edit/{dishId}")]
        public IActionResult Edit(Dish newDish, int dishId)
        {
            Dish? oldDish = _context.Dishes.FirstOrDefault(i => i.DishId == dishId);
            if (oldDish == null)
            {
                return RedirectToAction("Index", "Home");
            }
            if (ModelState.IsValid)
            {
                oldDish.Name = newDish.Name;
                oldDish.Chef = newDish.Chef;
                oldDish.Tastiness = newDish.Tastiness;
                oldDish.Calories = newDish.Calories;
                oldDish.Description = newDish.Description;
                oldDish.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View("Edit", oldDish);
        }


        [HttpPost("/Dishes/Delete/{dishId}")]
        public IActionResult Delete(int dishId)
        {
            Dish? dishToDelete = _context.Dishes.SingleOrDefault(i => i.DishId == dishId);
            if (dishToDelete == null)
            {
                return RedirectToAction("Index", "Home");
            }
            _context.Dishes.Remove(dishToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

    }
}
