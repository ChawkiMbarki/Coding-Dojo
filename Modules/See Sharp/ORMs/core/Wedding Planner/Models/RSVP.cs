#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wedding_Planner.Models;

public class RSVP
{
  [Key]
  public int Id { get; set; }

  [Required]
  public int UserId { get; set; }
  public User? User { get; set; }

  [Required]
  public int WeddingId { get; set; }
  public Wedding? Wedding { get; set; }
}
