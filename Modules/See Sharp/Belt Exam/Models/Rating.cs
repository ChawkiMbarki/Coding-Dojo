#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Belt_Exam.Models;

public class Rating
{
  [Key]
  public int Id { get; set; }
  
  public int Value { get; set; }
  [Required]
  public int UserId { get; set; }
  public User? User { get; set; }

  [Required]
  public int RecipyId { get; set; }
  public Recipy? Recipy { get; set; }
}
