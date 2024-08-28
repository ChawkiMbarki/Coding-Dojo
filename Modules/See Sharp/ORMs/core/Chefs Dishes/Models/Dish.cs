#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chefs_Dishes.Models;

public class Dish
{
  [Key]
  public int DishId { get; set; }

  [Required]
  public string Name { get; set; }

  [Required]
  [Range(1, int.MaxValue, ErrorMessage = "Calories must be greater than 0.")]
  public int Calories { get; set; }

  [Required]
  [Range(1, 5, ErrorMessage = "Tastiness must be between 1 and 5.")]
  public int Tastiness { get; set; }

  [Required]
  public int ChefId { get; set; }
  public Chef? Chef { get; set; }


  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;

}
