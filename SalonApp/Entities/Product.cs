using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Entities;

public class Product : AuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string? ImageUrl { get; set; }

    [ForeignKey("Salon")]
    public int SalonId { get; set; }
    public virtual Salon Salon { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}
