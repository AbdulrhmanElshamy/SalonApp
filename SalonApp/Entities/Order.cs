using SalonApp.Entities.consts.enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Entities;

public class Order
{

    public Guid Id { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }

    public DateTime OrderDate { get; set; } = DateTime.UtcNow;

    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }

    public OrderStatus Status { get; set; }
    public string ShippingAddress { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }
}
