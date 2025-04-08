using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Entities;

public class Salon : AuditableEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Phone { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? ImageUrl { get; set; }

    public bool IsApproved { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    [ForeignKey("Owner")]
    public string OwnerId { get; set; }
    public virtual ApplicationUser Owner { get; set; }
    public virtual ICollection<SalonService> SalonServices { get; set; }
    public virtual ICollection<Booking> Bookings { get; set; }
    public virtual ICollection<Product> Products { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
}
