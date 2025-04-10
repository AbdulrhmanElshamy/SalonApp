using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Entities;

public class OrderItem
{
   
    public Guid Id { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }
    public virtual Order Order { get; set; }

    [ForeignKey("Product")]
    public Guid ProductId { get; set; }
    public virtual Product Product { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
}
