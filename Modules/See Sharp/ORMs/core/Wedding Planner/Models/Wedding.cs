#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models;

public class Wedding
{
  [Key]
  public int Id { get; set; }

  [Required]
  public string WedderOne { get; set; }

  [Required]
  public string WedderTwo { get; set; }

  [Required]
  [FutureDate]
  public DateTime Date { get; set; }

  [Required]
  public string Address { get; set; }

  [Required]
  public int PlannerId { get; set; }

  public User? Planner { get; set; }
  public List<RSVP> RSVPs { get; set; } = new List<RSVP>();
}

public class FutureDateAttribute : ValidationAttribute
{
  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    if (value != null && (DateTime)value <= DateTime.Now)
    {
      return new ValidationResult("The wedding date must be in the future.");
    }
    return ValidationResult.Success;
  }
}
