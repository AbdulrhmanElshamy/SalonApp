using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SalonApp.Entities;

public class ApplicationRole : IdentityRole
{
    public ApplicationRole()
    {
        Id = Guid.NewGuid().ToString();
    }

    public bool IsDefault { get; set; }
    public bool IsDeleted { get; set; }
}




