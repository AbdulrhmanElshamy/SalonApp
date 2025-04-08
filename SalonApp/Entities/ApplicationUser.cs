using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SalonApp.Entities;

public sealed class ApplicationUser : IdentityUser
{

    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsDisabled { get; set; }

    public List<RefreshToken> RefreshTokens { get; set; } = [];

    [MaxLength(255)]
    public string ShippingAddress { get; set; } = string.Empty;

    public  ICollection<Booking> Bookings { get; set; }
    public  ICollection<Order> Orders { get; set; }
    public  ICollection<Review> Reviews { get; set; }
    public  Salon OwnedSalon { get; set; }
}

