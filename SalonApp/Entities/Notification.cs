using SalonApp.Entities.consts.enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Entities;

public class Notification
{
    
    public Guid Id { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }
    public string Title { get; set; } = null!;

    public string Message { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsRead { get; set; }

    public NotificationType Type { get; set; }

    public string ReferenceId { get; set; }
}