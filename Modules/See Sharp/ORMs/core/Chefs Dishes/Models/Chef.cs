#pragma warning disable CS8618
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chefs_Dishes.Models;

public class Chef
{
  [Key]
  public int ChefId { get; set; }

  [Required]
  public string FirstName { get; set; }

  [Required]
  public string LastName { get; set; }

  [Required]
  [PastDate(ErrorMessage = "Date of birth must be in the past.")]
  public DateTime DateOfBirth { get; set; }

  public List<Dish> AllDishes { get; set; } = new List<Dish>();

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;

}


public class PastDateAttribute : ValidationAttribute
{
  protected override ValidationResult IsValid(object value, ValidationContext validationContext)
  {
    DateTime dateValue;
    if (DateTime.TryParse(value.ToString(), out dateValue))
    {
      if (dateValue < DateTime.Now)
      {
        return ValidationResult.Success;
      }
      else
      {
        return new ValidationResult(ErrorMessage ?? "The date must be in the past.");
      }
    }
    return new ValidationResult("Invalid date format.");
  }
}

