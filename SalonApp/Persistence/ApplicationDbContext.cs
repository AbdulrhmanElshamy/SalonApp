using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalonApp.Entities;
using System.Reflection;
using System.Reflection.Emit;

namespace SalonApp.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) :
    IdentityDbContext<ApplicationUser, ApplicationRole, string>(options)
{
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public DbSet<Salon> Salons { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<SalonService> SalonServices { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Notification> Notifications { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        var cascadeFKs = builder.Model
                .GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.DeleteBehavior == DeleteBehavior.Cascade && !fk.IsOwnership);

        foreach (var fk in cascadeFKs)
            fk.DeleteBehavior = DeleteBehavior.Restrict;

        builder.Entity<SalonService>()
               .HasKey(ss => new { ss.SalonId, ss.ServiceId });

        builder.Entity<SalonService>()
            .HasOne(ss => ss.Salon)
            .WithMany(s => s.SalonServices)
            .HasForeignKey(ss => ss.SalonId);

        builder.Entity<SalonService>()
            .HasOne(ss => ss.Service)
            .WithMany(s => s.SalonServices)
            .HasForeignKey(ss => ss.ServiceId);

        builder.Entity<ApplicationUser>()
        .HasQueryFilter(c => !c.IsDisabled);




        base.OnModelCreating(builder);

    }
}