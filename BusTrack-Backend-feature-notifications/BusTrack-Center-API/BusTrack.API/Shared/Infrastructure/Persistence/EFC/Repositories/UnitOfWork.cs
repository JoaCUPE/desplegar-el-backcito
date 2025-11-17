using BusTrack_center_API.Shared.Domain.Repositories;
using BusTrack_center_API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace BusTrack_center_API.Shared.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
///     Unit of Work implementation for managing transactions
/// </summary>
/// <remarks>
///     This class implements the basic operations for a unit of work.
///     It requires the context to be passed in the constructor.
/// </remarks>

public class UnitOfWork(AppDbContext context) : IUnitOfWork
{
    public async Task CompleteAsync()
    {
        await context.SaveChangesAsync();
    }
}