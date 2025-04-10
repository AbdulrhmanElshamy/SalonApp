using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Entities;

public class SalonService
{
    public Guid SalonId { get; set; }
    public Guid ServiceId { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }

    public virtual Salon Salon { get; set; }
    public virtual Service Service { get; set; }
}
