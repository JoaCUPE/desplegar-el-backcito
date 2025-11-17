using BusTrack_center_API.Notifications.Domain.Model.Aggregates;
using BusTrack_center_API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;
namespace BusTrack_center_API.Shared.Infrastructure.Persistence.EFC;


/// <summary>
/// Central Entity Framework Core database context for the BusTrack backend.
/// </summary>
/// <remarks>
/// This context aggregates DbSet definitions for the different bounded contexts
/// (for now, <c>Notifications</c>) and applies common configuration conventions,
/// such as snake_case naming and entity configurations discovered via reflection.
/// </remarks>
public class AppDbContext : DbContext
{
    
    /// <summary>
    /// Initializes a new instance of the <see cref="AppDbContext"/> class
    /// using the provided DbContext options.
    /// </summary>
    /// <param name="options">
    /// Configuration options used by Entity Framework Core, including
    /// the database provider and connection settings.
    /// </param>
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    /// <summary>
    /// Represents the notifications collection in the database.
    /// </summary>
    /// <remarks>
    /// This <see cref="DbSet{TEntity}"/> maps to the notifications table
    /// and is used by the Notifications bounded context to query and persist
    /// <see cref="Notification"/> entities.
    /// </remarks>
    public DbSet<Notification> Notifications { get; set; } = null!;

    
    /// <summary>
    /// Configures context-wide options such as interceptors or providers.
    /// </summary>
    /// <param name="builder">
    /// The options builder used to configure this context instance.
    /// </param>
    /// <remarks>
    /// Currently this method delegates to the base implementation.
    /// It can be extended in the future to add logging, interceptors,
    /// or provider-specific settings.
    /// </remarks>
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        
        base.OnConfiguring(builder);
    }

    /// <summary>
    /// Configures the entity model and applies conventions.
    /// </summary>
    /// <param name="builder">
    /// The model builder used to configure entity mappings.
    /// </param>
    /// <remarks>
    /// This method:
    /// <list type="bullet">
    /// <item>Applies all IEntityTypeConfiguration classes in the current assembly.</item>
    /// <item>Enforces snake_case naming for tables and columns via
    /// <c>UseSnakeCaseNamingConvention()</c>.</item>
    /// </list>
    /// These conventions keep the database schema consistent across bounded contexts.
    /// </remarks>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        
        builder.UseSnakeCaseNamingConvention();
    }
}
