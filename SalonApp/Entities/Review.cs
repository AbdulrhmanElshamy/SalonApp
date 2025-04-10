using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalonApp.Entities;

public class Review
{
    public Guid Id { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }

    [ForeignKey("Salon")]
    public Guid SalonId { get; set; }
    public virtual Salon Salon { get; set; }

    [ForeignKey("Service")]
    public Guid? ServiceId { get; set; }
    public virtual Service Service { get; set; }

    [ForeignKey("Product")]
    public Guid? ProductId { get; set; } 
    public virtual Product Product { get; set; }

    public int Rating { get; set; } 

    [StringLength(1000)]
    public string Comment { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
