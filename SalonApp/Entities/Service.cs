namespace SalonApp.Entities;

public class Service : AuditableEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ImageUrl { get; set; }

    public int Duration { get; set; }
    public virtual ICollection<SalonService> SalonServices { get; set; }
}
