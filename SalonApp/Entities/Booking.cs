﻿using SalonApp.Entities.consts.enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalonApp.Entities;

public class Booking : AuditableEntity
{
    public Guid Id { get; set; }

    [ForeignKey("User")]
    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }

    [ForeignKey("Salon")]
    public int SalonId { get; set; }
    public virtual Salon Salon { get; set; }

    [ForeignKey("Service")]
    public int ServiceId { get; set; }
    public virtual Service Service { get; set; }

    public DateTime AppointmentDate { get; set; }

    public BookingStatus Status { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
}
