#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models;

public class User
{
  [Key]
  public int UserId { get; set; }

  [Required]
  public string FirstName { get; set; }

  [Required]
  public string LastName { get; set; }

  [Required]
  [EmailAddress]
  [UniqueEmail]
  public string Email { get; set; }

  [Required]
  [DataType(DataType.Password)]
  [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
  public string Password { get; set; }

  public List<Wedding> WeddingsPlanned { get; set; } = new List<Wedding>();
  public List<RSVP> RSVPs { get; set; } = new List<RSVP>();

  public DateTime CreatedAt { get; set; } = DateTime.Now;
  public DateTime UpdatedAt { get; set; } = DateTime.Now;

  [NotMapped]
  [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
  public string PasswordConfirm { get; set; }
}

public class UniqueEmailAttribute : ValidationAttribute
{
  protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
  {
    if (value == null)
    {
      return new ValidationResult("Email is required!");
    }

    var context = (MyContext)validationContext.GetService(typeof(MyContext));
    if (context.Users.Any(e => e.Email == value.ToString()))
    {
      return new ValidationResult("Email must be unique!");
    }
    return ValidationResult.Success;
  }
}
