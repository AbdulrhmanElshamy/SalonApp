using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Entities;

public class SalonService
{
    public int SalonId { get; set; }
    public int ServiceId { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }

    public virtual Salon Salon { get; set; }
    public virtual Service Service { get; set; }
}
